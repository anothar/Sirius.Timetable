using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Sirius.Timetable.Helpers;
using Sirius.Timetable.Views;
using Xamarin.Forms;

namespace Sirius.Timetable.Services
{
	public class GetTeamService : ObservableObject
	{
		public GetTeamService()
		{
			GetTeamCommand = new Command(async o => await GetTeamExecute(), CanExecute);
		}
		public bool IsBusy
		{
			get { return _isBusy; }
			set { SetProperty(ref _isBusy, value); }
		}
		public Command GetTeamCommand { get; set; }
		private bool CanExecute(object o)
		{
			return !_isBusy;
		}
		public static string Team { get; set; }
		private bool _isBusy;
		private async Task GetTeamExecute()
		{
			_isBusy = true;
			GetTeamCommand.ChangeCanExecute();
			try
			{
			    if (TimetableService.Timetables == null)
			    {
					await TimetableService.RefreshTimetables(DateTime.Today);
				}
			}
			catch (Exception)
            {
                await Application.Current.MainPage.Navigation.PopAllPopupAsync();
                await Application.Current.MainPage.DisplayAlert(
                    "Произошла ошибка при загрузке данных",
					"Убедитесь, что вы подключены к сети Сириуса (Sirius_free) и повторите попытку", 
                    "Ок");
	            IsBusy = false;
				GetTeamCommand.ChangeCanExecute();
				return;
			}

			var selectPage = new TeamSelectPage();
			var selectedGroup = await selectPage.SelectTeamAsync();

			if (String.IsNullOrEmpty(selectedGroup))
			{
				IsBusy = false;
				GetTeamCommand.ChangeCanExecute();
				return;
			}
			Team = selectedGroup;
			((TimetablePage)MasterDetailsServices.DetailPages[App.Detail.Timetable]).UpdateTeam();
			IsBusy = false;
			GetTeamCommand.ChangeCanExecute();
		}
	}
}