create table AddressType
(
	TypeId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Type varchar(20)
);
INSERT INTO AddressType (Type) VALUES ('Home')
INSERT INTO AddressType (Type) VALUES ('Work')
INSERT INTO AddressType (Type) VALUES ('Other')

---------------------Address table--------------------
create table Address
(
    AddressId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL
	FOREIGN KEY (UserId) REFERENCES Reguser(UserId),
	Address varchar(max) not null,
	City varchar(100),
	State varchar(100),
	TypeId int
	FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId)
);
---------------------Add address --------------------------

create procedure Sp_AddAddress(
		@UserId int,
        @Address varchar(600),
		@City varchar(50),
		@State varchar(50),
		@TypeId int	)		
As 
Begin
	IF (EXISTS(SELECT * FROM RegUser WHERE @UserId = @UserId))
	Begin
	Insert into Address (UserId,Address,City,State,TypeId )
		values (@UserId,@Address,@City,@State,@TypeId);
	End
	Else
	Begin
		Select 1
	End
End

Exec Sp_AddAddress 1,'RHS Society','Chikodi','Karanataka',1;

select * from Address

--------------------------Update address-------------------------
create PROCEDURE sp_UpdateAddress
(
@AddressId int,
@Address varchar(max),
@City varchar(100),
@State varchar(100),
@TypeId int	)

AS
BEGIN
       If (exists(Select * from Address where AddressId=@AddressId))
		begin
			UPDATE Address
			SET 
			Address= @Address, 
			City = @City,
			State=@State,
			TypeId=@TypeId 
				WHERE AddressId=@AddressID;
		 end
		 else
		 begin
		 select 1;
		 end
END 

Exec sp_UpdateAddress 1,'Buddha vihar','Chikodi','Karanataka',1

-----------------------Get all adresses--------------------------
create PROCEDURE sp_GetAllAddresses
AS
BEGIN
	 begin
	   SELECT * FROM Address ;
   	 end
End

Exec sp_GetAllAddresses
-----------Get adress by user id----------
create PROCEDURE sp_GetAddressbyUserid
  @UserId int
AS
BEGIN

     IF(EXISTS(SELECT * FROM Address WHERE UserId=@UserId))
	 begin
	   SELECT * FROM Address WHERE UserId=@UserId;
   	 end
	 else
	 begin
		select 1
	end
End

Exec sp_GetAddressbyUserid 1


select * from RegUser

select * from address

select * from addresstype