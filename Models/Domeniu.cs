using LegitimatieStudentDigitala.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LegitimatieStudentDigitala.Models
{
    public enum Forma_Invatamant
    {
        I_Frecventa, I_Distanta, I_Frecventa_Redusa
    }

    public enum Studiu_Universitar
    {
        Licenta, Master, Doctorat
    }

    public class Domeniu : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "Numele trebuie sa aiba maxim {0} caractere.")]
        public string Nume { get; set; }

        public Forma_Invatamant Forma_Invatamant { get; set; }

        public Studiu_Universitar Studiu_Universitar { get; set; }

        [Required]
        [Range(0, 4)]
        public uint Numar_Ani { get; set; }

        public string Cod_Domeniu { get; set; }

        public string Cod_Facultate { get; set; }

    }
}
