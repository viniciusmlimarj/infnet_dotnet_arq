using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Board.Dto;
using Tasks.Application.Board.Handler.Commands;
using Tasks.Domain.Board;
using Tasks.Domain.Board.Repository;
using Tasks.Infrastructure.Database;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "user-policy")]
    public class BoardController : ControllerBase
    {
        public IMediator Handler { get; }

        public BoardController(IMediator handler)
        {
            Handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BoardInputDto inputDto)
        {
            var result = await this.Handler.Send(new CreateBoardCommand(inputDto));

            return Created($"/{result.Board.Id}", result.Board);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Handler.Send(new GetAllBoardsQueryCommand());

            return Ok(result.Boards);
        }

    }
}
