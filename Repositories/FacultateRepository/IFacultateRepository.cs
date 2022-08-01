using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;

namespace LegitimatieStudentDigitala.Repositories.FacultateRepository
{
    public interface IFacultateRepository : IGenericRepository<Facultate>
    {
        Facultate GetByName(string name);
        Facultate GetByCod(string cod);
    }
}
