using System.Collections.Generic;
using Xamarin.Forms;

namespace Sirius.Timetable.Services
{
	public class MasterDetailsServices
	{
		public static Dictionary<App.Detail, Page> DetailPages { get; set; } = new Dictionary<App.Detail, Page>();
	}
}