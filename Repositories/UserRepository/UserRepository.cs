using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;
using LegitimatieStudentDigitala.Data;
using System.Linq;

namespace LegitimatieStudentDigitala.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context C) : base(C)
        {

        }

        public User GetByMail(string mail)
        {
            return _table.FirstOrDefault(x => x.Mail.Equals(mail));
        }
    }
}
