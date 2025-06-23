using System;
using System.Collections.Generic;

namespace EventEase.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public string Description { get; set; } = null!;

    public int VenueId { get; set; }

    public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();

    public virtual Venue Venue { get; set; } = null!;
}
