using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ClientBooking.Models
{
    public partial class BookingAdress
    {

        public int BookingAdressId { get; set; }

        public int BookingId { get; set; }

        public int? ZipCode { get; set; }
        [Required(ErrorMessage = "You should provide a StreetNo")]
        public int StreetNo { get; set; }
        [Required(ErrorMessage = "You should provide a HouseNo")]
        public int HouseNo { get; set; }
        [Required(ErrorMessage = "You should provide a Town")]
        public string Town { get; set; }
        [Required(ErrorMessage = "You should provide a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "You should provide a State")]
        public string State { get; set; }
        [Required(ErrorMessage = "You should provide a AdressType")]
        public string AdressType { get; set; }

        // public virtual Booking Booking { get; set; }
    }
}
