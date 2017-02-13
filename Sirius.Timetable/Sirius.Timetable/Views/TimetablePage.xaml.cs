using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirius.Timetable.ViewModels;
using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
	public partial class TimetablePage
	{
		public TimetablePage()
		{
			InitializeComponent();
			_viewModel = new TimetableViewModel(null, null);
			BindingContext = _viewModel;
		}

		private TimetableViewModel _viewModel;
	}
}