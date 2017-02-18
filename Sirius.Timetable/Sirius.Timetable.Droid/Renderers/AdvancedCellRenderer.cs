using System.ComponentModel;
using Android.Content;
using Android.Views;
using Sirius.Timetable.Controls;
using Sirius.Timetable.Droid.Controls;
using Sirius.Timetable.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;
using Android.Text;

[assembly: ExportRenderer(typeof(AdvancedCell), typeof(AdvancedCellRenderer))]
namespace Sirius.Timetable.Droid.Renderers
{
	public class AdvancedCellRenderer : ViewCellRenderer
	{
		private AdvancedCellControler _cell;
		protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
		{
			var advancedCell = (AdvancedCell) item;
			_cell = convertView as AdvancedCellControler;
			if (_cell == null)
			{
				_cell = new AdvancedCellControler(context, advancedCell);
			}
			else
			{
				_cell.AdvancedCell.PropertyChanged -= AdvancedCellOnPropertyChnaged;
			}
			advancedCell.PropertyChanged += AdvancedCellOnPropertyChnaged;

			_cell.UpdateCell(advancedCell);

			return _cell;
		}

		private void AdvancedCellOnPropertyChnaged(object sender, PropertyChangedEventArgs e)
		{
			var advancedCell = (AdvancedCell) sender;
			if (e.PropertyName == AdvancedCell.StartProperty.PropertyName)
				_cell.StartTextView.Text = advancedCell.Start;
			else if (e.PropertyName == AdvancedCell.EndProperty.PropertyName)
				_cell.EndTextView.Text = advancedCell.End;
			else if (e.PropertyName == AdvancedCell.BusToProperty.PropertyName)
				_cell.BusToTextView.Text = advancedCell.BusTo;
			else if (e.PropertyName == AdvancedCell.BusFromProperty.PropertyName)
				_cell.BusFromTextView.Text = advancedCell.BusFrom;
			else if (e.PropertyName == AdvancedCell.TitleProperty.PropertyName)
				_cell.TitleTextView.Text = advancedCell.Title;
			else if (e.PropertyName == AdvancedCell.PlaceProperty.PropertyName)
				_cell.PlaceTextView.Text = advancedCell.Place;
			else if (e.PropertyName == AdvancedCell.MainTextSizeProperty.PropertyName)
				_cell.StartTextView.TextSize = _cell.EndTextView.TextSize = _cell.DashTextView.TextSize = _cell.TitleTextView.TextSize = advancedCell.MainTextSize;
			else if (e.PropertyName == AdvancedCell.DetailTextSizeProperty.PropertyName)
				_cell.BusToTextView.TextSize =
					_cell.BusFromTextView.TextSize =
						_cell.PlaceTextView.TextSize = advancedCell.DetailTextSize;
			else if (e.PropertyName == AdvancedCell.IsSelectedProperty.PropertyName)
			{
				_cell.Details.Visibility = advancedCell.IsSelected ? ViewStates.Visible : ViewStates.Gone;
				_cell.TitleTextView.SetSingleLine(!advancedCell.IsSelected);
				_cell.TitleTextView.Ellipsize = advancedCell.IsSelected ? null : TextUtils.TruncateAt.Marquee;
				if (advancedCell.IsSelected) _cell.BackLayout.SetBackgroundColor(advancedCell.SelectedBackgroundColor.ToAndroid());
				else _cell.BackLayout.SetBackgroundResource(Resource.Drawable.item_background);
			}
			else if (e.PropertyName == AdvancedCell.IsBusProperty.PropertyName)
				_cell.Bus.Visibility = advancedCell.IsBus ? ViewStates.Visible : ViewStates.Gone;
			else if (e.PropertyName == AdvancedCell.IsPlaceProperty.PropertyName)
				_cell.PlaceTextView.Visibility = advancedCell.IsPlace ? ViewStates.Visible : ViewStates.Gone;
			else if (e.PropertyName == AdvancedCell.SelectedBackgroundColorProperty.PropertyName && advancedCell.IsSelected)
				_cell.BackLayout.SetBackgroundColor(advancedCell.SelectedBackgroundColor.ToAndroid());
		}
	}
}