using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LegitimatieStudentDigitala.Models.Base;

namespace LegitimatieStudentDigitala.Models
{
    public enum Forma_Finantare
    {
        Buget, Taxa_Platita, Taxa_Neplatita
    }

    public enum Stare_Inmatriculare
    {
        Inmatriculat, Exmatriculat
    }

    public enum role
    {
        Student, Admin
    }

    public class User : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 1)]
        public string Nume { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 1)]
        public string Prenume { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Required]
        public Forma_Finantare Forma_Finantare { get; set; }

        [Required]
        public Stare_Inmatriculare Stare_Inmatriculare { get; set; }

        [Range(0, 4)]
        public uint An_Curent { get; set; }

        public string Cod_Legitimatie { get; set; }

        public string Path_Poza { get; set; }

        public role Rol { get; } = role.Student;

    }
}
