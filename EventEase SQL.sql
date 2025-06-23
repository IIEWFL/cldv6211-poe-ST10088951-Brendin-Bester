USE EventEaseDB

CREATE TABLE Venue(
	VenueID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	VenueName VARCHAR(250) UNIQUE NOT NULL,
	Location VARCHAR(250) NOT NULL,
	Capacity INT NOT NULL,
	ImageURL VARCHAR (500)
);

CREATE TABLE Event(
	EventID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	EventName VARCHAR(250) UNIQUE NOT NULL,
	EventDate DATE NOT NULL,
	Description VARCHAR(500) NOT NULL,
	VenueID INT FOREIGN KEY REFERENCES Venue(VenueID) NOT NULL
);

CREATE TABLE Booking(
	BookingID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	EventID INT FOREIGN KEY REFERENCES Event(EventID) NOT NULL,
	VenueID INT FOREIGN KEY REFERENCES Venue(VenueID) NOT NULL,
	BookingDate DATE NOT NULL

);

-- Insert into Venue Table
INSERT INTO Venue (VenueName, Location, Capacity, ImageURL)
VALUES 
('Grand Hall', 'Pretoria', 250, 'https://img.tagvenue.com/upload/93/16/4547-grand-hall-room.jpg'),
('Skyline Arena', 'Cape Town', 120, 'https://c8.alamy.com/comp/2K8BD4E/first-direct-arena-leeds-uk-october-13-2022-an-aerial-view-of-the-first-direct-arena-in-the-arena-quarter-in-a-leeds-cityscape-skyline-2K8BD4E.jpg'),
('Flower View Pavilion', 'Midrand', 150, 'https://landezine-award.com/wp-content/uploads/2022/05/gallery-Aerial-view-of-Embrace-Pavilion.jpg');

-- Insert into Event Table
INSERT INTO Event (EventName, EventDate, Description, VenueID)
VALUES 
('Tech Conference', '2025-06-15', 'A conference about the latest in technology.', 4),
('Music Festival', '2025-07-20', 'A festival featuring top artists from around the Country.', 5),
('Art Expo', '2025-08-10', 'An exhibition showcasing Art created by small and new Artists.', 6);

-- Insert into Booking Table
INSERT INTO Booking (EventID, VenueID, BookingDate)
VALUES 
(5, 8, '2025-06-01'),
(6, 9, '2025-07-05'),
(7, 10, '2025-07-25');


SELECT * FROM Venue;
SELECT * FROM Event;
SELECT * FROM Booking;


Select Booking.BookingID, Venue.VenueID, Venue.VenueName, Event.EventName, Booking.BookingDate, Event.EventDate
From Booking
Join Venue On Booking.VenueID = Venue.VenueID
Join Event On Booking.EventID = Event.EventID;

GO

Create View BookingView As 
Select Booking.BookingID, Venue.VenueID, Venue.VenueName, Event.EventName, Booking.BookingDate, Event.EventDate
From Booking
Join Venue On Booking.VenueID = Venue.VenueID
Join Event On Booking.EventID = Event.EventID
;

GO 

Select * From BookingView
GO

CREATE OR ALTER VIEW BookingView AS
SELECT 
    Booking.BookingID,
    Venue.VenueID,
    Venue.VenueName,
    Event.EventID,
    Event.EventName,      
    Booking.BookingDate,
    Event.EventDate
FROM 
    Booking
JOIN 
    Venue ON Booking.VenueID = Venue.VenueID
JOIN 
    Event ON Booking.EventID = Event.EventID;
