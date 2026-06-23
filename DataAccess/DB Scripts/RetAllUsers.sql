CREATE PROCEDURE RET_ALL_USER_PR
AS
BEGIN

    SET NOCOUNT ON


    SELECT Id, Created, UserCode, Name, Email, Password, DateBirth, Status, PhoneNumber
    from tblUsers;
end 
GO
