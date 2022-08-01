using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;
using System.Collections.Generic;

namespace LegitimatieStudentDigitala.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByMail(string mail);
        List<string> GetAllUsersFromDomeniu(string cod_domeniu);
    }
}
