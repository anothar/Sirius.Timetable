using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Sirius.Timetable.Core.Services;
using Activity = Sirius.Timetable.Core.Activity;

namespace Sirius.Timetable.Droid.Services
{
	public class Notificator : INotificationService
	{
		private readonly Context _context;

		public Notificator(Context context)
		{
			_context = context;
		}

		public void CreateNotification(Activity activity, DateTime date, string title)
		{
			var mBuilder = new NotificationCompat.Builder(_context)
				.SetContentTitle(title)
				.SetContentText(activity.Title);
			var notificationIntent = new Intent(_context, typeof(NotificationPublisher));
			notificationIntent.PutExtra(NotificationPublisher.NotificationId, 1);
			notificationIntent.PutExtra(NotificationPublisher.Notification, mBuilder.Build());
			var pendingIntent = PendingIntent.GetBroadcast(_context, 0, notificationIntent, PendingIntentFlags.UpdateCurrent);

			var alarmManager = (AlarmManager) _context.GetSystemService(Context.AlarmService);
			alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, date.Millisecond, pendingIntent);
		}
	}

	public class NotificationPublisher : BroadcastReceiver
	{
		public static string NotificationId { get; set; } = "notificationId";
		public static string Notification { get; set; } = "notification";

		public override void OnReceive(Context context, Intent intent)
		{
			var notificationManager = (NotificationManager) context.GetSystemService(Context.NotificationService);
			var notification = (Notification) intent.GetParcelableExtra(Notification);
			var id = intent.GetIntExtra(NotificationId, 0);
			notificationManager.Notify(id, notification);
		}
	}
}