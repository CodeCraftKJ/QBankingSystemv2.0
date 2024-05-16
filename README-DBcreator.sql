GO
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