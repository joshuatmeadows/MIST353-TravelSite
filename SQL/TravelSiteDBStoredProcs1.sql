USE TravelSiteDB;
GO

-- 1 spHotelGetDetails
CREATE PROCEDURE spHotelGetDetails
    @HotelID int
AS
BEGIN
    SELECT * FROM Hotel WHERE HotelID = @HotelID;
END;
GO

/*
EXEC spHotelGetDetails 1
GO
*/

-- 2 spHotelGetRatings
CREATE PROCEDURE spHotelGetRatings
    @HotelID int
AS
BEGIN
    SELECT * FROM HotelRatings WHERE HotelID = @HotelID;
END;
GO

/*
EXEC spHotelGetRatings 1
GO
*/

-- 3 spRoomGetAvailabilityByDate
CREATE PROCEDURE spRoomGetAvailabilityByDate
    @HotelID int,
    @AvDate date
AS
BEGIN
    SELECT r.*, ra.AvDate, ra.Price
    FROM Room r
    JOIN RoomAvailiability ra ON r.RoomID = ra.RoomID
    WHERE r.HotelID = @HotelID AND ra.AvDate = @AvDate;
END;
GO

/*
EXEC spRoomGetAvailabilityByDate 1, '2024-02-20'
GO
*/

-- 4 spCartCreate
CREATE or alter PROCEDURE spCartCreate
    @NewCartIDOut char(36) output,
	@UserID char(36) = null,
    @GuestID char(36) = null,
	@NewCartID char(36) = null

AS
BEGIN
	Set @NewCartIDOut = isnull(@NewCartID,NEWID()) -- is null replaces values if null (otherwise keeps original)
    INSERT INTO Cart (cartID, userID, guestID)
    VALUES (@NewCartIDOut,@UserID, @GuestID);
	RETURN;
END;
GO

/*
Declare @myNewCartID char(36)
EXEC spCartCreate @myNewCartID output, Null, 'Z9Y8X7W6-V5U4-T3S2-R1Q0-P9O8N7M6L5K4'
print @myNewCartID
GO
*/

-- 5 spCartAddRoomSingleDate
CREATE or ALTER PROCEDURE spCartAddRoomSingleDate
    @CartID uniqueidentifier,
    @RoomAvailiabilityID int,
    @Price money = null,
    @Adults int = null,
    @Children int = null
AS
BEGIN
	if(@Price is null) -- ifs work like you think they would
	Begin -- begin and end are just the sql version of {}
		Declare @myPrice money -- creates a parameter (basically a variable)
		select @myPrice=price from RoomAvailiability where RoomAvailiabilityID=@RoomAvailiabilityID -- can set parameters using queries
    END
	INSERT INTO CartLines (CartID, RoomAvailiabilityID, price, adults, children)
    VALUES (@CartID, @RoomAvailiabilityID, isnull(@Price,@myPrice), @Adults, @Children);
END;
GO

/*
EXEC spCartAddRoomSingleDate '416C3817-5D1E-45F2-96CC-08D44D4C1B74', 1, 150.00
GO
*/