using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Data;
using EventEase.Models;

namespace EventEase.Controllers
{
    public class BookingViewController : Controller
    {
        private readonly EventEaseDbContext _context;

        public BookingViewController(EventEaseDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            int? bookingId,
            string searchQuery,
            string sortOrder,
            DateTime? startDate,
            DateTime? endDate,
            int? venueId)
        {
            var bookingViews = from b in _context.BookingView select b;

            // Search by Booking ID
            if (bookingId.HasValue)
            {
                bookingViews = bookingViews.Where(b => b.BookingID == bookingId.Value);
            }
            // Search by Event Name
            else if (!string.IsNullOrEmpty(searchQuery))
            {
                bookingViews = bookingViews.Where(b => EF.Functions.Like(b.EventName, $"%{searchQuery}%"));
            }

            // Filter by Date Range
            if (startDate.HasValue && endDate.HasValue)
            {
                bookingViews = bookingViews.Where(b =>
                    b.BookingDate >= startDate.Value && b.BookingDate <= endDate.Value);
            }

            // Filter by Venue
            if (venueId.HasValue)
            {
                bookingViews = bookingViews.Where(b => b.VenueID == venueId.Value);
            }

            // Sorting logic
            switch (sortOrder)
            {
                case "event":
                    bookingViews = bookingViews.OrderBy(b => b.EventName);
                    break;
                case "date_desc":
                    bookingViews = bookingViews.OrderByDescending(b => b.BookingDate);
                    break;
                case "booking_asc":
                    bookingViews = bookingViews.OrderBy(b => b.BookingDate);
                    break;
                case "eventdate_asc":
                    bookingViews = bookingViews.OrderBy(b => b.EventDate);
                    break;
                case "eventdate_desc":
                    bookingViews = bookingViews.OrderByDescending(b => b.EventDate);
                    break;
                default:
                    bookingViews = bookingViews.OrderBy(b => b.BookingDate);
                    break;
            }

            // Populate venue dropdown
            ViewBag.Venues = _context.Venues
                .Select(v => new SelectListItem
                {
                    Value = v.VenueId.ToString(),
                    Text = v.VenueName
                }).ToList();

            return View(await bookingViews.ToListAsync());
        }
    }
}

