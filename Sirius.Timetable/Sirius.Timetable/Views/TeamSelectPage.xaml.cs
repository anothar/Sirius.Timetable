using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Sirius.Timetable.Services;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Sirius.Timetable.ViewModels;

namespace Sirius.Timetable.Views
{
    public partial class TeamSelectPage : PopupPage
    {
        private readonly TaskCompletionSource<string> _completion = new TaskCompletionSource<string>();
        public Task<string> CompletionTask => _completion.Task;

        public TeamSelectPage()
        {
            InitializeComponent();
            var tapImg = new TapGestureRecognizer();

            tapImg.Tapped += OnChooseDirection;
            science.GestureRecognizers.Add(tapImg);
            sport.GestureRecognizers.Add(tapImg);
            literature.GestureRecognizers.Add(tapImg);
            art.GestureRecognizers.Add(tapImg);
        }

        public async Task<string> SelectTeamAsync()
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(this);
            return await CompletionTask;
        }

        private async void OnCancel(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
            _completion.TrySetResult(null);
        }

        private void OnChooseDirection(object sender, EventArgs e)
        {
            var arr = new List<Image> { science, sport, literature, art };
            if (SelectedItem == ((Image) sender).Resources["tag"].ToString() && Groups.IsVisible)
            {
                foreach (var item in arr)
                {
                    item.Opacity = 1;
                }
                Groups.IsVisible = false;
                DirectionName.IsVisible = false;
                return;
            }
            if (SelectedItem == ((Image) sender).Resources["tag"].ToString())
            {
                foreach (var item in arr)
                {
                    item.Opacity = 0.25;
                }
                ((Image)sender).Opacity = 1;
                DirectionName.IsVisible = true;
                Groups.IsVisible = true;
                return;
            }
            foreach (var item in arr)
            {
                item.Opacity = 0.25;
            }
            ((Image)sender).Opacity = 1;

            SelectedItem = ((Image)sender).Resources["tag"].ToString();
            DirectionName.Text = (string)DirectionName.Resources[SelectedItem];
            var numbers = TimetableService.TeamsLiterPossibleNumbers[SelectedItem].Select(GetGroupSelector);
            Groups.IsVisible = false;
            DirectionName.IsVisible = false;
            Groups.Children.Clear();
            foreach (var item in numbers) {
                Groups.Children.Add(item);
            }
            DirectionName.IsVisible = true;
            Groups.IsVisible = true;
        }

        private async void OnChooseGroup(object sender, EventArgs e)
        {
            var button = (Label) sender;
            SelectedNumber = button.Text;
            SelectedGroup = SelectedItem + SelectedNumber;
            await Navigation.PopPopupAsync();
            _completion.TrySetResult(SelectedGroup);
        }

        private Label GetGroupSelector(string text)
        {
            var tapGroup = new TapGestureRecognizer();
            tapGroup.Tapped += OnChooseGroup;
            var button = new Label()
            {
                Text = text,
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(2)
            };
            button.GestureRecognizers.Add(tapGroup);
            return button;
        }

        public string SelectedItem { get; private set; }
        public string SelectedNumber { get; private set; }
        public string SelectedGroup { get; private set; }
    }
}
