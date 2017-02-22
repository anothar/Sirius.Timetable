using System;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Services;
using Sirius.Timetable.ViewModels;
using Sirius.Timetable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Sirius.Timetable
{
	public partial class App
	{
		public enum Detail
		{
			Timetable
		}

		public App()
		{
			InitializeComponent();
			RegisterPages();
			SetMainPage();
		}

		private void RegisterPages()
		{
			MasterDetailsServices.DetailPages.Add(Detail.Timetable, new TimetablePage());
		}

		public static void SetMainPage()
		{
			Current.MainPage = new NavigationPage(MasterDetailsServices.DetailPages[Detail.Timetable]);
		}
	}
}