using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace Sirius.Timetable.Views
{
    public partial class TeamSelectPage : PopupPage
    {
        private readonly TaskCompletionSource<string> _completion = new TaskCompletionSource<string>();
        public Task<string> CompletionTask => _completion.Task;

        public async Task<string> SelectTesmAsync()
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(this);
            return await CompletionTask;
        }

        public TeamSelectPage()
        {
            InitializeComponent();
            var tapImg = new TapGestureRecognizer();

            tapImg.Tapped += OnChoose;
            science.GestureRecognizers.Add(tapImg);
            sport.GestureRecognizers.Add(tapImg);
            literature.GestureRecognizers.Add(tapImg);
            art.GestureRecognizers.Add(tapImg);
        }

        private async void OnCancel(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
            _completion.TrySetResult(null);
        }

        private async void OnChoose(object sender, EventArgs e)
        {
            SelectedItem = ((Image)sender).Resources["tag"].ToString();
            await Application.Current.MainPage.Navigation.PopPopupAsync();
            _completion.TrySetResult(SelectedItem);
        }

        public string SelectedItem { get; private set; }
    }
}
