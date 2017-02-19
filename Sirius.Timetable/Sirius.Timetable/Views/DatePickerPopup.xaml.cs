using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
    public partial class DatePickerPopup
    {
        private readonly TaskCompletionSource<DateTime> _completion = new TaskCompletionSource<DateTime>();
        private Task<DateTime> CompletionTask => _completion.Task;

        public DatePickerPopup(DateTime date)
        {
            InitializeComponent();
            Picker.Date = date;
            Picker.Format = "dd.MM.yyyy";
        }

        public async Task<DateTime> SelectDateAsync()
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(this);
            return await CompletionTask;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            var a = 2;
            _completion.TrySetResult(DateTime.Now);
        }
    }
}
