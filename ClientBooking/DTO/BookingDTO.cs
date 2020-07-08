using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public string Time { get; set; }
        public DateTime? Date { get; set; }
        public virtual ICollection<BookingAdressDTO> BookingAdress { get; set; }
    }
}
