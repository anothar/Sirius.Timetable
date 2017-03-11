using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using SiriusTimetable.Common.Helpers;
using SiriusTimetable.Common.Models;
using SiriusTimetable.Common.Services;
using SiriusTimetable.Core.Services;
using SiriusTimetable.Core.Services.Abstractions;
using Xamarin.Forms;
using LoadingView = SiriusTimetable.Common.Views.LoadingView;

namespace SiriusTimetable.Common.ViewModels
{
	public class TimetableViewModel : ObservableObject
	{
		private readonly string _team;

		private TimetableHeader _header;
		private bool _isBusy;
		private ObservableCollection<TimetableItem> _timetable;

		public string ShortTeam => _team;
		public TimetableViewModel(DateTime date, string team, bool isUp)
		{
			RefreshCommand = new Command(async arg => await RefreshTimetable(arg as bool?));
			Date = date;
			_team = team;
			Timetable = new ObservableCollection<TimetableItem>();
			RefreshCommand.Execute(!isUp);
			var timer = ServiceLocator.GetService<ITimerService>();
			var cacher = ServiceLocator.GetService<ISelectedTeamCacher>();
			cacher.Cache(_team);
			timer.AddHandler(UpdateCurrentAction);
			Header = new TimetableHeader
			{
				Team = Team,
				Date = Date.ToString("D"),
				IsLoaded = true
			};
			UpdateCurrentAction();
		}

		public TimetableHeader Header
		{
			get { return _header; }
			set { SetProperty(ref _header, value); }
		}

		public Command RefreshCommand { get; set; }

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

		public string Team => TimetableService.KeywordDictionary[_team];

		private void UpdateCurrentAction()
		{
			var time = ServiceLocator.GetService<IDateTimeService>().GetCurrentTime();
			foreach (var item in Timetable)
			{
				var startTime = Date.AddHours(item.Parent.Start.Value.Hour).AddMinutes(item.Parent.Start.Value.Minute);
				var endTime = Date.AddHours(item.Parent.End.Value.Hour).AddMinutes(item.Parent.End.Value.Minute);
				if ((startTime <= time) && (time <= endTime))
					item.Color = Color.FromHex("#10ff007b");
				else if (endTime < time)
					item.Color = Color.FromHex("#88CBCBCB");
				else
					item.Color = Color.Transparent;
			}
		}

		private async Task RefreshTimetable(bool? hard)
		{
			if (hard == null)
			{
				try
				{
					await TimetableService.RefreshTimetables(Date);
				}
				catch(Exception ex)
				{
					await Application.Current.MainPage.Navigation.PopAllPopupAsync();
					await Application.Current.MainPage.DisplayAlert(
						"Произошла ошибка при загрузке данных",
						"Убедитесь, что вы подключены к сети Сириуса (Sirius_free) и повторите попытку",
						"Ок");
					IsBusy = false;
					return;
				}
			}
			else if (hard.Value)
			{
				try
				{
					await Application.Current.MainPage.Navigation.PushPopupAsync(new LoadingView());
					await TimetableService.RefreshTimetables(Date);
					await Application.Current.MainPage.Navigation.PopAllPopupAsync();
				}
				catch (Exception ex)
				{
					await Application.Current.MainPage.Navigation.PopAllPopupAsync();
					await Application.Current.MainPage.DisplayAlert(
						"Произошла ошибка при загрузке данных",
						"Убедитесь, что вы подключены к сети Сириуса (Sirius_free) и повторите попытку",
						"Ок");
					IsBusy = false;
					return;
				}
			}

			var dateKey = Date.ToString("dd.MM.yyyy").Replace(".", "");
			var timetable = TimetableService.Timetables[dateKey];
			var currentTimetable = timetable.Teams[TimetableService.KeywordDictionary[_team]];
			var collection = currentTimetable.Select(activity => new TimetableItem(activity));
			Timetable = new ObservableCollection<TimetableItem>(collection);
			UpdateCurrentAction();
			IsBusy = false;
		}
	}
}