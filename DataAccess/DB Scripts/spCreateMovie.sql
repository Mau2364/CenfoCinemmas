CREATE PROCEDURE CRE_MOVIE_PR
(
    @P_TITLE NVARCHAR(100),
    @P_SYNOPSIS NVARCHAR(MAX),
    @P_GENDER NVARCHAR(50),
    @P_CLASIFICACION NVARCHAR(20),
    @P_IMAGE NVARCHAR(255),
    @P_STATUS NVARCHAR(2)
)
AS
BEGIN
    INSERT INTO tblMovie
    (
        Created,
        Title,
        Synopsis,
        Gender,
        Clasificacion,
        Image,
        Status
    )
    VALUES
    (
        GETDATE(),
        @P_TITLE,
        @P_SYNOPSIS,
        @P_GENDER,
        @P_CLASIFICACION,
        @P_IMAGE,
        @P_STATUS
    );
END