using TaskManagerX.ViewModels;

namespace TaskManagerX.Views;

public partial class RegisterItemView : ContentPage
{
    public RegisterItemView(TodoItemsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}