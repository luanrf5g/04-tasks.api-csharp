using System;
using Task = Tasks.Communication.Entities.Task;

namespace Tasks.Application.Services;

public class TasksServices
{
  public readonly List<Task> _tasks = [];

  public List<Task> GetTasks() => _tasks;

  public void AddTask(Task task)
  {
    _tasks.Add(task);
  }
}
