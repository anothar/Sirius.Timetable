using Android.App;
using Android.Content.PM;
using Android.OS;
using SiriusTimetable.Core.Services;
using SiriusTimetable.Core.Services.Abstractions;
using SiriusTimetable.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App = SiriusTimetable.Common.App;

namespace SiriusTimetable.Droid
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
			ServiceLocator.RegisterService<ITimerService>(new TimerSerice());
			ServiceLocator.RegisterService<IDateTimeService>(new DateTimeService());
			ServiceLocator.RegisterService<IDatePickerDialogService>(new DatePickerDialogService(FragmentManager));
			ServiceLocator.RegisterService<ITimetableDownloader>(new TimetableDownloader());
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