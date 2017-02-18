using System;

namespace Sirius.Timetable.Core.Services
{
	public interface INotificationService
	{
		void CreateNotification(Activity activity,  DateTime date, string title);
	}
}