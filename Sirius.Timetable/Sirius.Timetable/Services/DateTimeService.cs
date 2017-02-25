using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Helpers;
using Sirius.Timetable.ViewModels;
using Sirius.Timetable.Views;
using Xamarin.Forms;

namespace Sirius.Timetable.Services
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
			ServiceLocator.GetService<IDatePickerDialogService>().ChosenDate(ChoosenDate);
		}

		private void ChoosenDate(DateTime date)
		{
			Date = date;
			((TimetablePage)MasterDetailsServices.DetailPages[App.Detail.Timetable]).UpdateDate(Date);
		}
	}
}