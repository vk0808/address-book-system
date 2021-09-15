-- Sp addition
CREATE PROCEDURE [dbo].[SpAddPersonDetails]
(
	@FirstName VARCHAR(255),
	@LastName VARCHAR(255),
	@Address VARCHAR(250),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@Zip VARCHAR(6),
	@PhoneNumber VARCHAR(12),
	@Email VARCHAR(100),
	@BookName VARCHAR(20),
	@BookType VARCHAR(10)
)
AS
BEGIN
	INSERT INTO address (FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, BookName, BookType)
	VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email, @BookName, @BookType)
END
GO


-- Sp for update
CREATE PROCEDURE [dbo].[spUpdatePersonCityState]
	@BookID INT,
	@City VARCHAR(100),
	@State VARCHAR(100)
AS
BEGIN
SET XACT_ABORT ON;
BEGIN TRY
BEGIN TRANSACTION;
	UPDATE address
	SET City = @City, State = @State
	WHERE BookID = @BookID;
	SELECT BookID, City, State
	FROM address WHERE BookID = @BookID;
	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
		ROLLBACK TRANSACTION;
	END;

IF(XACT_STATE()) = 1
	BEGIN
		PRINT N'The transaction is committable. '+'Committing transaction.'
		COMMIT TRANSACTION;
	END;
END CATCH
END
GO