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

![image](https://github.com/CodeCraftKJ/QBankingSystemv2.0/assets/137210777/0c6dce98-bb8c-46e3-b225-6fe07b911597)


## Database Configuration

To configure the database connection, create an appsettings.json file with the following content:

```json
{
  "ConnectionStrings": {
    "MainDatabaseConnection": "YourConnectionString"
  }
}
[Uploading DB-SQLcreator.sql…]()GO
CREATE TABLE QPayAccounts (
    AccountID INT PRIMARY KEY,
    UserID INT,
    AccountType NVARCHAR(50),
    Balance DECIMAL(18, 2),
    Currency NVARCHAR(3),
    CreatedAt DATETIME,
    Status NVARCHAR(50),
    AccountName NVARCHAR(50),
    DepositLimit DECIMAL(18, 2),
    WithdrawalLimit DECIMAL(18, 2),
    TransferLimit DECIMAL(18, 2),
    FOREIGN KEY (UserID) REFERENCES QPayUsers(UserID)
);
GO
CREATE TABLE QPayTransactions (
    TransactionID INT PRIMARY KEY,
    SourceAccountID INT,
    DestinationAccountID INT,
    TransactionType NVARCHAR(50),
    Amount DECIMAL(18, 2),
    TransactionDate DATETIME,
    Description NVARCHAR(MAX),
    FOREIGN KEY (SourceAccountID) REFERENCES QPayAccounts(AccountID),
    FOREIGN KEY (DestinationAccountID) REFERENCES QPayAccounts(AccountID)
);
GO
CREATE TABLE QPayLoans (
    LoanID INT PRIMARY KEY,
    UserID INT,
    LoanAmount DECIMAL(18, 2),
    InterestRate DECIMAL(18, 2),
    RemainingBalance DECIMAL(18, 2),
    LoanAccountID INT,
    FOREIGN KEY (UserID) REFERENCES QPayUsers(UserID),
    FOREIGN KEY (LoanAccountID) REFERENCES QPayAccounts(AccountID)
);
GO
CREATE TABLE QPayHarshedPasswords (
    UserID INT PRIMARY KEY,
    PasswordHash NVARCHAR(MAX),
    FOREIGN KEY (UserID) REFERENCES QPayUsers(UserID)
);
GO
CREATE TABLE QPayUsers (
    UserID INT PRIMARY KEY,
    PIN NVARCHAR(10),
    Pesel NVARCHAR(20),
    Phone NVARCHAR(20),
    LastName NVARCHAR(50),
    FirstName NVARCHAR(50),
    UserName NVARCHAR(50),
    MaterialStatus NVARCHAR(20),
    Address NVARCHAR(100),
    BirthDate DATE,
    Email NVARCHAR(100),
    RegistrationDate DATETIME
);
GO
CREATE TABLE QPayLogTable (
    LogID INT PRIMARY KEY,
    UserID INT,
    Action NVARCHAR(MAX),
    LogDateTime DATETIME,
    FOREIGN KEY (UserID) REFERENCES QPayUsers(UserID)
);
GO
CREATE TRIGGER DeleteLoanAndAccount
ON QPayAccounts
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @LoanAccountID INT, @UserID INT, @HasSufficientBalance BIT;
    SELECT @HasSufficientBalance = CASE 
                                        WHEN EXISTS (
                                            SELECT 1
                                            FROM inserted 
                                            WHERE AccountType = 'Loan Account' 
                                            AND Balance >= (
                                                SELECT SUM(LoanAmount + (LoanAmount * InterestRate / 100)) 
                                                FROM QPayLoans 
                                                WHERE LoanAccountID = inserted.AccountID
                                            )
                                        )
                                        THEN 1
                                        ELSE 0
                                    END;
    IF @HasSufficientBalance = 1
    BEGIN
        BEGIN TRY
            DELETE FROM QPayTransactions
            WHERE SourceAccountID IN (
                    SELECT DestinationAccountID 
                    FROM QPayTransactions 
                    INNER JOIN QPayAccounts ON QPayTransactions.SourceAccountID = QPayAccounts.AccountID 
                    WHERE QPayAccounts.AccountType = 'Loan Account'
                )
                OR DestinationAccountID IN (
                    SELECT DestinationAccountID 
                    FROM QPayTransactions 
                    INNER JOIN QPayAccounts ON QPayTransactions.DestinationAccountID = QPayAccounts.AccountID 
                    WHERE QPayAccounts.AccountType = 'Loan Account'
                );
            DELETE FROM QPayLoans 
            WHERE LoanAccountID IN (
                SELECT AccountID 
                FROM inserted 
                WHERE AccountType = 'Loan Account'
            );
            SELECT @LoanAccountID = AccountID, @UserID = UserID 
            FROM inserted 
            WHERE AccountType = 'Loan Account';
            DELETE FROM QPayAccounts WHERE AccountID = @LoanAccountID;
            INSERT INTO QPayLogTable (UserID, Action, LogDateTime) VALUES (@UserID, 'Deleted loan account and associated loans', GETDATE());
            COMMIT;
        END TRY
        BEGIN CATCH
            ROLLBACK;
            INSERT INTO QPayLogTable (UserID, Action, LogDateTime) VALUES (@UserID, 'Error occurred: ' + ERROR_MESSAGE(), GETDATE());
        END CATCH
    END
END;
GO
SELECT * FROM QPayAccounts
SELECT * FROM QPayTransactions
SELECT * FROM QPayLoans
SELECT * FROM QPayHarshedPasswords
SELECT * FROM QPayUsers
SELECT * FROM QPayLogTable


