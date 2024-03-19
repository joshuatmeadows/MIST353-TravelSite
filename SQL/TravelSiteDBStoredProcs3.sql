USE [TravelSiteDB]
GO
/****** Object:  StoredProcedure [dbo].[spRoomGetAvailabilityByDateRange]    Script Date: 3/19/2024 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Test left as exercise
*/

-- 12
create or ALTER   proc [dbo].[spRoomGetAvailabilityByDateRangeAndHotelID]
@startDate date,
@endDate date,
@hotelID int
AS
Begin
	SELECT r.*
	FROM (SELECT RoomID, count(AvDate) as numDays
			FROM RoomAvailiability
			WHERE AvDate between  @startDate
				and @endDate
			Group by RoomID
			HAVING count(AvDate) = DATEDIFF(day,@startDate,@endDate)+1) ra
	LEFT JOIN Room r
	on ra.RoomID=r.RoomID
	where r.HotelID = @hotelID
END
