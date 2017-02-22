using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core.Services
{
	public interface IDatePickerDialogService
	{
		void ChosenDate(Action<DateTime> action);
	}
}