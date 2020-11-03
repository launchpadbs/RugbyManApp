Create Procedure sp_InsertNewPlayer
	@Name varchar(50),
	@Surname varchar(50),
	@Height int,
	@Age int,
	@Position int,
	@UserId int
AS
Begin
	Set nocount on;
	insert into dbo.Players (Name, Surname, Height, Age, Position, UserId)
	values (@Name, @Surname, @Height, @Age, @Position, @UserId)

	Select SCOPE_IDENTITY()
End