CREATE PROCEDURE sp_UpsertStudent
@StudentId BIGINT,
@RollNo VARCHAR(100),
@FirstName VARCHAR(100),
@Lastname VARCHAR(100),
@Gender VARCHAR(10),
@DateOfBirth DATETIME,
@DateOfAdmission DATETIME
AS
BEGIN
IF  EXISTS 
(SELECT
	* 
FROM
	Student 
WHERE 
	StudentId = @StudentId)
UPDATE Student
SET
	RollNo = @RollNo,
	FirstName = @FirstName,
	LastName =@Lastname,
	Gender = @Gender,
	DateOfBirth =@DateOfBirth,
	DateOfAdmission=@DateOfAdmission,
	DateOfDiscontinue =GETDATE(),
	ModifiedDate =GETDATE()
WHERE
	StudentId = @StudentId
ELSE
INSERT INTO Student
	(RollNo,
	FirstName,
	LastName,
	Gender,
	DateOfBirth,
	DateOfAdmission,
	CreatedDate)
VALUES
	(@RollNo,
	@FirstName,
	@Lastname,
	@Gender,
	@DateOfBirth,
	@DateOfAdmission,
	GETDATE())
END