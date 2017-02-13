using Sirius.Timetable.Core;

namespace Sirius.Timetable.Models
{
	public class TimetableItem
	{
		public TimetableItem(Activity activity)
		{
			if (activity.Start != null) Start = activity.Start.Value.ToString("t");
			if (activity.End != null) End = activity.End.Value.ToString("t");
			if (activity.BusTo != null) BusTo = activity.BusTo.Value.ToString("t");
			if (activity.BusFrom != null) BusFrom = activity.BusFrom.Value.ToString("t");
			Title = activity.Title;
			Place = activity.Place;
		}
		public string Start { get; set; }
		public string End { get; set; }
		public string BusTo { get; set; }
		public string BusFrom { get; set; }
		public string Title { get; set; }
		public string Place { get; set; }
	}
}