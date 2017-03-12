using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface ITimetableProvider
	{
		Dictionary<string, Timetable.Timetable> GetTimetables(DateTime date);
	}
}