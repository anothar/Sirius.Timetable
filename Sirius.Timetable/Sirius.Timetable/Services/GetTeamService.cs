using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Sirius.Timetable.Views;
using Xamarin.Forms;

namespace Sirius.Timetable.Services
{
	public class GetTeamService
	{
		public static Command GetTeamCommand { get; set; } = new Command(async date => await GetTeamExecute());
		public static string Team { get; set; }

		private static async Task GetTeamExecute()
		{
			try
			{
			    if (TimetableService.Timetables == null)
			    {
			        await Application.Current.MainPage.Navigation.PushPopupAsync(new LoadingView());
			        await TimetableService.RefreshTimetables(DateTime.Today);
			        await Application.Current.MainPage.Navigation.PopAllPopupAsync();
			    }
			}
			catch (Exception)
            {
                await Application.Current.MainPage.Navigation.PopAllPopupAsync();
                await Application.Current.MainPage.DisplayAlert(
                    "Произошла ошибка при загрузке данных",
					"Убедитесь, что вы подключены к сети Сириуса (Sirius_free) и повторите попытку", 
                    "Ок");
				return;
			}

			var selectPage = new TeamSelectPage();
			var selectedGroup = await selectPage.SelectTeamAsync();

			if(String.IsNullOrEmpty(selectedGroup))
				return;

			Team = selectedGroup;
			((TimetablePage)MasterDetailsServices.DetailPages[App.Detail.Timetable]).UpdateTeam();
		}
	}
}