using Day25_ServiceBased_Task_Manager.Data;
using Day25_ServiceBased_Task_Manager.Models;
using Day25_ServiceBased_Task_Manager.Services;
using Microsoft.EntityFrameworkCore;

public class TaskServiceTests
{
    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public void AddTask_Should_Add_Task_To_Database()
    {
        // Arrange

        var context = GetDbContext();

        var service = new TaskService(context);

        var task = new TaskItem
        {
            Title = "Learn Unit Testing",
            Description = "Practice xUnit",
            DueDate = DateTime.Today,
            IsCompleted = false
        };

        // Act

        service.Add(task);

        // Assert

        Assert.Single(context.TaskItems);

        Assert.Equal("Learn Unit Testing",
                     context.TaskItems.First().Title);
    }
    [Fact]
    public void GetTask_Should_Return_Task_By_Id()
    {
        // Arrange

        var context = GetDbContext();

        var service = new TaskService(context);

        var task = new TaskItem
        {
            Title = "Learn ASP.NET Core",
            Description = "Practice Service Layer",
            DueDate = DateTime.Today,
            IsCompleted = false
        };

        context.TaskItems.Add(task);
        context.SaveChanges();

        // Act

        var result = service.GetById(task.Id);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(task.Id, result.Id);
        Assert.Equal("Learn ASP.NET Core", result.Title);
    }
    [Fact]
    public void UpdateTask_Should_Update_Task()
    {
        // Arrange

        var context = GetDbContext();

        var service = new TaskService(context);

        var task = new TaskItem
        {
            Title = "Old Title",
            Description = "Old Description",
            DueDate = DateTime.Today,
            IsCompleted = false
        };

        context.TaskItems.Add(task);
        context.SaveChanges();

        // Change Data

        task.Title = "New Title";
        task.Description = "Updated Description";
        task.IsCompleted = true;

        // Act

        service.Update(task);

        // Assert

        var updatedTask = context.TaskItems.Find(task.Id);

        Assert.NotNull(updatedTask);
        Assert.Equal("New Title", updatedTask.Title);
        Assert.Equal("Updated Description", updatedTask.Description);
        Assert.True(updatedTask.IsCompleted);
    }
    [Fact]
    public void DeleteTask_Should_Remove_Task()
    {
        // Arrange

        var context = GetDbContext();

        var service = new TaskService(context);

        var task = new TaskItem
        {
            Title = "Delete Me",
            Description = "Task to be deleted",
            DueDate = DateTime.Today,
            IsCompleted = false
        };

        context.TaskItems.Add(task);
        context.SaveChanges();

        // Act

        service.Delete(task.Id);

        // Assert

        var deletedTask = context.TaskItems.Find(task.Id);

        Assert.Null(deletedTask);
        Assert.Empty(context.TaskItems);
    }
}

