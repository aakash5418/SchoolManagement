CREATE PROCEDURE sp_AddStudent
@RollNo VARCHAR(100),
@FirstName VARCHAR(100),
@Lastname VARCHAR(100),
@Gender	VARCHAR(10),
@DateOfBirth DATETIME,
@DateOfAdmission DATETIME
AS 
BEGIN
INSERT INTO Student
	(RollNo,
	FirstName,
	Lastname,
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