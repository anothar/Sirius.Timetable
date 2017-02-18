using System;
using System.IO;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
    public class CacheTimetable : ICacheTimetable
    {
        private readonly string _cacheLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public string Get(DateTime dateToGet)
        {
            var fileName = Path.Combine(_cacheLocation, dateToGet.ToString("yyyy-MM-dd") + ".json");
			return System.IO.File.Exists(fileName) ? System.IO.File.ReadAllText(fileName) : null;
        }
        
        public void Cache(string timetableJsonText, DateTime dateToCache)
        {
            var fileName = Path.Combine(_cacheLocation, dateToCache.ToString("yyyy-MM-dd") + ".json");
            System.IO.File.WriteAllText(fileName, timetableJsonText);
        }
    }
}