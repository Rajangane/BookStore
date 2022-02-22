 
--creating database 
Create database BookStoreDB;

-- creating table
Create table RegUser
(
UserId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FullName varchar(50) NOT NULL,
Email varchar(50) NOT NULL,
PhoneNo varchar(50) NOT NULL,
Password varchar(50) NOT NULL
)
-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Login
(
	@Email varchar(100),
	@Password varchar(400)
)
AS
BEGIN
	SELECT Email, Password FROM RegUser 
	WHERE @Email=Email AND @Password=Password
END;
--------------------------------------------------------------------------------------------------------------
exec sp_Login 'pratiksharajangane7@gmail.com','1234';
--------------------------------------------------------------------------------------------------------------
-- creating store procedure for user
create procedure sp_AddUsers
(   
    @FullName VARCHAR(50),
    @Email VARCHAR(50),   
    @PhoneNo VARCHAR(50),    
	@Password VARCHAR(50) 
)   
as  
Begin    
    Insert into RegUser   
	Values (@FullName,@Email,@PhoneNo, @Password)    
End

-------------------------------------------------------------------------------------------------------------
exec sp_AddUsers 'Pratiksha Rajangane','pratiksharajangane7@gmail.com','123456789','1234';

-------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ForgetPassword
(
	@Email varchar(100)
)
AS
BEGIN
	SELECT UserId,Email FROM RegUser 
	WHERE @Email=Email 
END
--------------------------------------------------------------------------------------------------------------
exec SP_Forget 'pratiksharajangane7@gmail.com';
--------------------------------------------------------------------------------------------------------------
create procedure sp_ResetPassword
 (
    @Email varchar(30),
	@Password varchar(40)
)
 as
 begin
	 Update RegUser 
	 SET Password=@Password
	 where Email=@Email
	 Select * from RegUser where Email=@Email; 
 End;
--------------------------------------------------------------------------------------------------------------
exec sp_ResetPassword 'pr@gmail.com','122'
--------------------------------------------------------------------------------------------------------------

select * from RegUser