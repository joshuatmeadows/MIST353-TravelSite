create database TravelSiteDB
GO

use TravelSiteDB
GO

CREATE TABLE [dbo].[Hotel](
	[HotelID] int NOT NULL identity primary key, -- identity auto increments the number, primary key specficies 
	[Address] [nvarchar](max) NOT NULL, -- nvarchar(max) will allow up to 2^31-1 characters
	[Zipcode] [nvarchar](20) Not NULL, -- Sql is not case sensitive
	[City] [nvarchar](max) not NULL,
	[State] [nvarchar](max) not NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [varchar](20) NULL,
	[HotelType] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	latitude DECIMAL(9,6) null, -- decimal(p,s): p = total number of digits, s = digits to the right of the decimal point. This would be ###.######
	longitude decimal(9,6)) -- default is null
GO

CREATE TABLE [dbo].[Room](
	[RoomID] [int] identity primary key, -- pk implies not null
	[HotelID] int NOT NULL FOREIGN KEY REFERENCES Hotel(HotelID), -- fks can be done in line or after the fact
	[NumBeds] [int] NOT NULL,
	[RoomType] [nchar](10) NULL,
	[numberNum] [int] NULL,
	[floor] [int] NULL)
GO

CREATE TABLE [dbo].[RoomAvailiability](
	RoomAvailiabilityID int identity primary key,
	[RoomID] [int] NOT NULL,
	[AvDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID))
GO

Alter table RoomAvailiability
add constraint RoomDateUnique unique(RoomID,AvDate); -- uniqueness constraints usefull for alternate keys
GO

Create table HotelRatings(
	HotelRatingsID int  identity primary key,
	HotelID int foreign key references hotel(hotelid) not null,
	rating int not null,
	userID char(36) null,
	comments nvarchar(max) null)
GO

Create table Cart(
	CartID uniqueidentifier NOT NULL primary key -- uniqueidentifier is a 36 long char that is unique to the database
		DEFAULT newid(), -- autogenerates unique identifier
	userID char(36) null,
	guestID char(36) null)
GO

Create table CartLines(
	CartID uniqueidentifier references cart(cartid) not null,
	RoomAvailiabilityID int references RoomAvailiability(RoomAvailiabilityID) not null,
	price money not null,
	adults int,
	children int)
GO

Create table Reservation(
	ReservationID uniqueidentifier NOT NULL primary key 
		DEFAULT newid(),
	userID char(36) null,
	guestID char(36) null,
	notes nvarchar(max),
	subtotal money,
	tax money,
	fees money,
	total money)
GO

create table ReservationLines(
	ReservationID uniqueidentifier NOT NULL references Reservation(ReservationID),
	RoomID int references Room(RoomID) not null,
	[AvDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
	adults int,
	children int,
	notes nvarchar(max),
	ReservationStatus nvarchar(100)
GO