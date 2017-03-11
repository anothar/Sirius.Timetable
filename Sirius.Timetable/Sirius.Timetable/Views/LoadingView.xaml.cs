namespace SiriusTimetable.Common.Views
{
	public partial class LoadingView
	{
		public LoadingView()
		{
			InitializeComponent();
		}

		protected override bool OnBackgroundClicked()
		{
			return false;
		}
	}
}