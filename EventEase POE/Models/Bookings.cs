
using System;
using System.Collections.Generic;

namespace EventEase.Models;
public class Bookings
{
    public int BookingId { get; set; }  // Primary key
    public int EventId { get; set; }    // Foreign key to Event
    public int VenueId { get; set; }    // Foreign key to Venue
    public DateTime BookingDate { get; set; }  // Booking Date

    // Navigation properties
    public Event Event { get; set; }
    public Venue Venue { get; set; }
}

