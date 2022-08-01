using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LegitimatieStudentDigitala.Repositories.FacultateRepository;
using LegitimatieStudentDigitala.Models.DTOs;
using LegitimatieStudentDigitala.Models;

namespace LegitimatieStudentDigitala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultateController : ControllerBase
    {
        private IFacultateRepository facultateRepository;

        public FacultateController(IFacultateRepository facultateR)
        {
            facultateRepository = facultateR;
        }

        [HttpGet("{Nume}")]
        public IActionResult Get(string Nume)
        {
            var facultate = facultateRepository.GetByName(Nume);
            if (facultate == null)
                return NotFound( new { message = "Facultatea introdusa nu exista"});
            return Ok(facultate);
        }

        [HttpPost("add")]
        public IActionResult Post(AddFacultateDTO dto)
        {
            var facultate = facultateRepository.GetByName(dto.Nume);
            if (facultate != null)
            {
                return BadRequest();
            }

            var new_facultate = new Facultate
            {
                Nume = dto.Nume,
                Numar_FAX = dto.Numar_FAX,
                Numar_Telefon = dto.Numar_Telefon,
                Mail = dto.Mail,
                Adresa = dto.Adresa,
                Cod_Facultate = dto.Cod_Facultate,
            };

            facultateRepository.Create(new_facultate);
            var result = facultateRepository.Save();

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
        public IActionResult Update(UpdateFacultateDTO dto)
        {
            var facultate = facultateRepository.GetByName(dto.Nume);
            if (facultate == null)
                return NotFound(new { message = "Facultatea introdusa nu exista" });

            if (!string.IsNullOrEmpty(dto.New_Nume))
            {
                facultate.Nume = dto.New_Nume;
            }

            if (!string.IsNullOrEmpty(dto.Numar_Telefon))
            {
                facultate.Numar_Telefon = dto.Numar_Telefon;
            }

            if (!string.IsNullOrEmpty(dto.Numar_Fax))
            {
                facultate.Numar_FAX = dto.Numar_Fax;
            }

            if (!string.IsNullOrEmpty(dto.Mail))
            {
                facultate.Mail = dto.Mail;
            }

            if (!string.IsNullOrEmpty(dto.Adresa))
            {
                facultate.Adresa = dto.Adresa;
            }

            if (!string.IsNullOrEmpty(dto.Cod_Facultate))
            {
                facultate.Cod_Facultate = dto.Cod_Facultate;
            }

            facultateRepository.Update(facultate);
            var result = facultateRepository.Save();

            if (result) { return Ok(result); } else { return BadRequest(); }
        }
    }
}
