----------------------OrderTable-------------------
create table Orders
(
         OrdersId int not null identity (1,1) primary key,
		 UserId INT NOT NULL,
		 FOREIGN KEY (UserId) REFERENCES RegUser(UserId),
		 AddressId int
		 FOREIGN KEY (AddressId) REFERENCES Address(AddressId),
	     BookId INT NOT NULL
		 FOREIGN KEY (BookId) REFERENCES Books(BookId),
		 TotalPrice int,
		 BookQuantity int,
		 OrderDate Date
);

-----------------------add order-------------------------
create PROC sp_AddingOrders
	@UserId INT,
	@AddressId int,
	@BookId INT ,
	@BookQuantity int
AS
	Declare @TotPrice int
BEGIN
	Select @TotPrice=DiscountPrice from Books where BookId = @BookId;
	IF (EXISTS(SELECT * FROM Books WHERE BookId = @BookId))
	begin
		IF (EXISTS(SELECT * FROM RegUser WHERE UserId = @UserId))
		Begin
		Begin try
			Begin transaction			
				INSERT INTO Orders(UserId,AddressId,BookId,TotalPrice,BookQuantity,OrderDate)
				VALUES ( @UserId,@AddressId,@BookId,@BookQuantity*@TotPrice,@BookQuantity,GETDATE())
				Update Books set BookCount=BookCount-@BookQuantity
				Delete from Cart where BookId = @BookId and UserId = @UserId
			commit Transaction
		End try
		Begin catch
			Rollback transaction
		End catch
		end
		Else
		begin
			Select 1
		end
	end 
	Else
	begin
			Select 2
	end	
END

-------------------get orders-----------------------
create PROC sp_GetAllOrders
	@UserId INT
AS
BEGIN
	select 
		Books.BookId,Books.BookName,Books.AuthorName,Books.DiscountPrice,Books.OriginalPrice,Books.Image,Orders.OrdersId,Orders.OrderDate
		FROM Books
		inner join Orders
		on Orders.BookId=Books.BookId where Orders.UserId=@UserId
END
select * from books
select * from orders
