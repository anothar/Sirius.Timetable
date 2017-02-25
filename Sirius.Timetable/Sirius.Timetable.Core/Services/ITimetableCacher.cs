using System;

namespace Sirius.Timetable.Core.Services
{
	public interface ITimetableCacher
	{
		string Get(DateTime dateToGet);
		void Cache(string timetableJsonText, DateTime dateToCache);
	}
}