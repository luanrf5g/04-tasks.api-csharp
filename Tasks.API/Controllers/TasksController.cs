using System.Reflection.Metadata.Ecma335;
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
        [ProducesResponseType(typeof(ResponseErrorsListJson), StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask([FromBody] RequestCreateTaskJson request)
        {
            var createTask = new CreateTaskUseCase(_tasksServices);
            var task = createTask.Execute(request);

            return Created(string.Empty, task);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseFetchTasksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsListJson), StatusCodes.Status204NoContent)]
        public IActionResult FetchTasks()
        {
            var fetchTasks = new FetchTasksUseCase(_tasksServices);
            var response = fetchTasks.Execute();

            if (response.Tasks.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Task), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsListJson), StatusCodes.Status404NotFound)]
        public IActionResult DetailsTask([FromRoute] int id)
        {
            var detailsTask = new DetailsTaskUseCase(_tasksServices);

            var response = detailsTask.Execute(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Task), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsListJson), StatusCodes.Status404NotFound)]
        public IActionResult UpdateTask([FromBody] RequestUpdateTaskJson request, [FromRoute] int id)
        {
            var updateTask = new UpdateTaskUseCase(_tasksServices);
            var response = updateTask.Execute(request, id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteTask([FromRoute] int id)
        {
            var deleteTask = new DeleteTaskUseCase(_tasksServices);
            deleteTask.Execute(id);

            return NoContent();
        }
    }
}
