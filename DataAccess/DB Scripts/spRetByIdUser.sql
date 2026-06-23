
CREATE PROCEDURE RET_USER_BY_ID_PR
@P_ID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
     Id, Created, UserCode, Name, Email, Password, DateBirth, Status, PhoneNumber
    from tblUsers
    where Id = @P_ID;
end;