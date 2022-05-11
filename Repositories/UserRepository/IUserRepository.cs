using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;

namespace LegitimatieStudentDigitala.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByMail(string mail);
    }
}
