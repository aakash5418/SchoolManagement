CREATE PROCEDURE sp_DeleteRollNo
@RollNo VARCHAR(20)
AS
BEGIN
DELETE
FROM 
	Student
WHERE
	RollNo=@RollNo
END