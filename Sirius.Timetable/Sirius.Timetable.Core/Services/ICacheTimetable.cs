using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core.Services
{
    public interface ICacheTimetable
    {
        Task<string> Get(DateTime d);
        Task Cache(string Timetable);
        
    }
}
