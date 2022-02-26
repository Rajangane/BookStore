
---------------------Feedback table----------------------------
create table Feedback
(
         FeedbackId int not null identity (1,1) primary key,
		 UserId INT NOT NULL
		 FOREIGN KEY (UserId) REFERENCES Reguser(UserId),
	     BookId INT NULL
		 FOREIGN KEY (BookId) REFERENCES Books(BookId),
		 Comments Varchar(max),
		 Ratings int		 
);

-------------------------CreateFeedbacktSP---------------------------------
create procedure Sp_AddFeedback(
	@UserId INT,
	@BookId INT,
	@Comments Varchar(max),
	@Ratings int)		
As 
Declare @AverageRating int;
Begin
	IF (EXISTS(SELECT * FROM Feedback WHERE BookId = @BookId and UserId=@UserId))
		select 1; --already given feedback--
	Else
	Begin
		IF (EXISTS(SELECT * FROM Books WHERE BookId = @BookId))
		Begin
			Begin try
				Begin transaction
					Insert into Feedback (UserId,BookId,Comments,Ratings )
						values (@UserId,@BookId,@Comments,@Ratings);		
					select @AverageRating=AVG(Ratings) from Feedback where BookId = @BookId;
					Update Books set Rating=@AverageRating, Reviewer=Reviewer+1 where BookId = @BookId;
				Commit Transaction
			End Try
			Begin catch
				Rollback transaction
			End catch
		End
		Else
		Begin
			Select 2; 
		End
	End
End

-------------------------Get feedback---------------------------
create PROC sp_GetFeedbacks
	@BookId INT
AS
BEGIN
	select 
		Feedback.UserId,Feedback.Comments,Feedback.Ratings,RegUser.FullName
		FROM RegUser
		inner join Feedback
		on Feedback.UserId=RegUser.UserId
		where BookId=@BookId
END

select * from Feedback
select * from RegUser
select * from books