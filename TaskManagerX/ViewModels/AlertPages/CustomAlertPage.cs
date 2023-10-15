namespace TaskManagerX.ViewModels
{
    public class CustomAlertPage : ContentPage
    {
        public event EventHandler OkClicked;
        public event EventHandler CancelClicked;

        protected CustomAlertPage()
        {
            BackgroundColor = Color.Parse("Black");
        }

        protected Button FactoryButtonOk(string buttonText, string backgroundColor, LayoutOptions position, double width)
        {
            return new Button
            {
                Text = buttonText,
                BackgroundColor = Color.Parse(backgroundColor),
                TextColor = Color.Parse("White"),
                WidthRequest = width,
                FontSize = 18,
                Margin = new Thickness(10),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = position,
                Command = new Command(() =>
                {
                    OkClicked?.Invoke(this, EventArgs.Empty);
                    CloseAlert();
                })
            };
        }

        protected Button FactoryButtonCancel(string buttonText, string backgroundColor, LayoutOptions position)
        {
            return new Button
            {
                Text = buttonText,
                BackgroundColor = Color.Parse(backgroundColor),
                TextColor = Color.Parse("White"),
                WidthRequest = 150,
                FontSize = 18,
                Margin = new Thickness(10),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = position,
                Command = new Command(() =>
                {
                    CancelClicked?.Invoke(this, EventArgs.Empty);
                    CloseAlert();
                })
            };
        }

        protected static Grid GridConfiguration()
        {
            return new Grid
            {
                RowDefinitions = {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = GridLength.Auto },
                }
            };
        }

        private async void CloseAlert() =>
            await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}
