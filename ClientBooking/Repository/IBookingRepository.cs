using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
   public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetBookingByClientID(int ClientId, DateTime Date);
        int AddBooking(Booking booking);
        int DeleteBooking(int BookingId);
        void UpdateBooking(Booking booking);
    }
}
