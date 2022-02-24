create table Wishlist
(
	WishlistId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL
	FOREIGN KEY (UserId) REFERENCES RegUser(UserId),
	BookId INT NOT NULL
	FOREIGN KEY (BookId) REFERENCES Books(BookId)	
);
select * from Wishlist

-----------------------Add wishlist------------------------
create PROCEDURE sp_CreateWishlist
	@UserId INT,
	@BookId INT
AS
BEGIN 
	IF EXISTS(SELECT * FROM Wishlist WHERE BookId = @BookId AND UserId = @UserId)
		SELECT 1;
	ELSE
	BEGIN
		IF EXISTS(SELECT * FROM Books WHERE BookId = @BookId)
		BEGIN
			INSERT INTO Wishlist(UserId,BookId)
			VALUES ( @UserId,@BookId)
		END
		ELSE
			SELECT 2;
	END
END

------------------Remove wishlist-----------------
CREATE PROCEDURE sp_DeleteWishlist
	@WishlistId INT
AS
BEGIN
		DELETE FROM Wishlist WHERE WishlistId = @WishlistId
END

------------------get wishlist-----------
create PROCEDURE sp_ShowWishlistbyUserId
  @UserId int
AS
BEGIN
	   select 
		Books.BookId,Books.BookName,Books.AuthorName,Books.DiscountPrice,Books.OriginalPrice,Books.Image,Wishlist.WishlistId,Wishlist.UserId,Wishlist.BookId
		FROM Books
		inner join Wishlist
		on Wishlist.BookId=Books.BookId where Wishlist.UserId=@UserId
End
select * from RegUser
select * from Books
select * from Cart
select * from Wishlist
