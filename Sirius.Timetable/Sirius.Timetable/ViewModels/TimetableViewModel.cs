using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Helpers;
using Sirius.Timetable.Models;
using Sirius.Timetable.Services;
using Xamarin.Forms;

namespace Sirius.Timetable.ViewModels
{
	public class TimetableViewModel : ObservableObject
	{

		public TimetableViewModel(DateTime date, string team, bool isUp)
		{
			RefreshCommand = new Command(async arg => await RefreshTimetable(arg as bool?));
			_date = date;
			_team = team;
			RefreshCommand.Execute(!isUp);
			var timer = ServiceLocator.GetService<ITimerService>();
			var cacher = ServiceLocator.GetService<ICacheLastSelectedTeam>();
			cacher.Cache(_team);
			timer.AddHandler(UpdateCurrentAction);
			Header = new TimetableHeader
			{
				Team = Team,
				Date = _date.ToString("D"),
				IsLoaded = true
			};
			UpdateCurrentAction();
		}

		private void UpdateCurrentAction()
		{
			var time = ServiceLocator.GetService<IDateTimeService>().GetCurrentTime();
			foreach (var item in Timetable)
			{
				var startTime = _date.AddHours(item.Parent.Start.Value.Hour).AddMinutes(item.Parent.Start.Value.Minute);
				var endTime = _date.AddHours(item.Parent.End.Value.Hour).AddMinutes(item.Parent.End.Value.Minute);
				if (startTime <= time && time <= endTime)
					item.Color = Color.FromHex("#10ff007b");
				else if (endTime < time)
					item.Color = Color.FromHex("#88CBCBCB");
				else
					item.Color = Color.Transparent;
			}
		}

		public TimetableHeader Header
		{
			get { return _header; }
			set { SetProperty(ref _header, value); }
		}

		private TimetableHeader _header;

		private async Task RefreshTimetable(bool? hard)
		{
			if (hard == null || hard.Value)
			{
				try
				{
					await TimetableService.RefreshTimetables(_date);
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.DisplayAlert(
						"Произошла ошибка при загрузке данных",
						"Убедитесь, что вы подключены к сети Сириуса (Sirius_free) и повторите попытку",
						"Ок");
					IsBusy = false;
					return;
				}
			}

			var dateKey = _date.ToString("dd.MM.yyyy").Replace(".", "");
			var timetable = TimetableService.Timetables[dateKey];
			var currentTimetable = timetable.Teams[TimetableService.KeywordDictionary[_team]];
			var collection = currentTimetable.Select(activity => new TimetableItem(activity));
			Timetable = new ObservableCollection<TimetableItem>(collection);
			UpdateCurrentAction();
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