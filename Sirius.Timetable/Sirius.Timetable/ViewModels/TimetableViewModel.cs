using System;
using System.Collections.ObjectModel;
using System.Linq;
using SiriusTimetable.Common.Helpers;
using SiriusTimetable.Common.Models;
using SiriusTimetable.Common.Services;
using SiriusTimetable.Common.Views;
using SiriusTimetable.Core.Services;
using SiriusTimetable.Core.Services.Abstractions;
using Xamarin.Forms;

namespace SiriusTimetable.Common.ViewModels
{
	public class TimetableViewModel : ObservableObject
	{
		public TimetableViewModel()
		{
			Init();
			Date = DateTime.Today;
		}
		public TimetableViewModel(DateTime date, string team)
		{
			Init();
			Date = date;
			ShortTeam = team;
		}
		private void Init()
		{
			RefreshCommand = new Command(RefreshTimetable, CanCommandsBeExecuted);
			SelectTeamCommand = new Command(SelectTeamExecute, CanCommandsBeExecuted);
		}

		private void SelectTeamExecute()
		{
			IsBusy = true;
			SelectTeamCommand.ChangeCanExecute();

			TimetableService.RefreshTimetables(Date);
			var team = new TeamSelectPage().SelectTeamAsync().Result;
			ShortTeam = team;
			UpdateTeam();

			IsBusy = false;
			SelectTeamCommand.ChangeCanExecute();
		}

		private TimetableHeader _header;
		private bool _isBusy;
		private ObservableCollection<TimetableItem> _timetable;
		private readonly ITimerService _timer = ServiceLocator.GetService<ITimerService>();
		public Command RefreshCommand { get; set; }
		public Command SelectTeamCommand { get; set; }
		public string ShortTeam { get; set; }
		public TimetableHeader Header
		{
			get { return _header; }
			set { SetProperty(ref _header, value); }
		}
		public bool IsBusy
		{
			get { return _isBusy; }
			set { SetProperty(ref _isBusy, value); }
		}
		public DateTime Date { get; set; }
		public ObservableCollection<TimetableItem> Timetable
		{
			get { return _timetable; }
			set { SetProperty(ref _timetable, value); }
		}
		public string Team => TimetableService.KeywordDictionary[ShortTeam];

		private bool CanCommandsBeExecuted()
		{
			return !_isBusy;
		}

		private void UpdateCurrentAction()
		{
			var time = ServiceLocator.GetService<IDateTimeService>().GetCurrentTime();
			foreach (var item in Timetable)
			{
				var startTime = Date.AddHours(item.Parent.Start.Hour).AddMinutes(item.Parent.Start.Minute);
				var endTime = Date.AddHours(item.Parent.End.Hour).AddMinutes(item.Parent.End.Minute);
				if ((startTime <= time) && (time <= endTime))
					item.Color = Color.FromHex("#10ff007b");
				else if (endTime < time)
					item.Color = Color.FromHex("#88CBCBCB");
				else
					item.Color = Color.Transparent;
			}
		}

		private void RefreshTimetable()
		{
			RefreshCommand.ChangeCanExecute();
			try
			{
				TimetableService.RefreshTimetables(Date);
			}
			catch (Exception)
			{
				IsBusy = false;
				RefreshCommand.ChangeCanExecute();
				return;
			}

			var dateKey = Date.ToString("ddMMyyyy");
			var timetable = TimetableService.Timetables[dateKey];
			var currentTimetable = timetable.Teams[TimetableService.KeywordDictionary[ShortTeam]];
			var collection = currentTimetable.Select(activity => new TimetableItem(activity));
			Timetable = new ObservableCollection<TimetableItem>(collection);

			_timer.SetHandler(UpdateCurrentAction);

			UpdateCurrentAction();
			IsBusy = false;
			RefreshCommand.ChangeCanExecute();
		}

		private void UpdateTeam()
		{
			var dateKey = Date.ToString("ddMMyyyy");
			var timetable = TimetableService.Timetables[dateKey];
			var currentTimetable = timetable.Teams[TimetableService.KeywordDictionary[ShortTeam]];
			var collection = currentTimetable.Select(activity => new TimetableItem(activity));
			Timetable = new ObservableCollection<TimetableItem>(collection);
			UpdateCurrentAction();
		}
	}
}