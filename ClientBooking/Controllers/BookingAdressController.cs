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

namespace ClientBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAdressController : ControllerBase
    {
        private BookingAdressRepository BookingAdressRepository;
        private readonly IMapper _mapper;

        public BookingAdressController(IMapper mapper)
        {
            BookingAdressRepository = new BookingAdressRepository();
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAllBookingAdresses()
        {
            var BookingAdress = BookingAdressRepository.GetAllBookingAdresses();
            if (BookingAdress == null)
            {
                return NotFound();
            }
            var bookingAdressDTO = _mapper.Map<List<BookingAdress>>(BookingAdress);
            return Ok(bookingAdressDTO);
        }

        [HttpGet("{BookingId}")]
        public IActionResult GetBookingAdressByBookingID(int BookingId)
        {
            var BookingAdress = BookingAdressRepository.GetBookingAdressByBookingID(BookingId);
            if (BookingAdress == null)
            {
                return NotFound();
            }
            var bookingAdressDTO = _mapper.Map<List<BookingAdress>>(BookingAdress);
            return Ok(bookingAdressDTO);
        }
    }
}
