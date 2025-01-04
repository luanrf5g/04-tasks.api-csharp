using System;
using Tasks.Application.Services;

namespace Tasks.Application.UseCases.Tasks;

public class DeleteTaskUseCase(TasksServices tasksServices)
{
  private readonly TasksServices _tasksServices = tasksServices;

  public void Execute(int id)
  {
    var task = _tasksServices.GetTaskById(id) ?? null;

    if (task != null)
    {
      _tasksServices._tasks.Remove(task);
    }
  }
}
