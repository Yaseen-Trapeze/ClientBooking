using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public class SendGridRepository : IEmailLogRepository
    {
        private ClientBookingContext SendGridDB;

        public SendGridRepository()
        {
            SendGridDB = new ClientBookingContext() ?? throw new ArgumentNullException(nameof(SendGridDB));
        }
        public void EmailLog(string Email,DateTime Date,int BookingId)
        {
            EmailLog emailLog = new EmailLog()
            {
                Email = "This email is Sent By SendGrid",
                Date = DateTime.Today,
                BookingId = BookingId
            };
            SendGridDB.EmailLog.Add(emailLog);
            SendGridDB.SaveChanges();
        }
    }
}
