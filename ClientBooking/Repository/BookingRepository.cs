using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClientBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private ClientBookingContext BookingDB;
        private int Count;
        public BookingRepository()
        {
            BookingDB = new ClientBookingContext() ?? throw new ArgumentNullException(nameof(BookingDB));
        }
        public int AddBooking(Booking booking)
        {

            Count = BookingDB.Booking.Where(b => b.ClientId == booking.ClientId && b.Date == booking.Date).Count();
            if (Count < 4)
            {
                BookingDB.Booking.Add(booking);
                BookingDB.SaveChanges();
                return booking.BookingId;
            }

            return 0;
        }

        public int DeleteBooking(int BookingId)
        {
            int result = 0;
            //Find the booking for specific Booking id
            var booking = BookingDB.Booking.FirstOrDefault(x => x.BookingId == BookingId);

            if (booking != null)
            {
                //Delete that booking
                BookingDB.Booking.Remove(booking);

                //Commit the transaction
                result = BookingDB.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Booking> GetAllBookings()
        {

            return BookingDB.Set<Booking>().Include(c => c.BookingAdress).ToList();
        }

        public IEnumerable<Booking> GetBookingByClientID(int ClientId, DateTime Date)
        {
            if (Date != null)
            {
                return BookingDB.Booking.Where(c => c.ClientId == ClientId && c.Date != default(DateTime))
                    .Include(c => c.BookingAdress).ToList();
            }
            else
            {
                return BookingDB.Booking.Where(c => c.ClientId == ClientId).ToList();
            }
        }

        public void UpdateBooking(Booking booking)
        {
            //Update that booking
            BookingDB.Booking.Update(booking);

            //Commit the transaction
            BookingDB.SaveChanges();

        }
    }
}
