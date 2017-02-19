using Android.App;
using Android.Content.PM;
using Android.OS;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Sirius.Timetable.Droid
{
	[Activity(
		 Label = "Расписание Сириус",
		 Theme = "@style/MyTheme",
		 MainLauncher = true,
		 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)
	]
	public class MainActivity : FormsAppCompatActivity
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

			Forms.Init(this, bundle);

			LoadApplication(new App());
		}

		public override void OnBackPressed()
		{
			MoveTaskToBack(true);
		}
	}
}