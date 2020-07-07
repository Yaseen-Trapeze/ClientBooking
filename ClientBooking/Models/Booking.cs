using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ClientBooking.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingAdress = new HashSet<BookingAdress>();
        }

        public int BookingId { get; set; }

        public int ClientId { get; set; }
        [Required(ErrorMessage = "You should provide a Time")]
        public string Time { get; set; }
        [Required(ErrorMessage = "You should provide a Date")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "You should provide a BookingAdress")]
        public virtual ICollection<BookingAdress> BookingAdress { get; set; }

        //public virtual Client Client { get; set; }

    }
}
