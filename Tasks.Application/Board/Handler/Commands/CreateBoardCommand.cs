using MediatR;
using Tasks.Application.Board.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Board.Handler.Commands
{
    public class CreateBoardCommand: IRequest<CreateBoardCommandResponse>
    {
        public BoardInputDto Board { get; set; }

        public CreateBoardCommand(BoardInputDto input)
        {
            Board = input;
        }

    }
}
