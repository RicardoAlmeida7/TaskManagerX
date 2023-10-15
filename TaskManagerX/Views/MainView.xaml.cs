using Microsoft.Maui.Controls;
using TaskManagerX.ViewModels;

namespace TaskManagerX.Views;

public partial class MainView : ContentPage
{
    public MainView(TodoItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
