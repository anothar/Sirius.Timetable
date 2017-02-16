using Sirius.Timetable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sirius.Timetable
{
	public partial class App
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
            
		}

		public static void SetMainPage()
		{
			Current.MainPage = new MasterDetailPage
			{
				Master = new ContentPage { Title = "Master" },
				Detail = new NavigationPage(new TimetablePage())
			};
		}
	}
}
