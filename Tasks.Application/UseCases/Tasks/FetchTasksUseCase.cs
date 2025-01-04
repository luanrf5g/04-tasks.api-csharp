using System;
using Tasks.Application.Services;
using Tasks.Communication.Responses;
using Task = Tasks.Communication.Entities.Task;

namespace Tasks.Application.UseCases.Tasks;

public class FetchTasksUseCase(TasksServices tasksServices)
{
  private readonly TasksServices _tasksServices = tasksServices;
  public ResponseFetchTasksJson Execute()
  {
    var tasks = _tasksServices.GetTasks();
    var responseTasks = tasks.Select(task => new ResponseShortTaskJson
    {
      Title = task.Title,
      LimitTime = task.LimitTime,
      Priority = task.Priority,
    }).ToList();

    return new ResponseFetchTasksJson { Tasks = responseTasks };
  }
}
