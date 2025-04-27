using System.Collections.Generic;

namespace KanbanBoardApp
{
    public class KanbanBoard
    {
        public List<Task> ToDo { get; set; }
        public List<Task> InProgress { get; set; }
        public List<Task> Done { get; set; }

        public KanbanBoard()
        {
            ToDo = new List<Task>();
            InProgress = new List<Task>();
            Done = new List<Task>();
        }
    }
}
