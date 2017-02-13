using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirius.Timetable.Core;

namespace Sirius.Timetable.Services
{
	public static class TimetableService
	{
		/// <summary>
		/// Словарь с расписанием по дате. key - дата в формате ddmmyyyy, value - расписание
		/// </summary>
		public static Dictionary<string, Core.Timetable> Timetables { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public static Dictionary<string, string> KeywordDictionary { get; set; }
		public static Dictionary<string, List<string>> TeamsLiterPossibleNumbers { get; set; }
		public static async Task RefreshTimetables()
		{
			Timetables = await TimetableParser.GetTimetables();
			KeywordDictionary = new Dictionary<string, string>();
			TeamsLiterPossibleNumbers = new Dictionary<String, List<String>>();
			foreach (var pair in Timetables["06022017"].Teams)
			{
				var shortTeamName = pair.Key.Split()[0];
				KeywordDictionary[shortTeamName] = pair.Key;
				var liter = shortTeamName[0].ToString();
				var number = shortTeamName.Substring(1);
				if (TeamsLiterPossibleNumbers.ContainsKey(liter))
					TeamsLiterPossibleNumbers[liter].Add(number);
				else TeamsLiterPossibleNumbers[liter] = new List<string> { number };
			}
			RefreshComplited?.Invoke(null, EventArgs.Empty);
		}
		public static event EventHandler RefreshComplited;
	}
}