CREATE PROCEDURE UPD_MOVIE_PR
(
    @P_ID INT,
    @P_TITLE NVARCHAR(100),
    @P_SYNOPSIS NVARCHAR(MAX),
    @P_GENDER NVARCHAR(50),
    @P_CLASIFICACION NVARCHAR(20),
    @P_IMAGE NVARCHAR(255),
    @P_STATUS NVARCHAR(2)
)
AS
BEGIN
    UPDATE tblMovie
    SET 
        Title = @P_TITLE,
        Synopsis = @P_SYNOPSIS,
        Gender = @P_GENDER,
        Clasificacion = @P_CLASIFICACION,
        Image = @P_IMAGE,
        Status = @P_STATUS
    WHERE Id = @P_ID;
END