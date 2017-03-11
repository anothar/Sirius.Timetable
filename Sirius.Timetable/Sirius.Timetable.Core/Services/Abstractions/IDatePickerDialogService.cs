using System;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface IDatePickerDialogService
	{
		void ChoosenDate(Action<DateTime> action);
	}
}