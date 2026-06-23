
CREATE PROCEDURE RET_ALL_TICKET_PR
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        t.Id,
        t.Price,
        t.Schedule,
        t.DateTicket,
        t.Type,
        t.MovieId
    FROM tblTicket t;
END
