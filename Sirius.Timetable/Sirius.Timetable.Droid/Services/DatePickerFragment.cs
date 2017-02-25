using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Sirius.Timetable.Droid.Services
{
	public class DatePickerFragment : DialogFragment,
		DatePickerDialog.IOnDateSetListener
	{
		// TAG can be any string of your choice.
		public static string TAG { get; } = "X:" + typeof (DatePickerFragment).Name.ToUpper();

		// Initialize this value to prevent NullReferenceExceptions.
		Action<DateTime> _dateSelectedHandler = delegate { };

		public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
		{
			var frag = new DatePickerFragment {_dateSelectedHandler = onDateSelected};
			return frag;
		}

		public override Dialog OnCreateDialog(Bundle savedInstanceState)
		{
			var currently = DateTime.Now;
			var dialog = new DatePickerDialog(Activity,
				this,
				currently.Year,
				currently.Month -1,
				currently.Day);
			return dialog;
		}

		public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			// Note: monthOfYear is a value between 0 and 11, not 1 and 12!
			var selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
			_dateSelectedHandler(selectedDate);
		}
	}
}