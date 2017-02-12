using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sirius.Timetable.Core
{
	public static class TimetableParser
	{
		public static async Task<Dictionary<string, Timetable>> GetTimetables()
		{
			var jsonText = await TimetableDownloader.GetJsonText();
			return JsonConvert.DeserializeObject<Dictionary<string, Timetable>>(jsonText);
		}
	}
}