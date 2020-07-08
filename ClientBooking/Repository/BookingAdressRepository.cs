using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public class BookingAdressRepository : IBookingAdressRepository
    {
        private ClientBookingContext BookingAdressDB;

        public BookingAdressRepository()
        {
            BookingAdressDB = new ClientBookingContext() ?? throw new ArgumentNullException(nameof(BookingAdressDB));
        }
        public int AddBookingAdress(BookingAdress BookingAdress)
        {
            throw new NotImplementedException();
        }

        public int DeleteBookingAdress(int? BookingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingAdress> GetAllBookingAdresses()
        {
            if (BookingAdressDB != null)
            {
                return BookingAdressDB.Set<BookingAdress>().ToList();
            }
            return null;
        }

        public IEnumerable<BookingAdress> GetBookingAdressByBookingID(int BookingId)
        {
            if (BookingAdressDB != null)
            {
                return BookingAdressDB.BookingAdress.Where(b => b.BookingId == BookingId).ToList();
            }
            return null;
        }

        public void UpdateBookingAdress(BookingAdress BookingAdress)
        {
            throw new NotImplementedException();
        }
    }
}
