﻿using System;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Models;
using Sirius.Timetable.Services;
using Sirius.Timetable.ViewModels;
using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
	public partial class TimetablePage
	{
		public TimetablePage()
		{
			InitializeComponent();
			//var cache = ServiceLocator.GetService<ISelectedTeamCacher>();
			//var team = cache.Get();
			//if (String.IsNullOrEmpty(team)) return;
			//ListView.BindingContext = new TimetableViewModel(DateTime.Today, team, false);
			//ListView.SetBinding(ListView.RefreshCommandProperty, "RefreshCommand");
		}

		private void ListViewOnActivityTapped(object sender, ItemTappedEventArgs e)
		{
			var item = (TimetableItem) e.Item;
			item.IsSelected = !item.IsSelected;
		}

		private void ListViewOnActivitySelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView) sender).SelectedItem = null;
		}

		public void UpdateTeam()
		{
			ListView.BindingContext = new TimetableViewModel((ListView.BindingContext as TimetableViewModel)?.Date ?? DateTime.Today, ((GetTeamService)BindingContext).Team ?? (ListView.BindingContext as TimetableViewModel)?.ShortTeam, true);
			ListView.SetBinding(ListView.RefreshCommandProperty, "RefreshCommand");
		}

		public static TimetableViewModel P;
		public static TimetableViewModel N;
			
		public void UpdateDate(DateTime date)
		{
			ListView.BindingContext = new TimetableViewModel(date, ((GetTeamService)BindingContext).Team ?? (ListView.BindingContext as TimetableViewModel)?.ShortTeam, false);
			ListView.SetBinding(ListView.RefreshCommandProperty, "RefreshCommand");
			//P = (TimetableViewModel)ListView.BindingContext;
			//N = new TimetableViewModel(date, ((GetTeamService)BindingContext).Team ?? (ListView.BindingContext as TimetableViewModel)?.ShortTeam, false, null);
			//N.Timetable = P.Timetable;
			//ListView.BindingContext = N;
			//ListView.SetBinding(ListView.RefreshCommandProperty, "RefreshCommand");
		}
	}
}