CREATE PROCEDURE CRE_TICKET_PR
(
    @P_PRICE DECIMAL(10,2),
    @P_SCHEDULE TIME,
    @P_DATE DATETIME,
    @P_TYPE NVARCHAR(20),
    @P_MOVIE_ID INT
)
AS
BEGIN

    INSERT INTO tblTicket
    (
        Price,
        Schedule,
        DateTicket,
        Type,
        MovieId
    )
    VALUES
    (
        @P_PRICE,
        @P_SCHEDULE,
        @P_DATE,
        @P_TYPE,
        @P_MOVIE_ID
    );
END