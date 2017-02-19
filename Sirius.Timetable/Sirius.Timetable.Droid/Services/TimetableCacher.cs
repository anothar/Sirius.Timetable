using System;
using System.IO;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
	public class TimetableCacher : ITimetableCacher
	{
		private readonly string _cacheLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		public string Get(DateTime dateToGet)
		{
			var fileName = $"{_cacheLocation}/{dateToGet:yyyy-MM-dd}.json";
			if (File.Exists(fileName) && ((DateTime.Now - File.GetLastWriteTime(fileName)).Hours < 6))
				return File.ReadAllText(fileName);
			return null;
		}

		public void Cache(string timetableJsonText, DateTime dateToCache)
		{
			var fileName = $"{_cacheLocation}/{dateToCache:yyyy-MM-dd}.json";
			File.WriteAllText(fileName, timetableJsonText);
		}
	}
}