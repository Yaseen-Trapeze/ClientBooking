using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Models
{
    public class EmailLog
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int BookingId { get; set; }

    }
}
