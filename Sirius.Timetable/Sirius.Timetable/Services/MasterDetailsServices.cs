using System.Collections.Generic;
using Xamarin.Forms;

namespace SiriusTimetable.Common.Services
{
	public class MasterDetailsServices
	{
		public static Dictionary<SiriusTimetable.Common.App.Detail, Page> DetailPages { get; set; } = new Dictionary<SiriusTimetable.Common.App.Detail, Page>();
	}
}