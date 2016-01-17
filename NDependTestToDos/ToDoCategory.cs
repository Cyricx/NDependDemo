using System.Collections.Generic;

namespace NDependTestToDos
{
    public class ToDoCategory
    {
        public int ToDoCategoryID { get; set; }
        public string ToDoCategoryName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
