using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Sirius.Timetable.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Sirius.Timetable.Droid.Controls
{
	public sealed class AdvancedCellControler : LinearLayout, INativeElementView
	{
		public TextView StartTextView { get; set; }
		public LinearLayout BackLayout { get; set; }
		public TextView DashTextView { get; set; }
		public TextView EndTextView { get; set; }
		public TextView TitleTextView { get; set; }
		public TextView BusToTextView { get; set; }
		public TextView BusHelper1 { get; set; }
		public TextView BusHelper2 { get; set; }
		public TextView BusFromTextView { get; set; }
		public TextView PlaceTextView { get; set; }
		public LinearLayout Details { get; set; }
		public LinearLayout Bus { get; set; }
		public AdvancedCell AdvancedCell { get; set; }
		public Element Element => AdvancedCell;
		public AdvancedCellControler(Context context, AdvancedCell advancedCell) : base(context)
		{
			AdvancedCell = advancedCell;
			var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.AdvancedCellView, null);
			StartTextView = view.FindViewById<TextView>(Resource.Id.TextStart);
			EndTextView = view.FindViewById<TextView>(Resource.Id.TextEnd);
			TitleTextView = view.FindViewById<TextView>(Resource.Id.TextTitle);
			BusToTextView = view.FindViewById<TextView>(Resource.Id.TextBusTo);
			BusFromTextView = view.FindViewById<TextView>(Resource.Id.TextBusFrom);
			DashTextView = view.FindViewById<TextView>(Resource.Id.TextDash);
			BackLayout = view.FindViewById<LinearLayout>(Resource.Id.Ground);
			PlaceTextView = view.FindViewById<TextView>(Resource.Id.TextPlace);
			Details = view.FindViewById<LinearLayout>(Resource.Id.DetailLine);
			Bus = view.FindViewById<LinearLayout>(Resource.Id.Bus);
			BusHelper1 = view.FindViewById<TextView>(Resource.Id.DetailHelp1);
			BusHelper2 = view.FindViewById<TextView>(Resource.Id.DetailHelp2);

			AddView(view, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
		}

		public void UpdateCell(AdvancedCell cell)
		{
			StartTextView.Text = cell.Start;
			EndTextView.Text = cell.End;
			TitleTextView.Text = cell.Title;
			BusToTextView.Text = cell.BusTo;
			BusFromTextView.Text = cell.BusFrom;
			PlaceTextView.Text = cell.Place;

			Details.Visibility = cell.IsSelected ? ViewStates.Visible : ViewStates.Gone;
			PlaceTextView.Visibility = cell.IsPlace ? ViewStates.Visible : ViewStates.Gone;
			Bus.Visibility = cell.IsBus ? ViewStates.Visible : ViewStates.Gone;

			StartTextView.TextSize = EndTextView.TextSize = DashTextView.TextSize = TitleTextView.TextSize = cell.MainTextSize;
			BusToTextView.TextSize = BusFromTextView.TextSize = PlaceTextView.TextSize = BusHelper1.TextSize = BusHelper2.TextSize = cell.DetailTextSize;
		}
	}
}