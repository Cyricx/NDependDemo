using NDependTestToDos;
using System.Data.Entity;

namespace NDependTestDAL
{
    public class MyContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }

        public MyContext() : base("DefaultConnection") { }
    }
}
