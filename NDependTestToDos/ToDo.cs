using System;
using System.ComponentModel.DataAnnotations;

namespace NDependTestToDos
{
    public class ToDo
    {
        public int ToDoID { get; set; }
        [StringLength(150)]
        public string Text { get; set; }
        public string AdditionalDetails { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompleteBy { get; set; }
        public ToDoPriority ToDoPriority { get; set; }
        public int? ToDoCategoryID { get; set; }
        public virtual ToDoCategory ToDoCategory { get; set; }
    }
}
