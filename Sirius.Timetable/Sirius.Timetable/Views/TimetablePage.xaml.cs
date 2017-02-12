using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
	public partial class TimetablePage
	{
		public TimetablePage()
		{
			InitializeComponent();

			Master = new ItemsPage();
			Detail = new NavigationPage(new Views.AboutPage());

			this.ShouldShowToolbarButton();
		}
	}
}
