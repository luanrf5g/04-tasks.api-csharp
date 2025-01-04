using Tasks.Application.Services;
using Tasks.Communication.Requests;
using Task = Tasks.Communication.Entities.Task;

namespace Tasks.Application.UseCases.Tasks;

public class CreateTaskUseCase(TasksServices tasksServices)
{
  private readonly TasksServices _tasksServices = tasksServices;

  public Task Execute(RequestCreateTaskJson request)
  {
    var task = new Task
    {
      Id = _tasksServices.GetTasks().Count + 1,
      Title = request.Title,
      Description = request.Description,
      LimitTime = request.LimitTime,
      Status = request.Status,
      Priority = request.Priority
    };

    _tasksServices.AddTask(task);

    return task;
  }
}
