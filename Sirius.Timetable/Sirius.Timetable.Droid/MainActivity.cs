using Android.App;
using Android.Content.PM;
using Android.OS;
using Rg.Plugins.Popup.Extensions;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Droid.Services;

namespace Sirius.Timetable.Droid
{
	[Activity(
        Label = "Расписание Сириус", 
        Theme = "@style/MyTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)
        ]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
            ServiceLocator.RegisterService<ITimetableCacher>(new TimetableCacher());
            ServiceLocator.RegisterService<ISelectedTeamCacher>(new SelectedTeamCacher());
			ServiceLocator.RegisterService<INotificationService>(new Notificator(this));
			ServiceLocator.RegisterService<ITimerService>(new TimerSerice());
			ServiceLocator.RegisterService<IDateTimeService>(new DateTimeService());

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

		public override void OnBackPressed()
		{
			MoveTaskToBack(true);
		}
	}
}