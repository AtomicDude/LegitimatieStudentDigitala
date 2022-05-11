using LegitimatieStudentDigitala.Models;
using System;

namespace LegitimatieStudentDigitala.Utility
{
    public interface IJWTUtils
    {
        public string GenerateToken(User user);
        public Guid ValidateToken(string token);
    }
}
