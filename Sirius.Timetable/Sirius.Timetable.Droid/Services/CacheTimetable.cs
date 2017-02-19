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
	        var fileName = $"{_cacheLocation}/{dateToGet:yyyy-MM-dd}.json";
			if (File.Exists(fileName))
				return File.ReadAllText(fileName);
            return File.Exists(fileName) ? File.ReadAllText(fileName) : null;
        }

        public void Cache(string timetableJsonText, DateTime dateToCache)
        {
	        var fileName = $"{_cacheLocation}/{dateToCache:yyyy-MM-dd}.json";
            System.IO.File.WriteAllText(fileName, timetableJsonText);
        }
    }
}