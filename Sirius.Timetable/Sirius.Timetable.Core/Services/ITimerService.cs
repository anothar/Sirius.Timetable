using System;

namespace Sirius.Timetable.Core.Services
{
	public interface ITimerService
	{
		void AddHandler(Action action);
	}
}