using System;
using System.Timers;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
	public class TimerSerice : ITimerService
	{
		private readonly Timer _timer;
		private Action _action;
		private ElapsedEventHandler _handler;

		public TimerSerice()
		{
			_timer = new Timer {Interval = 60000};
		}

		public void AddHandler(Action action)
		{
			_action = action;
			_handler = (sender, args) =>
			{
				if (_action == null)
				{
					_timer.Elapsed -= _handler;
					_timer.Stop();
				}
				else _action.Invoke();
			};
			_timer.Elapsed += _handler;
			_timer.Start();
		}
	}
}