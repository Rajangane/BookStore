CREATE TABLE Cart
(
	CartID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL
	FOREIGN KEY (UserId) REFERENCES RegUser(UserId),
	BookId INT NOT NULL
	FOREIGN KEY (BookId) REFERENCES Books(BookId),	
	OrderQuantity INT default 1
);

select * from Cart

-----------------------Add book to cart--------------------------
alter PROCEDURE sp_AddingCart(
	@UserId INT,
	@BookId INT,
	@OrderQuantity INT)
AS
BEGIN
	IF (EXISTS(SELECT * FROM Books WHERE BookId=@BookId))		
	begin
		INSERT INTO Cart( UserId,BookId,OrderQuantity)
		VALUES (@UserId,@BookId,@OrderQuantity)
	end
	else
	begin 
		select 2
	end
END

Exec sp_AddingCart 2,2,5
Exec sp_AddingCart 3,2

select * from Cart
----------------------Update Quantity in cart details-------------------------
CREATE PROC sp_UpdateQuantity
	@CartID INT,
	@OrderQuantity INT
AS
BEGIN
	IF (EXISTS(SELECT * FROM Cart WHERE CartID = @CartID))
	BEGIN
			UPDATE Cart
			SET
				OrderQuantity = @OrderQuantity
			WHERE
				CartID = @CartID;
		END
		ELSE
		BEGIN
			Select 1;
		END
END

-------------------get cart details---------------
CREATE PROCEDURE sp_GetCartDetails
	@UserId INT
AS
BEGIN
	SELECT
		Cart.CartID,
		Cart.UserId,
		Cart.BookId,
		Cart.OrderQuantity,	
		Books.BookName,
		Books.AuthorName,
		Books.DiscountPrice,
		Books.OriginalPrice  
	FROM Cart
	Inner JOIN Books ON Cart.BookId = Books.BookId
	WHERE Cart.UserId = @UserId
END

---------------------------------Delete cart-----------------------------
CREATE PROCEDURE sp_DeleteCartDetails
	@CartID INT
AS
BEGIN
	IF EXISTS(SELECT * FROM Cart WHERE CartID = @CartID)
	BEGIN
		DELETE FROM Cart WHERE CartID = @CartID
	END
	ELSE
	BEGIN
		select 1
	END
END

select * from RegUser
select * from Books
select * from Cart