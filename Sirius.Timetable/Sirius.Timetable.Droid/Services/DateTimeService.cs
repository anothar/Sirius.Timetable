using System;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
	public class DateTimeService : IDateTimeService
	{
		public DateTime GetCurrentTime()
		{
			return DateTime.Now;
		}
	}
}