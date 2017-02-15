using System;
using Sirius.Timetable.Models;
using Sirius.Timetable.ViewModels;
using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
	public partial class TimetablePage
	{
		public TimetablePage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new TimetableViewModel(null, null);
		}
		
		private void ListViewOnActivitySelected(object sender, SelectedItemChangedEventArgs e)
		{
			foreach (var timetableItem in _viewModel.Timetable)
			{
				timetableItem.IsSelected = false;
				timetableItem.Color = Color.Transparent;
			}
			var item = (TimetableItem)e.SelectedItem;
			item.IsSelected = true;
			item.Color = (Color)Application.Current.Resources["Accent"];
		}

		private readonly TimetableViewModel _viewModel;
	}
}