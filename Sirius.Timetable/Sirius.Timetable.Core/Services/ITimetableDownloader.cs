using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core.Services
{
	public interface ITimetableDownloader
	{
		Task<string> GetJsonText(DateTime date);
	}
}