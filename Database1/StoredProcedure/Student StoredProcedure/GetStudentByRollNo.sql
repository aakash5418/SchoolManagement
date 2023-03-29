CREATE PROCEDURE sp_GetStudentByRollNo
@RollNo varchar(20)
AS
BEGIN
SELECT
	*
FROM
	Student
WHERE
	RollNo = @RollNo
END