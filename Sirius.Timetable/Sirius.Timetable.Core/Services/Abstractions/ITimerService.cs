using System;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface ITimerService
	{
		void AddHandler(Action action);
	}
}