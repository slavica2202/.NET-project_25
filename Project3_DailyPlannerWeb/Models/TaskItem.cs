namespace Project3_DailyPlannerWeb.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }
}
