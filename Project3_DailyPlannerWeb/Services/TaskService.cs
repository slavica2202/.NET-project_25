using Project3_DailyPlannerWeb.Models;

namespace Project3_DailyPlannerWeb.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();

        // Get all tasks
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        // Add a task
        public void AddTask(TaskItem task)
        {
            _tasks.Add(task);
        }

        // Toggle task completion status (mark as done or undone)
        public void ToggleTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsDone = !task.IsDone;
            }
        }

        // Save tasks (This method could be useful if you want to store them persistently later)
        public void SaveTasks(List<TaskItem> tasks)
        {
            _tasks = tasks; // Save the tasks list (for now, this is in-memory)
        }
    }
}
