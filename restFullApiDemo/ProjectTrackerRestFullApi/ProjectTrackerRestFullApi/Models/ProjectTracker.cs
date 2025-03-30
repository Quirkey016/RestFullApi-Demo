namespace ProjectTrackerRestFullApi.Models
{
    public class ProjectTracker
    {
        public int Id { get; set; }
        public int projectNumber { get; set; }
        public string? projectName { get; set; }
        public decimal completionPercent { get; set; }
    }
}
