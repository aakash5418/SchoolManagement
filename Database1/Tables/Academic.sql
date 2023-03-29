CREATE TABLE Academic(
AcademicId BIGINT IDENTITY(1,1)PRIMARY KEY,
AcademicStartYear INT NOT NULL,
AcademicEndYear INT NOT NULL ,
CreatedDate DATETIME NOT NULL,
ModifiedDate DATETIME)