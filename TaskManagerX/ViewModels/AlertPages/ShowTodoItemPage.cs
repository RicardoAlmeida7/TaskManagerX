using TaskManagerX.Models;

namespace TaskManagerX.ViewModels
{
    public class ShowTodoItemPage : CustomAlertPage
    {
        public ShowTodoItemPage(TodoItem item)
        {
            var grid = CustomAlertPage.GridConfiguration();

            var titleLabel = new Label
            {
                Text = item.Title,
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(10),
                TextColor = Color.Parse("White")
            };

            var messageLabel = new Label
            {
                Text = item.Description,
                FontSize = 20,
                Margin = new Thickness(10, 20, 10, 0),
                TextColor = Color.Parse("White")
            };

            var scrollView = new ScrollView
            {
                Content = messageLabel
            };

            var width = DeviceDisplay.MainDisplayInfo.Width;

            var okButton = FactoryButtonOk("Ok", "DarkOrange", LayoutOptions.Fill, width);

            grid.Add(titleLabel, 0, 1);
            grid.Add(scrollView, 0, 2);
            grid.Add(okButton, 0, 3);

            Content = grid;
        }
    }
}
