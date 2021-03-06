using System.ComponentModel.DataAnnotations;

namespace LegitimatieStudentDigitala.Models.DTOs
{
    public class AddUserDTO
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
        public string Stare_Inmatriculare { get; set; }
        public uint An_Curent { get; set; }
        public string Serie_Legitimatie { get; set; }
        public string Cod_Legitimatie { get; set; }
        public string Path_Poza { get; set; }
        public string Cod_Domeniu { get; set; }
    }
}
