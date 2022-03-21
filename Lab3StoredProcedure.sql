CREATE PROCEDURE [dbo].[Lab3StoredProcedure]
@Username AS NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
SELECT Pass FROM ADMIN WHERE Username = @Username;
END