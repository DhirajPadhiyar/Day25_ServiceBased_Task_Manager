using Day25_ServiceBased_Task_Manager.Models;

namespace Day25_ServiceBased_Task_Manager.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(int id);
        void Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(int id);
    }
}
