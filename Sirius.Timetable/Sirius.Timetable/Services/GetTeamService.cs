using System;
using System.Threading.Tasks;
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
			await TimetableService.RefreshTimetables(DateTime.Today);
			var selectPage = new TeamSelectPage();
			var selectedGroup = await selectPage.SelectTeamAsync();

			if(String.IsNullOrEmpty(selectedGroup))
				return;

			Team = selectedGroup;
			((TimetablePage)MasterDetailsServices.DetailPages[App.Detail.Timetable]).UpdateTeam();
		}
	}
}