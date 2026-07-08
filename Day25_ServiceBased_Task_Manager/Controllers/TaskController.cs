using Day25_ServiceBased_Task_Manager.Models;
using Day25_ServiceBased_Task_Manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day25_ServiceBased_Task_Manager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            var tasks = _taskService.GetAll();
            return View(tasks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if(ModelState.IsValid)
            {
                _taskService.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
        public IActionResult Edit(int id)
        {
            var task = _taskService.GetById(id);

            if(task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem task)
        {
            if(ModelState.IsValid)
            {
                _taskService.Update(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
        public IActionResult Delete(int id)
        {
            var task = _taskService.GetById(id);

            if(task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
