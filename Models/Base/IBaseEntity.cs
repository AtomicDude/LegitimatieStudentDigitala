using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegitimatieStudentDigitala.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime? DataCreat { get; set; }

        DateTime? DataModificat { get; set; }
    }
}
