using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core
{
    /// <summary>
    /// Расписание на один день для всех групп
    /// </summary>
	public class Timetable
	{
        /// <summary>
        /// Словарь расписаний для каждой команды
        /// </summary>
		public Dictionary<string, List<Activity>> Teams { get; set; }
	}
}