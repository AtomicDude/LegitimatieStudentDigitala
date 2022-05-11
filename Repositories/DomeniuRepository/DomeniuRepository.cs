using LegitimatieStudentDigitala.Data;
using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;
using System.Linq;

namespace LegitimatieStudentDigitala.Repositories.DomeniuRepository
{
    public class DomeniuRepository : GenericRepository<Domeniu>, IDomeniuRepository
    {
        public DomeniuRepository(Context C) : base(C)
        {

        }

        public Domeniu GetByName(string name)
        {
            return _table.FirstOrDefault(x => x.Nume.Equals(name));
        }
    }
}
