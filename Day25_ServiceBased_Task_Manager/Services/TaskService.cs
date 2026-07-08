using Day25_ServiceBased_Task_Manager.Data;
using Day25_ServiceBased_Task_Manager.Models;

namespace Day25_ServiceBased_Task_Manager.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(TaskItem task)
        {
            _context.TaskItems.Add(task);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }

        public TaskItem? GetById(int id)
        {
            return _context.TaskItems.FirstOrDefault(t => t.Id == id);
        }

        public void Update(TaskItem task)
        {
            _context.TaskItems.Update(task);
            _context.SaveChanges();
        }
    }
}
