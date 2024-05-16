# QBankingSystemv2.0

QBankingSystemv2.0 is a simulation application of a banking system, allowing users to interact with a virtual representation of a bank.
Please note that this application is for simulation purposes only and does not perform real banking operations. 
Users can control virtual bank accounts, conduct simulated transactions, and manage virtual loans within the db.

## Features

- **Bank Account Management:** Users can add, remove, and view their bank accounts.
- **Transaction Processing:** The application allows users to conduct transactions between their own accounts and external accounts.
- **Loan Management:** Users can take out loans, setting the amount and interest rate, as well as repay borrowed funds.

## Technologies

- **C#:** Programming language used for implementing business logic and user interface.
- **Windows Forms:** Graphics library used for creating user interfaces in desktop applications.
- **SQL Server:** Database used for storing user data, bank accounts, and transactions.

## Running Instructions

1. Clone the repository to your local computer.
2. Open the project in a C#-compatible development environment.
3. Compile the project and run the application.

**Note:** To run the program, you need access to a database. You can create your own local database according to the provided schema in the README and connect it. Currently, the database is not connected in the code.

## Database Configuration

To configure the database connection, create an appsettings.json file with the following content:

```json
{
  "ConnectionStrings": {
    "MainDatabaseConnection": "YourConnectionString"
  }
}

![image](https://github.com/CodeCraftKJ/QBankingSystemv2.0/assets/137210777/315cd6b0-72c8-4be4-9620-36eb1fc0101f)


