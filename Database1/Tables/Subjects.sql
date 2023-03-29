CREATE TABLE Subjects(
SubjectId BIGINT IDENTITY(1,1)PRIMARY KEY,
SubjectName VARCHAR(20)NOT NULL,
SubjectCode VARCHAR(10)NOT NULL,
GroupId BIGINT FOREIGN KEY REFERENCES Groups(GroupId),
CONSTRAINT unique_Subjectsname_const UNIQUE(GroupId,SubjectName),
CONSTRAINT unique_Subjectscode_const UNIQUE(GroupId,SubjectCode),
CreatedDate DATETIME not null,
ModifiedDate DATETIME)