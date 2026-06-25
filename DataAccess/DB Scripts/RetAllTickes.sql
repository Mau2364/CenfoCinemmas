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
        t.MovieId,
        m.Title,
        m.Synopsis,
        m.Gender,
        m.Clasificacion,
        m.Image,
        m.Status
    FROM tblTicket t
    INNER JOIN tblMovie m
        ON t.MovieId = m.Id;
END
GO