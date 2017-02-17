using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Timetable.Helpers;
using Sirius.Timetable.Models;
using Sirius.Timetable.Services;
using Xamarin.Forms;

namespace Sirius.Timetable.ViewModels
{
	public class TimetableViewModel : ObservableObject
	{
		public TimetableViewModel(DateTime date, string team)
		{
			RefreshCommand = new Command(async () => await RefreshTimetable(true));
			_date = date;
			_team = team;
			RefreshCommand.Execute(null);

			Header = new TimetableHeader
			{
				Team = Team,
				Date = _date.ToString("D"),
				IsLoaded = true
			};

		}
		public TimetableHeader Header
		{
			get { return _header; }
			set { SetProperty(ref _header, value); }
		}

		private TimetableHeader _header;
		private async Task RefreshTimetable(bool hard)
		{
			if (hard)
				await TimetableService.RefreshTimetables(_date);

			var dateKey = _date.ToString("dd.MM.yyyy").Replace(".", "");
			var timetable = TimetableService.Timetables[dateKey];
			var currentTimetable = timetable.Teams[TimetableService.KeywordDictionary[_team]];
			var collection = currentTimetable.Select(activity => new TimetableItem(activity));
			Timetable = new ObservableCollection<TimetableItem>(collection);

			IsBusy = false;
		}
		public Command RefreshCommand { get; set; }
		public bool IsBusy
		{
			get { return _isBusy; }
			set { SetProperty(ref _isBusy, value); }
		}
		public ObservableCollection<TimetableItem> Timetable
		{
			get { return _timetable; }
			set { SetProperty(ref _timetable, value); }
		}
		public string Team => TimetableService.KeywordDictionary[_team];
		private ObservableCollection<TimetableItem> _timetable;
		private bool _isBusy;
		private DateTime _date;
		private readonly string _team;
	}
}