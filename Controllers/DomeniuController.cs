using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LegitimatieStudentDigitala.Repositories.DomeniuRepository;
using LegitimatieStudentDigitala.Repositories.UserRepository;
using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Models.DTOs;
using System;
using System.Collections.Generic;
using LegitimatieStudentDigitala.Repositories.FacultateRepository;

namespace LegitimatieStudentDigitala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomeniuController : ControllerBase
    {
        private IDomeniuRepository domeniuRepository;
        private IUserRepository userRepository;
        private IFacultateRepository facultateRepository;

        public DomeniuController(IDomeniuRepository domeniuRepository, IUserRepository userRepository, IFacultateRepository facultateRepository)
        {
            this.domeniuRepository = domeniuRepository;
            this.userRepository = userRepository;
            this.facultateRepository = facultateRepository;
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
            if (domeniu != null)
                return BadRequest();

            var cod_fac = facultateRepository.GetByCod(dto.Cod_Facultate);
            if (cod_fac == null)
            {
                return BadRequest();
            }

            var new_domeniu = new Domeniu
            {
                Nume = dto.Nume,
                Numar_Ani = dto.Numar_Ani,
                Forma_Invatamant = Enum.Parse<Forma_Invatamant>(dto.Forma_Invatamant),
                Studiu_Universitar = Enum.Parse<Studiu_Universitar>(dto.Studiu_Universitar),
                Cod_Domeniu = dto.Cod_Domeniu,
                Cod_Facultate = dto.Cod_Facultate,
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

        [HttpPut("update")]
        public IActionResult Update(UpdateDomeniuDTO dto)
        {
            var domeniu = domeniuRepository.GetByName(dto.Nume);
            if (domeniu== null)
            {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(dto.New_Nume))
            {
                domeniu.Nume = dto.New_Nume;
            }

            if (!string.IsNullOrEmpty(dto.Forma_Invatamant))
            {
                domeniu.Forma_Invatamant = Enum.Parse<Forma_Invatamant>(dto.Forma_Invatamant);
            }

            if (dto.Numar_Ani != 0)
            {
                domeniu.Numar_Ani = dto.Numar_Ani;
            }

            if (!string.IsNullOrEmpty(dto.Studiu_Universitar))
            {
                domeniu.Studiu_Universitar = Enum.Parse<Studiu_Universitar>(dto.Studiu_Universitar);
            }

            if (!string.IsNullOrEmpty(dto.Cod_Domeniu))
            {
                domeniu.Cod_Domeniu = dto.Cod_Domeniu;
            }

            if (!string.IsNullOrEmpty(dto.Cod_Facultate))
            {
                domeniu.Cod_Facultate = dto.Cod_Facultate;
            }

            domeniuRepository.Update(domeniu);
            var result = domeniuRepository.Save();

            if (result) { return Ok(result); } else { return BadRequest(); }
            
        }
        
    }
}
