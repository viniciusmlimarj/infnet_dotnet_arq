using MediatR;
using Tasks.Application.Board.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Board.Handler.Commands
{
    public class GetAllBoardsQueryCommand : IRequest<GetAllBoardsQueryCommandResponse>
    {

    }

    public class GetAllBoardsQueryCommandResponse
    {
        public List<BoardOutputDto> Boards { get; set; }

        public GetAllBoardsQueryCommandResponse()
        {

        }

        public GetAllBoardsQueryCommandResponse(List<BoardOutputDto> tasks)
        {
            Boards = tasks;
        }
    }
}
