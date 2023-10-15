using TaskManagerX.Models;

namespace TaskManagerX.ViewModels
{
    public class DeleteTodoItemPage : CustomAlertPage
    {
        public DeleteTodoItemPage(TodoItem item, string okButtonText, string cancelButtonText)
        {
            var grid = CustomAlertPage.GridConfiguration();

            var titleLabel = new Label
            {
                Text = $"Deseja realmente excluir a Tarefa {item.Title}?",
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(50, 200, 0, 50),
                TextColor = Color.Parse("White")
            };

            var okButton = FactoryButtonOk(okButtonText, "DarkOrange", LayoutOptions.End, 150);
            var cancelButton = FactoryButtonCancel(cancelButtonText, "Gray", LayoutOptions.Start);

            grid.Add(titleLabel, 1, 2);
            grid.Add(cancelButton, 0, 3);
            grid.Add(okButton, 2, 3);

            Content = grid;
        }
    }
}
