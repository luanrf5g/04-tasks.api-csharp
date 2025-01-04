using System;
using Tasks.Application.Services;
using Task = Tasks.Communication.Entities.Task;

namespace Tasks.Application.UseCases.Tasks;

public class DetailsTaskUseCase(TasksServices tasksServices)
{
  private readonly TasksServices _tasksServices = tasksServices;

  public Task Execute(int id)
  {
    var task = _tasksServices.GetTaskById(id) ?? throw new Exception("Task not found");

    return task;
  }
}
