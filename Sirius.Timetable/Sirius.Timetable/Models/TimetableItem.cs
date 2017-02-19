using System;
using Sirius.Timetable.Core;
using Sirius.Timetable.Helpers;
using Xamarin.Forms;

namespace Sirius.Timetable.Models
{
	public class TimetableItem : ObservableObject
	{
		private string _busFrom;
		private string _busTo;
		private Color _color = Color.Transparent;
		private bool _isBus;
		private bool _isPlace;
		private bool _isSelected;
		private string _place;
		private string _start;
		private LineBreakMode _warp = LineBreakMode.TailTruncation;

		public TimetableItem(Activity activity)
		{
			Parent = activity;
			if (activity.Start != null) Start = activity.Start.Value.ToString("HH:mm");
			if (activity.End != null) End = activity.End.Value.ToString("HH:mm");
			if (activity.BusTo != null) BusTo = activity.BusTo.Value.ToString("HH:mm");
			if (activity.BusFrom != null) BusFrom = activity.BusFrom.Value.ToString("HH:mm");
			Title = activity.Title;
			Place = activity.Place;
			IsBus = !String.IsNullOrEmpty(BusTo);
			IsPlace = !String.IsNullOrEmpty(Place);
		}

		public Activity Parent { get; }

		public LineBreakMode Wrap
		{
			get { return _warp; }
			set { SetProperty(ref _warp, value); }
		}

		public Color Color
		{
			get { return _color; }
			set { SetProperty(ref _color, value); }
		}

		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				SetProperty(ref _isSelected, value);
				OnPropertyChanged(nameof(IsPlace));
				OnPropertyChanged(nameof(IsBus));
			}
		}

		public string Start
		{
			get { return _start; }
			set { SetProperty(ref _start, value); }
		}

		public string End { get; set; }

		public string BusTo
		{
			get { return String.IsNullOrEmpty(_busTo) ? "" : _busTo; }
			set { _busTo = value; }
		}

		public string BusFrom
		{
			get { return String.IsNullOrEmpty(_busFrom) ? "" : _busFrom; }
			set { _busFrom = value; }
		}

		public string Title { get; set; }

		public string Place
		{
			get { return String.IsNullOrEmpty(_place) ? "" : _place; }
			set { _place = value; }
		}

		public bool IsBus
		{
			get { return _isBus && _isSelected; }
			set { SetProperty(ref _isBus, value); }
		}

		public bool IsPlace
		{
			get { return _isPlace && _isSelected; }
			set { SetProperty(ref _isPlace, value); }
		}
	}
}