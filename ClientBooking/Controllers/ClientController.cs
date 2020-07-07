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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClientBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientRepository ClientRepository;
        private readonly IMapper _mapper;

        public ClientController(IMapper mapper)
        {
            ClientRepository = new ClientRepository();
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var client = ClientRepository.GetAllClients();
            if (client == null)
            {
                return NotFound();
            }

            var clientDTO = _mapper.Map<List<Client>>(client);
            return Ok(clientDTO);
        }


        [HttpGet("{ClientID:int}")]
        public IActionResult GetClientByID(int ClientID)
        {
            var client = ClientRepository.GetClientByID(ClientID);

            if (client == null)
            {
                return NotFound();
            }
            var clientDTO = _mapper.Map<Client>(client);
            return Ok(clientDTO);
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {

            if (ModelState.IsValid) //chekc validation errors in model bidnig

            {
                var ClientID = ClientRepository.AddClient(client);
                if (ClientID > 0)
                {
                    return Ok(ClientID);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteClient(int ClientID)
        {
            int result = 0;

            if (ClientID == 0)
            {
                return BadRequest();
            }
            result = ClientRepository.DeleteClient(ClientID);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateClient(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClientRepository.UpdateClient(client);

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

