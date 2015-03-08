--Getting Member password

CREATE PROCEDURE getPwdFrmDB (@memberId int)
AS
BEGIN
SELECT LMS_MEMBER_DETAILS.[PASSWORD] FROM LMS_MEMBER_DETAILS WHERE LMS_MEMBER_DETAILS.MEMBER_ID=@memberId
END
exec getPwdFrmDB 100002


--BookSearch
CREATE PROCEDURE spBookSearchTitleAndAuthor(@bookTitle varchar(100),@bookAuthor varchar(50))
AS
BEGIN
SELECT BOOK_ID as 'BOOK ID',
LMS_ALL_BOOKS.BOOK_CODE AS 'BOOK CODE',
BOOK_TITLE AS 'BOOK TITLE',
AUTHOR AS 'AUTHOR',
BOOK_EDITION AS 'EDITION',
BOOK_AVAILABILITY AS 'AVAILABILITY' 
FROM LMS_BOOK_DETAILS INNER JOIN LMS_ALL_BOOKS 
ON LMS_ALL_BOOKS.BOOK_CODE=LMS_BOOK_DETAILS.BOOK_CODE 
WHERE LMS_BOOK_DETAILS.AUTHOR LIKE '%'+@bookAuthor+'%' AND LMS_BOOK_DETAILS.BOOK_TITLE LIKE '%'+@bookTitle+'%'
END


DROP PROC spBookSearchTitleAndAuthor


--GetBookHistory for the memberid

CREATE PROCEDURE spGetBookHistory (@memberId int)
AS
BEGIN

SELECT 
LMS_BOOK_ISSUE.BOOK_ID AS 'Book ID',
LMS_BOOK_DETAILS.BOOK_TITLE AS 'Book Title',
LMS_BOOK_ISSUE.DATE_ISSUE AS 'Issue Date',
LMS_BOOK_ISSUE.DATE_DUE AS 'Due Date',
LMS_BOOK_ISSUE.DATE_RETURN AS 'Return Date',
LMS_BOOK_ISSUE.DAYS_DELAYED AS 'Days Delayed',
LMS_BOOK_ISSUE.BOOK_ISSUE_NUMBER AS 'Book Issue No'
FROM 
LMS_BOOK_ISSUE 
JOIN LMS_ALL_BOOKS ON LMS_ALL_BOOKS.BOOK_ID=LMS_BOOK_ISSUE.BOOK_ID
JOIN LMS_BOOK_DETAILS ON LMS_ALL_BOOKS.BOOK_CODE=LMS_BOOK_DETAILS.BOOK_CODE
WHERE LMS_BOOK_ISSUE.MEMBER_ID=@memberId
END

DROP PROC spGetBookHistory


--Forgot Password SP
create procedure spSecurityQuestion(@memberId int)
as 
begin
select SECURITY_QUESTION from LMS_MEMBER_DETAILS where MEMBER_ID=@memberId
end
exec spSecurityQuestion 100001

drop procedure spSecurityQuestion


--BookTransaction Book Issue

CREATE PROCEDURE spBookIssue(@memberId int,@bookId int,@issueDate date)
AS
BEGIN
DECLARE @errorMessage nvarchar(255)
IF (EXISTS (SELECT MEMBER_ID FROM LMS_MEMBER_DETAILS WHERE MEMBER_ID=@memberId) AND EXISTS (SELECT BOOK_ID FROM LMS_ALL_BOOKS WHERE BOOK_ID=@bookId AND BOOK_AVAILABILITY='Y'))
BEGIN
INSERT 
INTO 
LMS_BOOK_ISSUE
(MEMBER_ID,BOOK_ID,DATE_ISSUE)
VALUES
(@memberId,@bookId,@issueDate)
END
ELSE
IF (EXISTS (SELECT BOOK_ID FROM LMS_ALL_BOOKS WHERE BOOK_ID=@bookId AND BOOK_AVAILABILITY='N') )
BEGIN
SET @errorMessage = 'Book alread Issued! False Entry!'
RAISERROR (@errorMessage, 11,1)
END
ELSE
BEGIN
SET @errorMessage = 'Check your Member ID and Book ID'
RAISERROR (@errorMessage, 11,1)
END
END

EXEC spBookIssue 100002,1002,'2014-01-24'

DROP PROC spBookIssue
--Book Return

CREATE PROCEDURE spBookReturn(@memberId int,@bookId int,@returnDate date)
AS
BEGIN
DECLARE @errorMessage nvarchar(255)
IF (EXISTS (SELECT MEMBER_ID FROM LMS_BOOK_ISSUE WHERE MEMBER_ID=@memberId AND BOOK_ID=@bookId AND DATE_RETURN IS NULL))
BEGIN
UPDATE 
LMS_BOOK_ISSUE
SET DATE_RETURN=@returnDate
WHERE
MEMBER_ID=@memberId
AND
BOOK_ID=@bookId
AND
BOOK_ISSUE_NUMBER=(SELECT MAX(BOOK_ISSUE_NUMBER) FROM LMS_BOOK_ISSUE
WHERE MEMBER_ID=@memberId AND BOOK_ID=@bookId)
END
ELSE
IF (EXISTS (SELECT BOOK_ID FROM LMS_ALL_BOOKS WHERE BOOK_ID=@bookId AND BOOK_AVAILABILITY='Y') )
BEGIN
SET @errorMessage = 'Book alread Returned! False Entry!'
RAISERROR (@errorMessage, 11,1)
END
ELSE
BEGIN
SET @errorMessage = 'Check your Member ID and Book ID'
RAISERROR (@errorMessage, 11,1)
END
END

exec spBookReturn 100002,1003,'2014-01-24'

DROP PROC spBookReturn


--MemberManagement Add Member


CREATE PROCEDURE spAddMemberDetails
(
	@memberName VARCHAR(20),
	@phoneNumber BIGINT,@password VARCHAR(20),@memberEmail VARCHAR(30),@securityQuestion VARCHAR(50),
	@answer VARCHAR(20),@idProofType VARCHAR(20),@idProofValue VARCHAR(20),@registerDate DATE
)
AS
BEGIN
INSERT 
INTO 
LMS_MEMBER_DETAILS 
(MEMBER_NAME,PHONE_NUMBER,[PASSWORD],MEMBER_EMAIL,SECURITY_QUESTION,ANSWER,ID_PROOF_TYPE,ID_PROOF_NUMBER,DATE_REGISTER)
VALUES
(@memberName,@phoneNumber,@password,@memberEmail,@securityQuestion,@answer,@idProofType,@idProofValue,@registerDate)
END



--GetMemberDetails To Edit
CREATE PROCEDURE spGetMemberDetails(@memberId int)
AS
BEGIN
SELECT
	MEMBER_ID,
	MEMBER_NAME,
	PHONE_NUMBER,
	[PASSWORD],
	MEMBER_EMAIL,
	SECURITY_QUESTION,
	ANSWER,
	ID_PROOF_TYPE,
	ID_PROOF_NUMBER,
	DATE_REGISTER
FROM LMS_MEMBER_DETAILS
WHERE MEMBER_ID=@memberId
END



--Edit Member

CREATE PROCEDURE spEditMemberDetails
(
	@memberId int,@memberName VARCHAR(20),
	@phoneNumber BIGINT,@memberEmail VARCHAR(30),@securityQuestion VARCHAR(50),
	@answer VARCHAR(20),@idProofType VARCHAR(20),@idProofValue VARCHAR(20)
)
AS
BEGIN
UPDATE
LMS_MEMBER_DETAILS
SET
MEMBER_NAME=@memberName,
PHONE_NUMBER=@phoneNumber,
MEMBER_EMAIL=@memberEmail,
SECURITY_QUESTION=@securityQuestion,
ANSWER=@answer,
ID_PROOF_TYPE=@idProofType,
ID_PROOF_NUMBER=@idProofValue
WHERE MEMBER_ID=@memberId
END

DROP PROC spEditMemberDetails


--Add Supplier
CREATE PROCEDURE spAddSupplierDetails
(
	@supplierName VARCHAR(20),@phoneNumber BIGINT,@supplierEmail VARCHAR(30)
)
AS
BEGIN
INSERT 
INTO 
LMS_SUPPLIER_DETAILS
(SUPPLIER_NAME,CONTACT,EMAIL)
VALUES
(@supplierName,@phoneNumber,@supplierEmail)
END

--GetSupplierDetails To Edit
CREATE PROCEDURE spGetSupplierDetails(@supplierId int)
AS
BEGIN
SELECT
	LMS_SUPPLIER_DETAILS.SUPPLIER_ID,LMS_SUPPLIER_DETAILS.SUPPLIER_NAME,
	LMS_SUPPLIER_DETAILS.CONTACT,LMS_SUPPLIER_DETAILS.EMAIL
FROM LMS_SUPPLIER_DETAILS
WHERE SUPPLIER_ID=@supplierId
END

--Edit Member

CREATE PROCEDURE spEditSupplierDetails
(
	@supplierId int,@supplierName varchar(20),@phoneNumber bigint,@supplierEmail varchar(30)
)
AS
BEGIN
UPDATE
LMS_SUPPLIER_DETAILS
SET
SUPPLIER_NAME=@supplierName,
CONTACT=@phoneNumber,
EMAIL=@supplierEmail
WHERE SUPPLIER_ID=@supplierId
END


--Book Add New Data

CREATE PROCEDURE spAddNewBookDetails
(
	@bookCode VARCHAR(6),@bookTitle VARCHAR(100),@category VARCHAR(15),@author VARCHAR(50),@publications VARCHAR(50),@bookEdition NUMERIC(2,0),
	@price NUMERIC(6, 2)
)
AS
BEGIN
INSERT 
INTO 
LMS_BOOK_DETAILS
(BOOK_CODE,BOOK_TITLE,AUTHOR,CATEGORY,PUBLICATIONS,BOOK_EDITION,PRICE)
VALUES 
(@bookCode,@bookTitle,@author,@category,@publications,@bookEdition,@price)
END


--Book Code ddl

CREATE PROCEDURE spBookCodeSelect
(@categorySelected varchar(15))
AS
BEGIN
SELECT BOOK_CODE as 'bookcode' FROM LMS_BOOK_DETAILS WHERE CATEGORY=@categorySelected GROUP BY BOOK_CODE 
END
GO

--Book add copies

CREATE PROCEDURE spAddBookCopies
(
	@bookCode varchar(15),
	@availability varchar(1),
	@supplierName varchar(50)
)
AS
BEGIN
INSERT
INTO
LMS_ALL_BOOKS
(BOOK_CODE,BOOK_AVAILABILITY,SUPPLIER_ID)
VALUES
(@bookCode,@availability,(SELECT SUPPLIER_ID FROM LMS_SUPPLIER_DETAILS WHERE SUPPLIER_NAME=@supplierName))
END

DROP PROC spAddBookCopies

--Admin

CREATE PROCEDURE getAdminPwd (@adminId int)
AS
BEGIN
SELECT ADMIN_PASSWORD FROM ADMIN_DETAILS WHERE ADMIN_ID=@adminId
END

exec getAdminPwd 100000