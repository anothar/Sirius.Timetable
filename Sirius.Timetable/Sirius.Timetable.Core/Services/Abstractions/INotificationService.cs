using System;
using SiriusTimetable.Core.Timetable;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface INotificationService
	{
		void CreateNotification(Activity activity, DateTime date, string title);
	}
}