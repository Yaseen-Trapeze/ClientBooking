using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.DTO
{
    public class BookingAdressDTO
    {
        public int BookingAdressId { get; set; }
        public int? ZipCode { get; set; }
        public int StreetNo { get; set; }
        public int HouseNo { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AdressType { get; set; }
    }
}
