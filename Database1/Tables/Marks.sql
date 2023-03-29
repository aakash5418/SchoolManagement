CREATE TABLE Marks(
MarksId BIGINT IDENTITY (1,1)PRIMARY KEY,
MarksObtained INT NOT NULL,
TotalMarksObtained INT,
AcademicStudentId BIGINT FOREIGN KEY REFERENCES AcademicStudent(AcademicStudentId),
ExamId BIGINT FOREIGN KEY REFERENCES Exams(ExamId),
SubjectId BIGINT FOREIGN KEY REFERENCES Subjects(SubjectId)
CONSTRAINT unique_IsMarks_const UNIQUE(AcademicStudentId,ExamId,SubjectId),
CreatedDate DATETIME not null,
ModifiedDate DATETIME)