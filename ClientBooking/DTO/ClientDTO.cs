using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.DTO
{
    public class ClientDTO
    {

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string HomeAdress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<BookingDTO> Booking { get; set; }
        public virtual IEnumerable<ClientContactDTO> ClientContact { get; set; }

    }
}
