using Xamarin.Forms;

namespace Sirius.Timetable.Controls
{
	public class AdvancedCell : ViewCell
	{
		public static readonly BindableProperty SelectedBackgroundColorProperty =
			BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(AdvancedCell), Color.Transparent,
				BindingMode.TwoWay);

		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool),
			typeof(AdvancedCell), false, BindingMode.TwoWay);

		public static readonly BindableProperty StartProperty = BindableProperty.Create(nameof(Start), typeof(string), typeof(AdvancedCell), "", BindingMode.TwoWay);

		public static readonly BindableProperty EndProperty = BindableProperty.Create(nameof(End), typeof(string), typeof(AdvancedCell), "", BindingMode.TwoWay);

		public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(AdvancedCell), "", BindingMode.TwoWay);

		public static readonly BindableProperty BusToProperty = BindableProperty.Create(nameof(BusTo), typeof(string), typeof(AdvancedCell), "", BindingMode.TwoWay);

		public static readonly BindableProperty BusFromProperty = BindableProperty.Create(nameof(BusFrom), typeof(string),
			typeof(AdvancedCell), "", BindingMode.TwoWay);

		public static readonly BindableProperty PlaceProperty = BindableProperty.Create(nameof(Place), typeof(string),
			typeof(AdvancedCell), "", BindingMode.TwoWay);

		public static readonly BindableProperty MainTextSizeProperty = BindableProperty.Create(nameof(MainTextSize), typeof(int), typeof(AdvancedCell), 14, BindingMode.TwoWay);

		public static readonly BindableProperty DetailTextSizeProperty = BindableProperty.Create(nameof(DetailTextSize),
			typeof(int), typeof(AdvancedCell), 14, BindingMode.TwoWay);

		public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor),
			typeof(Color), typeof(AdvancedCell), Color.Transparent, BindingMode.TwoWay);

		public static readonly BindableProperty IsBusProperty = BindableProperty.Create(nameof(IsBus), typeof(bool),
			typeof(AdvancedCell), false, BindingMode.TwoWay);

		public static readonly BindableProperty IsPlaceProperty = BindableProperty.Create(nameof(IsPlace), typeof(bool),
			typeof(AdvancedCell), false, BindingMode.TwoWay);

		public Color SelectedBackgroundColor
		{
			get { return (Color)GetValue(SelectedBackgroundColorProperty); }
			set { SetValue(SelectedBackgroundColorProperty, value);}
		}
		public Color BackgroundColor
		{
			get { return (Color)GetValue(BackgroundColorProperty); }
			set { SetValue(BackgroundColorProperty, value); }
		}
		public bool IsSelected
		{
			get { return (bool) GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value);}
		}
		public string Start
		{
			get { return (string) GetValue(StartProperty); }
			set { SetValue(StartProperty, value); }
		}
		public string End
		{
			get { return (string) GetValue(EndProperty); }
			set { SetValue(EndProperty, value); }
		}
		public string Title
		{
			get { return (string) GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public string BusTo
		{
			get { return (string) GetValue(BusToProperty); }
			set { SetValue(BusFromProperty, value); }
		}
		public string BusFrom
		{
			get { return (string) GetValue(BusFromProperty); }
			set { SetValue(BusFromProperty, value); }
		}
		public string Place
		{
			get { return (string) GetValue(PlaceProperty); }
			set { SetValue(PlaceProperty, value); }
		}
		public int MainTextSize
		{
			get { return (int) GetValue(MainTextSizeProperty); }
			set { SetValue(MainTextSizeProperty, value); }
		}
		public bool IsBus
		{
			get { return (bool) GetValue(IsBusProperty); }
			set { SetValue(IsBusProperty, value); }
		}
		public bool IsPlace
		{
			get { return (bool) GetValue(IsPlaceProperty); }
			set { SetValue(IsPlaceProperty, value); }
		}
		public int DetailTextSize
		{
			get { return (int) GetValue(DetailTextSizeProperty); }
			set { SetValue(DetailTextSizeProperty, value); }
		}

	}
}