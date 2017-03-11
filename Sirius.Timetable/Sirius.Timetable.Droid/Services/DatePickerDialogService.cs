using System;
using Android.App;
using SiriusTimetable.Core.Services.Abstractions;

namespace SiriusTimetable.Droid.Services
{
	public class DatePickerDialogService : IDatePickerDialogService
	{
		private DateTime _date;
		private readonly FragmentManager _manager;

		public DatePickerDialogService(FragmentManager manager)
		{
			_manager = manager;
		}
		public void ChoosenDate(Action<DateTime> action)
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