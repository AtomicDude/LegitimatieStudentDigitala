using System.Collections.Generic;

namespace LegitimatieStudentDigitala.Models.DTOs
{
    public class AddDomeniuDTO
    {
        public string Nume { get; set; }

        public virtual ICollection<User> Useri { get; set; }

        public string Forma_Invatamant { get; set; }

        public uint Numar_Ani { get; set; }
    }
}
