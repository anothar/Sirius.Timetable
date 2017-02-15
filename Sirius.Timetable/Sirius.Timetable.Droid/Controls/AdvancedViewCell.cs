using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sirius.Timetable.Controls;
using Xamarin.Forms;

namespace Sirius.Timetable.Droid.Controls
{
	internal sealed class AdvancedViewCell : LinearLayout, INativeElementView
	{
		public AdvancedCell AdvancedCell { get; set; }

		public Element Element => AdvancedCell;
		
		public AdvancedViewCell(Context context) : base (context)
		{
			AddView(Android.Views.View.Inflate(context, Resource.Layout.ViewCell, null));
		}
	}
}