using System;

namespace Sirius.Timetable.Core.Services
{
    public interface ICacheTimetable
    {
        string Get(DateTime dateToGet);
        void Cache(string timetableJsonText, DateTime dateToCache);
        
    }
}
