using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
    public partial class LoadingView
    {
        public LoadingView()
        {
            InitializeComponent();

            var tap = new TapGestureRecognizer();
            tap.Tapped += (object s, EventArgs e) => { return; };
            Background.GestureRecognizers.Add(tap);
        }
    }
}
