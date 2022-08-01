using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;
using LegitimatieStudentDigitala.Data;
using System.Linq;
using System.Collections.Generic;

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

        public List<string> GetAllUsersFromDomeniu(string cod_domeniu)
        {
            var result = from x in _context.Useri
                         where x.Cod_Domeniu.Equals(cod_domeniu)
                         select x;

            var mail_list = new List<string>();

            foreach (var x in result)
            {
                mail_list.Add(x.Mail);
            }
            
            return mail_list;
        }
    }
}
