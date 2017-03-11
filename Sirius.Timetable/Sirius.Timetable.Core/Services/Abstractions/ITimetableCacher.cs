using System;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface ITimetableCacher
	{
		string Get(DateTime dateToGet);
		void Cache(string timetableJsonText, DateTime dateToCache);
	}
}