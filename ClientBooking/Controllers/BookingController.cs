using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ClientBooking.DTO;
using ClientBooking.Models;
using ClientBooking.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClientBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IBookingRepository _BookingRepository;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _Configuration;
        private readonly IEmailLogRepository _SendGridRepository;
        private readonly IEmailLogRepository _SMTPRepository;
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper, IBookingRepository context,IEmailLogRepository sendgridcontext,
            IEmailLogRepository smtpcontext, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _BookingRepository = context;
            _Configuration = configuration;
            _SendGridRepository = sendgridcontext;
            _SMTPRepository = smtpcontext;

             _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var booking = _BookingRepository.GetAllBookings();
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDTO = _mapper.Map<List<Booking>>(booking);
            return Ok(bookingDTO);
        }

        [HttpGet("{ClientID}")]
        public IActionResult GetBookingByClientID(int ClientId, DateTime Date = default(DateTime))
        {

            var booking = _BookingRepository.GetBookingByClientID(ClientId, Date);
            if (booking == null || booking.Count() == 0)
            {
                return NotFound();
            }
            var bookingDTO = _mapper.Map<List<Booking>>(booking);
            return Ok(bookingDTO);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            
            
            if (ModelState.IsValid)
            {

                var BookingId = _BookingRepository.AddBooking(booking);
                

                if (BookingId > 0)
                {
                    //configuration
                    
                    var emailLog = _Configuration.GetValue<string>("EmailLogsService:EmailServiceProvider");
                    if(emailLog == "SendGrid")
                    {
                        _SendGridRepository.EmailLog("This email is Sent By SendGrid", DateTime.Today, BookingId);

                    }
                    else if (emailLog == "SMTP")
                    {
                        _SMTPRepository.EmailLog("This email is Sent By SMTP", DateTime.Today, BookingId);
                    }
                    return Ok(BookingId);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int BookingId)
        {
            int result = 0;

            if (BookingId == 0)
            {
                return BadRequest();
            }
            result = _BookingRepository.DeleteBooking(BookingId);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _BookingRepository.UpdateBooking(booking);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
