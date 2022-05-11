using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LegitimatieStudentDigitala.Repositories.UserRepository;
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
        private IJWTUtils jwtUtils;

        public UserController(IUserRepository userR, IJWTUtils jwtUti)
        {
            userRepository = userR;
            jwtUtils = jwtUti;
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

        [HttpPost("add")]
        public IActionResult Add_user(AdduserDTO dto)
        {
            var user = userRepository.GetByMail(dto.Mail);
            if (user != null)
                return BadRequest(new { Message = "userul exista!" });



            var new_user = new User
            {
                Nume = dto.Nume,
                Prenume = dto.Prenume,
                Mail = dto.Mail,
                Parola = BCryptNet.HashPassword(dto.Parola),
                Forma_Finantare = Enum.Parse<Forma_Finantare>(dto.Forma_Finantare),
                An_Curent = dto.An_Curent
            };

            userRepository.Create(new_user);
            var result = userRepository.Save();

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
        [Authorization(role.Admin)]
        public IActionResult Update_User(UpdateUserDTO dto)
        {
            var user = userRepository.GetByMail(dto.Mail);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
