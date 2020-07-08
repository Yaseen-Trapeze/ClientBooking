using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientBooking.Models
{


    public partial class Client
    {
        public Client()
        {
            Booking = new HashSet<Booking>();
            ClientContact = new HashSet<ClientContact>();
        }


        public int ClientId { get; set; }
        [Required(ErrorMessage = "You should provide a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should provide a HomeAdress")]
        public string HomeAdress { get; set; }
        [Required(ErrorMessage = "You should provide a DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "You should provide a Email")]
        public string Email { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        [Required(ErrorMessage = "You should provide a ClientContact")]
        public virtual ICollection<ClientContact> ClientContact { get; set; }
    }
}
