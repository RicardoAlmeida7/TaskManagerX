using TaskManagerX.Models;

namespace TaskManagerX.Infra.Data.Repositories
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAllItems();

        TodoItem GetItemById(int id);

        void AddItem(TodoItem item);

        void UpdateItem(TodoItem item);

        void DeleteItem(TodoItem item);
    }
}
