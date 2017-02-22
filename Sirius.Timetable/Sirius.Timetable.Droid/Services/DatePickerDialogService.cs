using System;
using Android.App;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
	public class DatePickerDialogService : IDatePickerDialogService
	{
		private DateTime _date;
		private readonly FragmentManager _manager;

		public DatePickerDialogService(FragmentManager manager)
		{
			_manager = manager;
		}
		public void ChosenDate(Action<DateTime> action)
		{
			var frag = DatePickerFragment.NewInstance(delegate(DateTime time)
			{
				_date = time;
				action?.Invoke(_date);
			});
			frag.Show(_manager, DatePickerFragment.TAG);
		}
	}
}