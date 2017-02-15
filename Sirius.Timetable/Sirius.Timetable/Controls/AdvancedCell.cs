using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sirius.Timetable.Controls
{
	public class AdvancedCell : ViewCell
	{
		public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(
			nameof(SelectedBackgroundColor), typeof(Color), typeof(AdvancedCell), Color.Transparent, BindingMode.OneWayToSource,
			null, OnBackColorPropertyChanged);

		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
			nameof(IsSelected), typeof(bool), typeof(AdvancedCell), false, BindingMode.TwoWay, null, OnIsSelectedPropertyChanged);

		private static void OnIsSelectedPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			((AdvancedCell) bindable).IsSelected = (bool)newValue;
		}

		private static void OnBackColorPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			((AdvancedCell) bindable).SelectedBackgroundColor = (Color)newValue;
		}

		public Color SelectedBackgroundColor
		{
			get { return (Color)GetValue(SelectedBackgroundColorProperty); }
			set { SetValue(SelectedBackgroundColorProperty, value);}
		}

		public bool IsSelected
		{
			get { return (bool) GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value);}
		}
		protected override void OnTapped()
		{
			IsSelected = true;
		}
	}
}