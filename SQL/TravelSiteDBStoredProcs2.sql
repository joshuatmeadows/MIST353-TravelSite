Use TravelSiteDB
GO

-- 6
Create proc spCartViewByCartID
@CartID char(36) -- use char(36) when creating parameter to fetch a uniqueidentifier
AS
SELECT *
From CartLines -- note we want CartLines instead of cart since these are the items in the cart
WHERE CartID = @CartID
GO
/*
EXEC spCartViewByCartID 'DF215E10-8BD4-4401-B2DC-99BB03135F2F'
GO
*/
-- 7
Create proc spCartAddRoomDateRange
@RoomID int,
@startDate date,
@endDate date,
@CartId char(36)
AS
Begin -- We can use begin and end to stay organized
	Insert Into CartLines(Price, RoomAvailiabilityID, CartId)
	SELECT Price, RoomAvailiabilityID, @CartId as CartID
	from RoomAvailiability
	Where RoomID = @RoomID
	and AvDate between  @StartDate
	and @EndDate
END

/*
EXEC spCartAddRoomDateRange 1, '20240220', '20240222', 'DF215E10-8BD4-4401-B2DC-99BB03135F2F'
GO
*/

-- 8
Create proc spHotelAdd
	@HotelID int, -- Don't type all these by hand. Be clever with SSMS scripting, find and replace, and chatGPT
	@Address nvarchar(max) ,
	@Zipcode nvarchar(20) ,
	@City nvarchar(max) ,
	@State nvarchar(max) ,
	@Country nvarchar(max) ,
	@Name nvarchar(max) ,
	@Phone varchar(20) = null , -- nullable fields get default of 'null' and are put at the end for convience
	@HotelType nvarchar(max) = null,
	@email nvarchar(max) = null,
	@latitude decimal(9, 6) = null,
	@longitude decimal(9, 6) = null
AS
BEGIN
INSERT INTO Hotel([HotelID]
      ,[Address]
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
Values(@HotelID
      ,@Address
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

/*
Test left as exercise
*/

-- 9
CREATE PROC spRoomAddToHotel
@HotelID int, @NumBeds int, @RoomType nchar(10) = null, @numberNum int = null, @floor int =null
AS
BEGIN
Insert into Room(HotelID, NumBeds, RoomType, numberNum, [floor])
Values(@HotelID, @NumBeds, @RoomType, @numberNum, @floor)
END
Go

/*
exec spRoomAddToHotel 1, 2
GO
*/

-- 10
CREATE proc spRoomAvailabilityAdd
	@RoomID int,
	@AvDate date,
	@Price money
AS
Begin
	INSERT INTO [dbo].[RoomAvailiability]
			   ([RoomID]
			   ,[AvDate] -- SQL is unhinged. It doesn't care at all where we put things like commas
			   ,[Price])
		 VALUES
			   (@RoomID
			   ,@AvDate
			   ,@Price)
END
GO

/*
Test left as exercise
*/

-- 11
Create proc spHotelAddReview
	@HotelID int
	,@rating int
	,@userID char(36) = null
	,@comments nvarchar(max) = null
AS
BEGIN
	INSERT INTO [dbo].[HotelRatings]
			   ([HotelID]
			   ,[rating]
			   ,[userID]
			   ,[comments])
		 VALUES
			   (@HotelID
			   ,@rating
			   ,@userID
			   ,@comments)
END
GO

/*
Test left as exercise
*/

-- 12
Create or alter proc spRoomGetAvailabilityByDateRange
@startDate date,
@endDate date
AS
Begin
	SELECT *
	FROM (SELECT RoomID, count(AvDate) as numDays
			FROM RoomAvailiability
			WHERE AvDate between  @startDate
				and @endDate
			Group by RoomID
			HAVING count(AvDate) = DATEDIFF(day,@startDate,@endDate)+1) ra
	LEFT JOIN Room r
	on ra.RoomID=r.RoomID
END
GO

/*
EXEC spRoomGetAvailabilityByDateRange '20240220', '20240221'
GO
*/
