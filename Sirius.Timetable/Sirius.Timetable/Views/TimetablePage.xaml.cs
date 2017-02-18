using System;
using Sirius.Timetable.Models;
using Sirius.Timetable.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Sirius.Timetable.Services;
using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
	public partial class TimetablePage
	{
		public TimetablePage()
		{
			InitializeComponent();
		}
		
		private void ListViewOnActivityTapped(object sender, ItemTappedEventArgs e)
		{
			var item = (TimetableItem)e.Item;
			item.IsSelected = !item.IsSelected;
		}

		private void ListViewOnActivitySelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView) sender).SelectedItem = null;
		}

		public void UpdateTeam()
		{
			BindingContext = new TimetableViewModel(DateTime.Today, GetTeamService.Team);
		}

	}
}