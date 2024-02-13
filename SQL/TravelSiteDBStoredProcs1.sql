USE TravelSiteDB;
GO

-- spHotelGetDetails
CREATE PROCEDURE spHotelGetDetails
    @HotelID int
AS
BEGIN
    SELECT * FROM Hotel WHERE HotelID = @HotelID;
END;
GO

EXEC spHotelGetDetails 1
GO

-- spHotelGetRatings
CREATE PROCEDURE spHotelGetRatings
    @HotelID int
AS
BEGIN
    SELECT * FROM HotelRatings WHERE HotelID = @HotelID;
END;
GO

EXEC spHotelGetRatings 1
GO

-- spRoomGetAvailabilityByDate
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

EXEC spRoomGetAvailabilityByDate 1, '2024-02-20'
GO

-- spCartCreate
CREATE or alter PROCEDURE spCartCreate
    @UserID char(36) = null,
    @GuestID char(36) = null,
	@NewCartID char(36) output
AS
BEGIN
	Set @NewCartID = NEWID()
    INSERT INTO Cart (cartID, userID, guestID)
    VALUES (@NewCartID,@UserID, @GuestID);
	
	RETURN;
END;
GO

Declare @myNewCartID char(36)
EXEC spCartCreate null, 'Z9Y8X7W6-V5U4-T3S2-R1Q0-P9O8N7M6L5K4', @myNewCartID output
print @myNewCartID
GO

-- spCartAddRoomSingleDate
CREATE PROCEDURE spCartAddRoomSingleDate
    @CartID uniqueidentifier,
    @RoomAvailiabilityID int,
    @Price money,
    @Adults int = null,
    @Children int = null
AS
BEGIN
    INSERT INTO CartLines (CartID, RoomAvailiabilityID, price, adults, children)
    VALUES (@CartID, @RoomAvailiabilityID, @Price, @Adults, @Children);
END;
GO

EXEC spCartAddRoomSingleDate '416C3817-5D1E-45F2-96CC-08D44D4C1B74', 1, 150.00
GO