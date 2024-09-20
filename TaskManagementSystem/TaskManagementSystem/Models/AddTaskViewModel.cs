namespace TaskManagementSystem.Models
{
    // View model for adding a new task
    public class AddTaskViewModel
    {
        // Title of the task
        public string Title { get; set; }

        // Description of the task
        public string Description { get; set; }

        // Due date of the task
        public DateOnly DueDate { get; set; }

        // Status of the task (e.g. "Pending", "Completed")
        public string Status { get; set; }
    }
}