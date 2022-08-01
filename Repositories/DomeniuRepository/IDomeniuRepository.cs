using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Repositories.GenericRepository;

namespace LegitimatieStudentDigitala.Repositories.DomeniuRepository
{
    public interface IDomeniuRepository : IGenericRepository<Domeniu>
    {
        Domeniu GetByName(string name);
        Domeniu GetByCod(string cod);
    }
}
