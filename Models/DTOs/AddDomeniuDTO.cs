using System.Collections.Generic;

namespace LegitimatieStudentDigitala.Models.DTOs
{
    public class AddDomeniuDTO
    {
        public string Nume { get; set; }

        public string Forma_Invatamant { get; set; }

        public uint Numar_Ani { get; set; }

        public string Studiu_Universitar { get; set; }

        public string Cod_Domeniu { get; set; }

        public string Cod_Facultate { get; set; }
    }
}
