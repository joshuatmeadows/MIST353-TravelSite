USE TravelSiteDB;
GO

-- Inserting into Hotel
SET IDENTITY_INSERT Hotel ON;
INSERT INTO Hotel (HotelID, Address, Zipcode, City, State, Country, Name, Phone, HotelType, email, latitude, longitude)
VALUES
(1, '123 Main St', '00000', 'Example City', 'Example State', 'Example Country', 'Hotel 1', '123-456-7890', 'Luxury', 'contact@hotel1.com', 40.712776, -74.005974),
(2, '456 Second St', '11111', 'Another City', 'Another State', 'Another Country', 'Hotel 2', '098-765-4321', 'Budget', 'info@hotel2.com', 34.052235, -118.243683);
SET IDENTITY_INSERT Hotel OFF;
DBCC CHECKIDENT ('Hotel', RESEED, 2);
GO

-- Inserting into Room
SET IDENTITY_INSERT Room ON;
INSERT INTO Room (RoomID, HotelID, NumBeds, RoomType, numberNum, floor)
VALUES
(1, 1, 2, 'Double', 101, 1),
(2, 1, 1, 'Single', 102, 1),
(3, 2, 3, 'Triple', 201, 2);
SET IDENTITY_INSERT Room OFF;
DBCC CHECKIDENT ('Room', RESEED, 3);
GO

-- Inserting into RoomAvailability
SET IDENTITY_INSERT RoomAvailiability ON;
INSERT INTO RoomAvailiability (RoomAvailiabilityID, RoomID, AvDate, Price)
VALUES
(1, 1, '2024-02-20', 150.00),
(2, 2, '2024-02-20', 100.00),
(3, 3, '2024-02-21', 200.00);
SET IDENTITY_INSERT RoomAvailiability OFF;
DBCC CHECKIDENT ('RoomAvailiability', RESEED, 3);
GO

-- Inserting into HotelRatings
SET IDENTITY_INSERT HotelRatings ON;
INSERT INTO HotelRatings (HotelRatingsID, HotelID, rating, userID, comments)
VALUES
(1, 1, 5, 'A1B2C3D4-E5F6-G7H8-I9J0-K1L2M3N4O5P6', 'Excellent service and comfortable rooms.'),
(2, 2, 4, 'Z9Y8X7W6-V5U4-T3S2-R1Q0-P9O8N7M6L5K4', 'Great location, but the rooms were a bit small.');
SET IDENTITY_INSERT HotelRatings OFF;
DBCC CHECKIDENT ('HotelRatings', RESEED, 2);
GO

-- Inserting into Cart
INSERT INTO Cart (CartID, guestID)
VALUES
('DF215E10-8BD4-4401-B2DC-99BB03135F2E', 'Z9Y8X7W6-V5U4-T3S2-R1Q0-P9O8N7M6L5K4');

-- Inserting into CartLines
INSERT INTO CartLines (CartID, RoomAvailiabilityID, price, adults, children)
VALUES
('DF215E10-8BD4-4401-B2DC-99BB03135F2E6', 1, 150.00, 2, 1); 

-- Inserting into Reservation
INSERT INTO Reservation (ReservationID, guestID, notes, subtotal, tax, fees, total)
VALUES
('DF215E10-8BD4-4401-B2DC-99BB03135F2E7', 'Z9Y8X7W6-V5U4-T3S2-R1Q0-P9O8N7M6L5K4', 'Need early check-in', 300.00, 30.00, 20.00, 350.00);

-- Inserting into ReservationLines
INSERT INTO ReservationLines (ReservationID, RoomID, AvDate, Price, adults, children, notes, ReservationStatus)
VALUES
('DF215E10-8BD4-4401-B2DC-99BB03135F2E7', 1, '2024-02-20', 150.00, 2, 0, 'Room with a view', 'Confirmed');


