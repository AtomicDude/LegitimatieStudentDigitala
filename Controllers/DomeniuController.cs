using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LegitimatieStudentDigitala.Repositories.DomeniuRepository;
using LegitimatieStudentDigitala.Repositories.UserRepository;
using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Models.DTOs;
using System;
using System.Collections.Generic;

namespace LegitimatieStudentDigitala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomeniuController : ControllerBase
    {
        private IDomeniuRepository domeniuRepository;
        private IUserRepository userRepository;

        public DomeniuController(IDomeniuRepository domeniuRepository, IUserRepository userRepository)
        {
            this.domeniuRepository = domeniuRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("{Nume}")]
        public IActionResult Get(string Nume)
        {
            var domeniu = domeniuRepository.GetByName(Nume);
            if (domeniu == null)
                return NotFound();
            return Ok(domeniu);

        }

        [HttpPost("add")]
        public IActionResult Post(AddDomeniuDTO dto)
        {
            var domeniu = domeniuRepository.GetByName(dto.Nume);
            if (domeniu == null)
                return BadRequest();

            var new_domeniu = new Domeniu
            {
                Nume = dto.Nume,
                Numar_Ani = dto.Numar_Ani,
                Forma_Invatamant = Enum.Parse<Forma_Invatamant>(dto.Forma_Invatamant),
            };

            domeniuRepository.Create(new_domeniu);
            var result = domeniuRepository.Save();

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
