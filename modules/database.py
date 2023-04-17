from datetime import datetime
from typing import Any

import aiosqlite

from classes.errors import AccountExistsError
from modules.tokens import generate_token


class Database:
    def __init__(self, db: str):
        self.db_path = db

    async def async_init(self):
        async with aiosqlite.connect(self.db_path) as db:
            await db.execute(
                """
                CREATE TABLE IF NOT EXISTS customers (
                    customer_id INTEGER PRIMARY KEY,
                    username TEXT,
                    password TEXT,
                    access_token TEXT,
                    UNIQUE (username)
                )
                """
            )
            await db.execute(
                """
                CREATE TABLE IF NOT EXISTS documents (
                    customer_id INTEGER NOT NULL,
                    document_data BLOB,
                    FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
                    UNIQUE(customer_id)
                    )
                """
            )

            await db.execute(
                """
                CREATE TABLE IF NOT EXISTS personal_details (
                    customer_id INTEGER PRIMARY KEY,
                    first_name TEXT,
                    last_name TEXT,
                    DoB DATE,
                    verified BOOLEAN DEFAULT 0,
                    FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
                    UNIQUE (customer_id)
                )
                """
            )
            await db.commit()

    async def execute(self, query: str, *params: Any) -> None:
        """
        __Summary__

        Execute a query

        __Arguments__

        * query (str): The SQL query to execute
        * params (Any): The parameters to pass to the query

        __Returns__

        * None
        """
        async with aiosqlite.connect(self.db_path) as db:
            await db.execute(query, (*params,))
            await db.commit()

    async def fetch_one(self, query: str, *params: Any) -> Any:
        """
        __Summary__

        Fetch one row from the database

        __Arguments__

        * query (str): The SQL query to execute
        * params (Any): The parameters to pass to the query

        __Returns__

        * Any: A row
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(query, params)
            result = await cur.fetchone()
            await cur.close()
        return result

    async def fetch_all(self, query: str, *params: Any) -> list[Any]:
        """
        __Summary__

        Fetch all rows from the database

        __Arguments__

        * query (str): The SQL query to execute
        * params (Any): The parameters to pass to the query

        __Returns__

        * list[Any]: A list of rows
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(query, params)
            result = await cur.fetchall()
            await cur.close()
        return list(result)

    async def get_customer_id(self, username: str) -> Any:
        """
        __Summary__

        Get the customer ID of a user

        __Arguments__

        * username (str): The username of the user

        __Returns__

        * Any: The customer ID of the user
        """

        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT customer_id FROM customers WHERE username=? LIMIT 1",
                (username,),
            )
            result = await cur.fetchone()
            await cur.close()
        return result[0] if result is not None else None

    async def account_registered(self, username: str) -> bool:
        """
        __Summary__

        Check if an account is registered using their username

        __Arguments__

        * username (str): The username of the user

        __Returns__

        * bool: True if the account is registered, False otherwise

        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT customer_id FROM customers WHERE username=?", (username,)
            )
            result = await cur.fetchone()
            await cur.close()
        return result is not None

    async def token_exists(self, access_token: str) -> bool:
        """
        __Summary__

        Check if an access token exists

        __Arguments__

        * access_token (str): The access token to check

        __Returns__

        * bool: True if the access token exists, False otherwise
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT customer_id FROM customers WHERE access_token=?",
                access_token,
            )
            result = await cur.fetchone()
            await cur.close()
        return result is not None

    async def customer_registered(self, customer_id: int) -> bool:
        """
        __Summary__

        Check if a customer is registered using their customer ID

        __Arguments__

        * customer_id (int): The customer ID of the customer

        __Returns__

        * bool: True if the customer is registered, False otherwise
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT customer_id FROM customers WHERE customer_id=?", (customer_id,)
            )
            result = await cur.fetchone()
            await cur.close()
        return result is not None

    async def credentials_match(self, username: str, password_hash: str) -> bool:
        """
        __Summary__

        Check if the username and password provided match those stored in the database

        __Arguments__

        * username (str): The username of the user
        * password_hash (str): The hashed password of the user

        __Returns__

        * bool: True if the credentials match, False otherwise
        """

        result: list[str] = await self.fetch_one(
            "SELECT username, password FROM customers WHERE username=? AND password=?",
            username,
            password_hash,
        )
        assert result is not None, "Invalid username or password"

        return result[0] == username and result[1] == password_hash

    async def insert_document(
            self, customer_id: int, file_data: bytes
    ) -> None:
        """
        __Summary__

        Insert a document into the database

        __Arguments__

        * customer_id (int): The customer ID of the customer
        * file_data (bytes): The contents of the document

        __Returns__

        * None
        """
        async with aiosqlite.connect(self.db_path) as db:
            await db.execute(
                "INSERT INTO documents (customer_id, document_data) VALUES ($1, $2) ON CONFLICT("
                "customer_id) DO UPDATE SET document_data = $2 WHERE customer_id = $1",
                (customer_id, file_data),
            )
            await db.commit()

    async def register_customer(self, username: str, password_hash: str, first_name: str, last_name: str,
                                date_of_birth: str) -> int:
        """
        __Summary__

        Register a customer

        __Arguments__

        * username (str): The username of the customer
        * password_hash (str): The hashed password of the customer
        * name (str): The name of the customer
        * date_of_birth (str): The date of birth of the customer

        __Returns__

        * int: The customer ID of the customer
        """

        if await self.account_registered(username):
            raise AccountExistsError(username)

        await self.execute(
            "INSERT INTO customers (username, password, access_token) VALUES (?, ?, ?) ON CONFLICT DO NOTHING",
            username,
            password_hash,
            generate_token(username, password_hash),
        )
        customer_id = await self.get_customer_id(username)
        await self.execute(
            "INSERT INTO personal_details (customer_id, first_name, last_name, DoB, verified) VALUES (?, ?, ?, ?, "
            "?) ON CONFLICT DO NOTHING",
            customer_id,
            first_name,
            last_name,
            date_of_birth,
            False
        )
        return customer_id

    async def get_token(self, username: str) -> str:
        """
        __Summary__

        Get the access token for a user

        __Arguments__

        * username (str): The username of the user

        __Returns__

        * str: The access token for the user
        """

        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT access_token FROM customers WHERE username=?",
                (username,),
            )
            result = await cur.fetchone()
            await cur.close()

        return result[0] if result is not None else None

    async def fetch_document(self, customer_id):
        """
        __Summary__

        Fetch the document for a customer

        __Arguments__

        * customer_id (int): The customer ID of the customer

        __Returns__

        * bytes: The document data
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT document_data FROM documents WHERE customer_id=?",
                (customer_id,),
            )
            result = await cur.fetchone()
            await cur.close()

        return result[0] if result is not None else None

    async def fetch_personal_details(self, customer_id):
        """
        __Summary__

        Fetch the personal details for a customer

        __Arguments__

        * customer_id (int): The customer ID of the customer

        __Returns__

        * list: The personal details
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT first_name, last_name, DoB, verified FROM personal_details WHERE customer_id=?",
                (customer_id,),
            )
            result = await cur.fetchone()
            await cur.close()

        return result if result is not None else None

    async def verify_account(self, customer_id: int, dob: datetime.date) -> None:
        """
        __Summary__

        Verify a customer's account

        __Arguments__

        * customer_id (int): The customer ID of the customer
        * dob (datetime.date): The date of birth of the customer

        __Returns__

        * None
        """
        await self.execute(
            "UPDATE personal_details SET verified = ?, DoB = ? WHERE customer_id = ?",
            True,
            dob,
            customer_id,
        )

    async def customer_verified(self, customer_id: int) -> bool:
        """
        __Summary__

        Check if a customer's account is verified

        __Arguments__

        * customer_id (int): The customer ID of the customer

        __Returns__

        * bool: True if the customer's account is verified, False otherwise
        """
        async with aiosqlite.connect(self.db_path) as db:
            cur = await db.execute(
                "SELECT verified FROM personal_details WHERE customer_id=?",
                (customer_id,),
            )
            result = await cur.fetchone()
            await cur.close()

        return result[0] if result is not None else False
    