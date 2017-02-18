using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Sirius.Timetable.Services;
using Xamarin.Forms;

namespace Sirius.Timetable.Views
{
    public partial class TeamSelectPage
    {
        private readonly TaskCompletionSource<string> _completion = new TaskCompletionSource<string>();
        private bool IsSelected { get; set; }
        public Task<string> CompletionTask => _completion.Task;
        public string SelectedItem { get; private set; }
        public string SelectedNumber { get; private set; }
        public string SelectedGroup { get; private set; }

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

        private void OnChooseDirection(object sender, EventArgs e)
        {
            ButtonOk.FadeTo(0.25);
            GroupName.FadeTo(0);
            if (Groups.Children.Any())
            {
                SelectGroupByOpacity(Groups.Children[0], 0.25, 0.25);
            }
            if (SelectedItem == ((Image) sender).Resources["tag"].ToString() && Groups.Opacity == 1.0)
            {
                TitleText.Text = TitleText.Resources["1"].ToString();
                SelectDirectionByOpacity((Image)sender, 0.25, 0.25);
                ChangeVisible(false);
                return;
            }
            if (SelectedItem == ((Image) sender).Resources["tag"].ToString())
            {
                TitleText.Text = TitleText.Resources["2"].ToString();
                SelectDirectionByOpacity((Image) sender, 1, 0.25);
                ChangeVisible(true);
                return;
            }

            TitleText.Text = TitleText.Resources["2"].ToString();
            SelectDirectionByOpacity((Image)sender, 1, 0.25);
            SelectedItem = ((Image)sender).Resources["tag"].ToString();
            ChangeVisible(false);
            DirectionName.Text = (string)DirectionName.Resources[SelectedItem];


            var numbers = TimetableService.TeamsLiterPossibleNumbers[SelectedItem].Select(GetGroupSelector);
            
            Groups.Children.Clear();
            foreach (var item in numbers) {
                Groups.Children.Add(item);
            }

            ChangeVisible(true);
        }

        private void OnChooseGroup(object sender, EventArgs e)
        {
            if (SelectedGroup == ((Label) sender).Text && IsSelected)
            {
                return;
            }
            
            SelectGroupByOpacity((Label)sender, 1, 0.25);
            SelectedNumber = ((Label)sender).Text;
            SelectedGroup = SelectedItem + SelectedNumber;
            IsSelected = true;
            ButtonOk.FadeTo(1);
            GroupName.Text = TimetableService.KeywordDictionary[SelectedGroup];
            GroupName.FadeTo(1);
        }

        private void SelectDirectionByOpacity(Image toSelect, double opacitySelected, double opacityUnselected)
        {
            var arr = new List<Image> { science, sport, literature, art };
	        Task.WhenAll(
		        arr.Select(item => item.FadeTo(item != toSelect ? opacityUnselected : opacitySelected)));
        }

        private void SelectGroupByOpacity(IElementController toSelect, double opacitySelected, double opacityUnselected)
        {
	        Task.WhenAll(
		        Groups.Children.Select(item => item.FadeTo(item != toSelect ? opacityUnselected : opacitySelected)));
        }

        private void ChangeVisible(bool x)
        {
	        if (x)
	        {
				Task.WhenAll(
					DirectionName.FadeTo(1),
					Groups.FadeTo(1));
	        }
	        else
	        {
				Task.WhenAll(
			        DirectionName.FadeTo(0),
			        Groups.FadeTo(0));
	        }
		}

        private Label GetGroupSelector(string text)
        {
            var tapGroup = new TapGestureRecognizer();
            tapGroup.Tapped += OnChooseGroup;
            var selecter = new Label
            {
                Text = text,
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(2),
                Opacity = 0.25
            };
            selecter.GestureRecognizers.Add(tapGroup);
            return selecter;
        }

        private async void OnChoose(object sender, EventArgs e)
        {
            if (!IsSelected)
                return;
            await Application.Current.MainPage.Navigation.PopPopupAsync();
            _completion.TrySetResult(SelectedGroup);
        }
    }
}
