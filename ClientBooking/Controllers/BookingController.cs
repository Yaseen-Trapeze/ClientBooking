using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClientBooking.DTO;
using ClientBooking.Models;
using ClientBooking.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingRepository BookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper)
        {
            BookingRepository = new BookingRepository();
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var booking = BookingRepository.GetAllBookings();
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
            var booking = BookingRepository.GetBookingByClientID(ClientId, Date);
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

                var BookingId = BookingRepository.AddBooking(booking);

                if (BookingId > 0)
                {
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
            result = BookingRepository.DeleteBooking(BookingId);
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
                    BookingRepository.UpdateBooking(booking);
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
