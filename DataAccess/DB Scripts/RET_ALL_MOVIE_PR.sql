CREATE PROCEDURE RET_ALL_MOVIE_PR
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        Created,
        Title,
        Synopsis,
        Gender,
        Clasificacion,
        Image,
        Status
    FROM tblMovie;
END