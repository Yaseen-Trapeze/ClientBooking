using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public class EmailLogRepository : IEmailLogRepository
    {
        private ClientBookingContext EmailLogDB;

        public EmailLogRepository()
        {
            EmailLogDB = new ClientBookingContext() ?? throw new ArgumentNullException(nameof(EmailLogDB));
        }

        public void EmailLog(string Email, DateTime Date, int BookingId)
        {
            EmailLog emailLog = new EmailLog()
            {
                Email = Email,
                Date = DateTime.Today,
                BookingId = BookingId
            };
            EmailLogDB.EmailLog.Add(emailLog);
            EmailLogDB.SaveChanges();
        }
    }
}
