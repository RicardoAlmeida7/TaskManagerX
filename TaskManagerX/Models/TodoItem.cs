using SQLite;

namespace TaskManagerX.Models
{
    [Table("todo_item")]
    public class TodoItem
    {
        public TodoItem() { }

        public TodoItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(40), Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_completed")]
        public bool IsCompleted { get; set; }
    }
}
