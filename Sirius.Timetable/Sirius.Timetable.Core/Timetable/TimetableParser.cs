using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Core
{
	public static class TimetableParser
	{
		public static async Task<Dictionary<string, Timetable>> GetTimetables(DateTime d)
		{
			var jsonText = await ServiceLocator.GetService<ITimetableDownloader>().GetJsonText(d);
			return String.IsNullOrEmpty(jsonText) ? null : JsonConvert.DeserializeObject<Dictionary<string, Timetable>>(jsonText);
		}
	}
}