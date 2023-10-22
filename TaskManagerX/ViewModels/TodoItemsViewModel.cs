using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManagerX.Infra.Data.Repositories;
using TaskManagerX.Models;

namespace TaskManagerX.ViewModels
{
    public partial class TodoItemsViewModel : ObservableObject
    {
        private readonly ITodoItemRepository _repository;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        ObservableCollection<TodoItem> todoItems;

        public TodoItemsViewModel(ITodoItemRepository repository)
        {
            _repository = repository;
            TodoItems = new ObservableCollection<TodoItem>(_repository.GetAllItems());
        }

        [ICommand]
        private void Add()
        {
            if (string.IsNullOrWhiteSpace(Title))
                return;

            var todoItem = new TodoItem(Title, Description);

            todoItems.Add(todoItem);
            _repository.AddItem(todoItem);
            ClearFields();
        }

        [ICommand]
        private async Task ShowTodoItem(TodoItem item)
        {
            var showTodoItem = new ShowTodoItemPage(item);
            await Application.Current.MainPage.Navigation.PushModalAsync(showTodoItem);
        }

        [ICommand]
        private async Task Delete(TodoItem item)
        {
            var alertPage = new DeleteTodoItemPage(item, "OK", "Cancelar");

            alertPage.OkClicked += (sender, e) =>
            {
                _repository.DeleteItem(item);
                TodoItems.Remove(item);
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(alertPage);
        }


        [ICommand]
        private void Update(TodoItem item)
        {
            item.IsCompleted = !item.IsCompleted;
            _repository.UpdateItem(item);
            UpdatesTheViewList(item);
        }

        private void UpdatesTheViewList(TodoItem item)
        {
            var index = TodoItems.IndexOf(item);
            if (index >= 0)
                TodoItems[index] = item;
        }

        private void ClearFields()
        {
            Description = string.Empty;
            Title = string.Empty;
        }
    }
}
