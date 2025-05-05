namespace KanbanBoardApp
{
    public class Task
    {
        public string TaskId { get; set; }
        public string TaskDescription { get; set; }

        public Task(string taskId, string taskDescription)
        {
            TaskId = taskId;
            TaskDescription = taskDescription;
        }
    }
}
