using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3_DailyPlannerWeb.Models;
using Project3_DailyPlannerWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Project3_DailyPlannerWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskService _taskService;

        public IndexModel(TaskService taskService)
        {
            _taskService = taskService;
            NewTask = new TaskItem
            {
                Date = DateTime.Today // Set default date to today's date
            };
        }

        public List<TaskItem> Tasks { get; set; } = new();

        [BindProperty]
        public TaskItem NewTask { get; set; } = new TaskItem(); // fixed here 

        public void OnGet()
        {
            Tasks = _taskService.GetAllTasks();
        }

        public IActionResult OnPost()
        {
            var tasks = _taskService.GetAllTasks();
            NewTask.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            _taskService.AddTask(NewTask); // Use AddTask to add the task
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var tasks = _taskService.GetAllTasks();
            var taskToDelete = tasks.FirstOrDefault(t => t.Id == id);
            if (taskToDelete != null)
            {
                tasks.Remove(taskToDelete);
                // SaveTasks() should be removed unless you're actually using it in TaskService
                // _taskService.SaveTasks(tasks); 
            }
            return RedirectToPage();
        }
    }
}
