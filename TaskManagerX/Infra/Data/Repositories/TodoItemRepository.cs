using SQLite;
using TaskManagerX.Models;

namespace TaskManagerX.Infra.Data.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        SQLiteConnection Database;

        public TodoItemRepository() { }

        void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Database.CreateTable<TodoItem>();
        }

        public void AddItem(TodoItem item)
        {
            Init();
            Database.Insert(item);
        }

        public void DeleteItem(TodoItem item)
        {
            Init();
            Database.Delete(item);
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            Init();
            return Database.Table<TodoItem>().ToList();
        }


        public TodoItem GetItemById(int id)
        {
            Init();
            return Database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefault();
        }

        public void UpdateItem(TodoItem item)
        {
            Init();
            if (ItemExistsByTitle(item.Title, item.Id))
                Database.Update(item);
        }

        private bool ItemExistsByTitle(string title, int? itemId = null)
        {
            Init();
            return Database.Table<TodoItem>()
                .ToList()
                .Any(i => i.Title == title && i.Id == itemId);
        }
    }
}
