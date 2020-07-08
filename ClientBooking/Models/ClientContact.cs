using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientBooking.Models
{

    public partial class ClientContact
    {

        public int ClientContactId { get; set; }
        [Required(ErrorMessage = "You should provide a MobileNumber")]
        public string MobileNumber { get; set; }

        public int ClientId { get; set; }

        //public virtual Client Client { get; set; }
    }
}
