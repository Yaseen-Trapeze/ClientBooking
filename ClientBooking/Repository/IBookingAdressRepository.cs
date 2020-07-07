using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public interface IBookingAdressRepository
    {
        IEnumerable<BookingAdress> GetAllBookingAdresses();
        IEnumerable<BookingAdress> GetBookingAdressByBookingID(int BookingId);
        int AddBookingAdress(BookingAdress BookingAdress);
        int DeleteBookingAdress(int? BookingId);
        void UpdateBookingAdress(BookingAdress BookingAdress);
    }
}
