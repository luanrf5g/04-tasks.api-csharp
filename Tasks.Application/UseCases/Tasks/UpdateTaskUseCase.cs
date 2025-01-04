using System;
using Tasks.Application.Services;
using Tasks.Communication.Requests;
using Task = Tasks.Communication.Entities.Task;

namespace Tasks.Application.UseCases.Tasks;

public class UpdateTaskUseCase(TasksServices tasksServices)
{
  private readonly TasksServices _tasksServices = tasksServices;

  public Task Execute(RequestUpdateTaskJson request, int id)
  {
    var task = _tasksServices.GetTaskById(id) ?? throw new Exception("Task not found");

    task.Title = request.Title;
    task.Description = request.Description;
    task.Priority = request.Priority;
    task.Status = request.Status;

    _tasksServices._tasks[task.Id - 1] = task;

    return task;
  }
}
