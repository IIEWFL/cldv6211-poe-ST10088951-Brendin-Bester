using System;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Models
{
    [Keyless]
    public class BookingView
    {
        public int BookingID { get; set; }
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string EventName { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime EventDate { get; set; }
    }
}
