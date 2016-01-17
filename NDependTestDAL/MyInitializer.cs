using NDependTestToDos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDependTestDAL
{
    public class MyInitializer : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var todoCategories = new List<ToDoCategory>
            {
                new ToDoCategory { ToDoCategoryName = "MMA", IsActive = true },
                new ToDoCategory { ToDoCategoryName = "Errands", IsActive = true },
                new ToDoCategory { ToDoCategoryName = "Chores", IsActive = true }
            };
            todoCategories.ForEach(x => context.ToDoCategories.Add(x));
            context.SaveChanges();

            var todos = new List<ToDo>
            {
                new ToDo { Text = "Kick butt", IsComplete = false, ToDoCategoryID = 1 },
                new ToDo { Text = "Take names", ToDoCategoryID = 1 },
                new ToDo { Text = "Eat a Kit-Kat", ToDoCategoryID = 3 },
                new ToDo { Text = "Order more pizza!", ToDoCategoryID = 2}
            };
            todos.ForEach(x => context.ToDos.Add(x));
            context.SaveChanges();

            base.Seed(context);
        }
    }

}
