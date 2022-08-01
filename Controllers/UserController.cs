using Microsoft.AspNetCore.Mvc;
using LegitimatieStudentDigitala.Repositories.UserRepository;
using LegitimatieStudentDigitala.Repositories.DomeniuRepository;
using BCryptNet = BCrypt.Net.BCrypt;
using LegitimatieStudentDigitala.Utility;
using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Models.DTOs;
using System;

namespace LegitimatieStudentDigitala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private IDomeniuRepository domeniuRepository;
        private IJWTUtils jwtUtils;

        public UserController(IUserRepository userR, IJWTUtils jwtUti, IDomeniuRepository domeniuR)
        {
            userRepository = userR;
            jwtUtils = jwtUti;
            domeniuRepository = domeniuR;
        }

        [HttpGet("{mail}")]
        public IActionResult Get(string mail)
        {
            var adr_mail = userRepository.GetByMail(mail);
            if (adr_mail == null)
            {
                return BadRequest(new { message = "userul cu adresa de mail introdusa nu exista" });
            }
            return Ok(adr_mail);
        }

        [HttpGet("domeniu/{cod}")]
        public IActionResult GetFromDomeniu(string cod)
        {
            var result = userRepository.GetAllUsersFromDomeniu(cod);
            if (result.Count == 0)
            {
                return BadRequest(new { message = "Domeniul nu are niciun utilizator" });
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add_user(AddUserDTO dto)
        {
            var user = userRepository.GetByMail(dto.Mail);
            if (user != null)
                return BadRequest(new { Message = "userul exista!" });

            var result = domeniuRepository.GetByCod(dto.Cod_Domeniu);

            if (result != null)
                user.Cod_Domeniu = dto.Cod_Domeniu;
            else
                return BadRequest();

            var new_user = new User
            {
                Nume = dto.Nume,
                Prenume = dto.Prenume,
                Initiala_Tata = dto.Initiala_Tata,
                CNP = dto.CNP,
                Mail = dto.Mail,
                Parola = BCryptNet.HashPassword(dto.Parola),
                Forma_Finantare = Enum.Parse<Forma_Finantare>(dto.Forma_Finantare),
                Stare_Inmatriculare = Enum.Parse<Stare_Inmatriculare>(dto.Stare_Inmatriculare),
                An_Curent = dto.An_Curent,
                Serie_Legitimatie = dto.Serie_Legitimatie,
                Cod_Legitimatie = dto.Cod_Legitimatie,
                Path_Poza = dto.Path_Poza,
                Rol = Role.User,
                Cod_Domeniu = dto.Cod_Domeniu,
            };

            userRepository.Create(new_user);
            var resultsave = userRepository.Save();

            if (resultsave)
            { }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = userRepository.GetByMail(dto.Mail);
            if (user == null)
            {
                return BadRequest(new { message = "userul cu adresa de mail introdusa nu exista" });
            }

            var token = jwtUtils.GenerateToken(user);
            return Ok(new { Token = token });

        }

        [HttpPut("update")]
        [Authorization(Role.Admin)]
        public IActionResult Update_User(UpdateUserDTO dto)
        {
            var user = userRepository.GetByMail(dto.Mail);
            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(dto.Nume))
            {
                user.Nume = dto.Nume;
            }

            if (!string.IsNullOrEmpty(dto.Prenume))
            {
                user.Prenume = dto.Prenume;
            }

            if (!string.IsNullOrEmpty(dto.Initiala_Tata))
            {
                user.Initiala_Tata = dto.Initiala_Tata;
            }

            if (!string.IsNullOrEmpty(dto.CNP))
            {
                user.CNP = dto.CNP;
            }

            if (!string.IsNullOrEmpty(dto.New_Mail))
            {
                user.Mail = dto.New_Mail;
            }

            if (!string.IsNullOrEmpty(dto.Forma_Finantare))
            {
                user.Forma_Finantare = Enum.Parse<Forma_Finantare>(dto.Forma_Finantare);
            }

            if (!string.IsNullOrEmpty(dto.Stare_Inmatriculare))
            {
                user.Stare_Inmatriculare = Enum.Parse<Stare_Inmatriculare>(dto.Stare_Inmatriculare);
            }

            if (dto.An_Curent != 0)
            {
                user.An_Curent = dto.An_Curent;
            }

            if (!string.IsNullOrEmpty(dto.Serie_Legitimatie))
            {
                user.Serie_Legitimatie = dto.Serie_Legitimatie;
            }

            if (!string.IsNullOrEmpty(dto.Cod_Legitimatie))
            {
                user.Cod_Legitimatie = dto.Cod_Legitimatie;
            }

            if (!string.IsNullOrEmpty(dto.Path_Poza))
            {
                user.Path_Poza = dto.Path_Poza;
            }

            if (!string.IsNullOrEmpty(dto.Cod_Domeniu))
            {
                var result = domeniuRepository.GetByCod(dto.Cod_Domeniu);

                if (result != null)
                    user.Cod_Domeniu = dto.Cod_Domeniu;
                else
                    return BadRequest();
            }

            userRepository.Update(user);
            var resultsave = userRepository.Save();

            if (resultsave)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
