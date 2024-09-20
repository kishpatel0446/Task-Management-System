namespace TaskManagementSystem.Models.Entities
{
    // Represents a single work item in the task management system
    public class Work
    {
        // Unique identifier for the work item
        public int Id { get; set; }

        // Title of the work item
        public string Title { get; set; }

        // Description of the work item
        public string Description { get; set; }

        // Due date of the work item
        public DateOnly DueDate { get; set; }

        // Status of the work item (e.g. "Pending", "Completed")
        public string Status { get; set; }
    }
}