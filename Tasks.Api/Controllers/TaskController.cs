using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Task.Dto;
using Tasks.Application.Task.Handler.Commands;
using Tasks.Domain.Task;
using Tasks.Domain.Task.Repository;
using Tasks.Infrastructure.Database;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "user-policy")]
    public class TaskController : ControllerBase
    {
        public IMediator Handler { get; }

        public TaskController(IMediator handler)
        {
            Handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskInputDto inputDto)
        {
            var result = await this.Handler.Send(new CreateTaskCommand(inputDto));

            return Created($"/{result.Task.Id}", result.Task);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Handler.Send(new GetAllTasksQueryCommand());

            return Ok(result.Tasks);
        }

    }
}
