using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public interface IEmailLogRepository
    {
        public void EmailLog(string Email, DateTime Date, int BookingId);
    }
}
