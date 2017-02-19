using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sirius.Timetable.Core
{
	public static class TimetableParser
	{
		public static async Task<Dictionary<string, Timetable>> GetTimetables(DateTime d)
		{
			var jsonText = await new TimetableDownloader().GetJsonText(d);
			return String.IsNullOrEmpty(jsonText) ? null : JsonConvert.DeserializeObject<Dictionary<string, Timetable>>(jsonText);
		}
	}
}