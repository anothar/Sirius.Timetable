using Android.App;
using Android.Content.PM;
using Android.OS;
using Sirius.Timetable.Core.Services;
using Sirius.Timetable.Core;

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
            ServiceLocator.RegisterService<ICacheTimetable>(new Sirius.Timetable.Droid.Services.CacheTimetable());

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

		public override void OnBackPressed()
		{
			base.MoveTaskToBack(true);
		}
	}
}