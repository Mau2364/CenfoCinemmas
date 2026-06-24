CREATE PROCEDURE UPD_TICKET_PR
(
    @P_ID INT,
    @P_PRICE DECIMAL(10,2),
    @P_SCHEDULE TIME,
    @P_DATE DATETIME,
    @P_TYPE NVARCHAR(20),
    @P_MOVIE_ID INT
)
AS
BEGIN
    UPDATE tblTicket
    SET
        Price = @P_PRICE,
        Schedule = @P_SCHEDULE,
        DateTicket = @P_DATE,
        Type = @P_TYPE,
        MovieId = @P_MOVIE_ID
    WHERE Id = @P_ID;
END