using System;
using SiriusTimetable.Common.Helpers;
using SiriusTimetable.Core.Services;
using SiriusTimetable.Core.Services.Abstractions;
using Xamarin.Forms;
using TimetablePage = SiriusTimetable.Common.Views.TimetablePage;

namespace SiriusTimetable.Common.Services
{
	public class DateTimeService : ObservableObject
	{
		private DateTime _date;

		public Command GetDateCommand { get; set; }
		public DateTime Date
		{
			get { return _date; }
			set { SetProperty(ref _date, value); }
		}

		public DateTimeService()
		{
			GetDateCommand = new Command(GetDateExecute);
			Date = DateTime.Today;
		}

		private void GetDateExecute()
		{
			ServiceLocator.GetService<IDatePickerDialogService>().ChoosenDate(ChoosenDate);
		}

		private void ChoosenDate(DateTime date)
		{
			Date = date;
			((TimetablePage)MasterDetailsServices.DetailPages[App.Detail.Timetable]).UpdateDate(Date);
		}
	}
}