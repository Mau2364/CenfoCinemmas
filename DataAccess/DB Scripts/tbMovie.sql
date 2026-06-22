CREATE TABLE tblMovie
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Created DATETIME NOT NULL,
    Updated DATETIME NULL,
    Title NVARCHAR(100),
    Synopsis NVARCHAR(MAX),
    Gender NVARCHAR(50),
    Clasificacion NVARCHAR(20),
    Image NVARCHAR(255),
    Status NVARCHAR(2)
);

