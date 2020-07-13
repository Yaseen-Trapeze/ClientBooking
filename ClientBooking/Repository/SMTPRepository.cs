using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public class SMTPRepository : IEmailLogRepository
    {
        private ClientBookingContext SMTPDB;

        public SMTPRepository()
        {
            SMTPDB = new ClientBookingContext() ?? throw new ArgumentNullException(nameof(SMTPDB));
        }

        public void EmailLog(string Email, DateTime Date, int BookingId)
        {
            EmailLog emailLog = new EmailLog()
            {
                Email = "This email is Sent By SMTP",
                Date = DateTime.Today,
                BookingId = BookingId
            };
            SMTPDB.EmailLog.Add(emailLog);
            SMTPDB.SaveChanges();
        }
    }
}
