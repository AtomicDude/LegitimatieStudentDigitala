using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LegitimatieStudentDigitala.Models.Base;

namespace LegitimatieStudentDigitala.Models
{
    public class Facultate : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 5)]
        public string Nume { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 10)]
        public string Numar_Telefon { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 10)]
        public string Numar_FAX { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Parola trebuie sa aiba minim {2} caractere si maxim {0}.", MinimumLength = 10)]
        public string Adresa { get; set; }

        public string Cod_Facultate { get; set; }
    }
}
