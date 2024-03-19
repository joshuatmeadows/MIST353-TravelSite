USE [TravelSiteDB]
GO



CREATE TABLE [dbo].[Photo](
	[HotelPhotoID] [int] primary key identity,
	[HotelID] [int] not null references Hotel(HotelID),
	[Photo] [varbinary](max) NULL,
	[IsPrimary] [bit] NULL,

)
GO


