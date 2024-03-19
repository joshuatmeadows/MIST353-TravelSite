USE [TravelSiteDB]
GO

create proc spAddHotel
@Address nvarchar(max),
           @Zipcode nvarchar(20),
           @City nvarchar(max),
           @State nvarchar(max),
           @Country nvarchar(max),
           @Name nvarchar(max),
           @Phone varchar(20) =null,
           @HotelType nvarchar(max)=null,
           @email nvarchar(max)=null,
           @latitude decimal(9,6)=null,
           @longitude decimal(9,6)=null
AS
BEGIN
INSERT INTO [dbo].[Hotel]
           ([Address]
           ,[Zipcode]
           ,[City]
           ,[State]
           ,[Country]
           ,[Name]
           ,[Phone]
           ,[HotelType]
           ,[email]
           ,[latitude]
           ,[longitude])
     VALUES
           (@Address
           ,@Zipcode
           ,@City
           ,@State
           ,@Country
           ,@Name
           ,@Phone
           ,@HotelType
           ,@email
           ,@latitude
           ,@longitude)
END
GO
