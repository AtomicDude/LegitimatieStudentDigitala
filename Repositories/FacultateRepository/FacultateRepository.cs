using LegitimatieStudentDigitala.Data;
using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;
using System.Linq;

namespace LegitimatieStudentDigitala.Repositories.FacultateRepository
{
    public class FacultateRepository : GenericRepository<Facultate>, IFacultateRepository
    {
        public FacultateRepository(Context C) : base(C)
        {

        }

        public Facultate GetByName(string name)
        {
            return _table.FirstOrDefault(x => x.Nume.Equals(name));
        }

        public Facultate GetByCod(string cod)
        {
            return _table.FirstOrDefault(x => x.Cod_Facultate.Equals(cod));
        }
    }
}
