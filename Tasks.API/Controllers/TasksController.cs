using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Services;
using Tasks.Application.UseCases.Tasks;
using Tasks.Communication.Requests;
using Tasks.Communication.Responses;
using Task = Tasks.Communication.Entities.Task;

namespace Tasks.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(TasksServices tasksServices) : ControllerBase
    {
        private readonly TasksServices _tasksServices = tasksServices;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateTask([FromBody] RequestCreateTaskJson request)
        {
            var createTask = new CreateTaskUseCase(_tasksServices);
            var task = createTask.Execute(request);

            return Created(string.Empty, task);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseFetchTasksJson), StatusCodes.Status200OK)]
        public IActionResult FetchTasks()
        {
            var useCase = new FetchTasksUseCase(_tasksServices);
            var response = useCase.Execute();

            return Ok(response);
        }
    }
}
