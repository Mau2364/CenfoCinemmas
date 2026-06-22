CREATE TABLE tblTicket
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Price DECIMAL(10,2) NOT NULL,
    Schedule TIME NOT NULL,
    DateTicket DATETIME NOT NULL,
    Type NVARCHAR(20) NOT NULL,
    MovieId INT NOT NULL,

    CONSTRAINT FK_Ticket_Movie
        FOREIGN KEY (MovieId)
        REFERENCES tblMovie(Id)
);
