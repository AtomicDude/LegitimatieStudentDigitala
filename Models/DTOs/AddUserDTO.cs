using System.ComponentModel.DataAnnotations;

namespace LegitimatieStudentDigitala.Models.DTOs
{
    public class AdduserDTO
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Initiala_Tata { get; set; }
        public string CNP { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }
        public string Parola { get; set; }
        public string Forma_Finantare { get; set; }
        public uint An_Curent { get; set; }
        public string Facultate { get; set; }
        public string Studiu_Universitar { get; set; }
        public string Domeniu { get; set; }
        public string Path_Poza { get; set; }
    }
}
