using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Entities;

namespace TaskManagementSystem.Controllers
{
    public class TasksController : Controller
    {
        // Dependency injection of the TaskDbContext
        private readonly TaskDbContext dbContext;

        public TasksController(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Add
        [HttpGet]
        public IActionResult Add()
        {
            // Return the Add view
            return View();
        }

        // POST: Add
        [HttpPost]
        public async Task<IActionResult> Add(AddTaskViewModel viewModel)
        {
            // Create a new Work entity from the view model
            var task = new Work
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                DueDate = viewModel.DueDate,
                Status = viewModel.Status
            };

            // Add the task to the database
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            // Redirect to the List action
            return RedirectToAction("List", "Tasks");
        }

        // GET: List
        [HttpGet]
        public async Task<IActionResult> List(string searchTerm, string status)
        {
            // Get the tasks from the database
            var tasks = dbContext.Tasks.AsQueryable();

            // Filter tasks by search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                tasks = tasks.Where(t => t.Title.Contains(searchTerm) || t.Description.Contains(searchTerm));
            }

            // Filter tasks by status
            if (!string.IsNullOrEmpty(status))
            {
                tasks = tasks.Where(t => t.Status == status);
            }

            // Get the list of tasks
            var taskList = await tasks.ToListAsync();

            // Set the view bag with search term and status
            ViewBag.SearchTerm = searchTerm;
            ViewBag.Status = status;

            // Return the List view
            return View(taskList);
        }

        // GET: Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            // Get the task from the database
            var task = await dbContext.Tasks.FindAsync(Id);

            // Return the Edit view
            return View(task);
        }

        // POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Work viewModel)
        {
            // Get the task from the database
            var task = await dbContext.Tasks.FindAsync(viewModel.Id);

            if (task != null)
            {
                // Update the task properties
                task.Title = viewModel.Title;
                task.Description = viewModel.Description;
                task.DueDate = viewModel.DueDate;
                task.Status = viewModel.Status;

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // Redirect to the List action
            return RedirectToAction("List", "Tasks");
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Get the task from the database
            var task = await dbContext.Tasks.FindAsync(id);

            if (task != null)
            {
                // Remove the task from the database
                dbContext.Tasks.Remove(task);
                await dbContext.SaveChangesAsync();
            }

            // Redirect to the List action
            return RedirectToAction("List", "Tasks");
        }

        // POST: MarkAsCompleted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            // Get the task from the database
            var task = await dbContext.Tasks.FindAsync(id);

            if (task != null)
            {
                // Update the task status
                task.Status = "Completed";
                await dbContext.SaveChangesAsync();
            }

            // Redirect to the List action
            return RedirectToAction("List", "Tasks");
        }
    }
}