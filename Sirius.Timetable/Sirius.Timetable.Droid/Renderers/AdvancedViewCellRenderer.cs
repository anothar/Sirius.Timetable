using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using Sirius.Timetable.Controls;
using Sirius.Timetable.Droid.Controls;
using Sirius.Timetable.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(AdvancedCell), typeof(AdvancedViewCellRenderer))]

namespace Sirius.Timetable.Droid.Renderers
{
	public class AdvancedViewCellRenderer : ViewCellRenderer
	{
		protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
		{
			var advCell = item as AdvancedCell;
			var advancedViewCell = convertView as AdvancedViewCell;
			if (advancedViewCell == null)
			{
				advancedViewCell = new AdvancedViewCell(context)
				{
					AdvancedCell = advCell
				};
			}
			else
			{
				advancedViewCell.AdvancedCell.PropertyChanged -= OnAdvancedViewCellPropertyChanged;
			}

			advCell.PropertyChanged += OnAdvancedViewCellPropertyChanged;

			return advancedViewCell;
		}

		private void OnAdvancedViewCellPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			/*var advCell = (AdvancedCell) sender;
			if (e.PropertyName == AdvancedCell.SelectedBackgroundColorProperty.PropertyName)
			{
				_SelectedColor = advCell.SelectedBackgroundColor.ToAndroid();
			}
			else if (e.PropertyName == AdvancedCell.IsSelectedProperty.PropertyName)
			{
				_advancedViewCell.SetBackgroundColor(_SelectedColor);
			}*/
		}
		private Android.Graphics.Color _color;
		private Android.Graphics.Color _SelectedColor;
	//	private AdvancedViewCell _advancedViewCell;
	}
}