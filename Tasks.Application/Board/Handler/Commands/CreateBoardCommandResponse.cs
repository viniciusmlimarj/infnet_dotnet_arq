using Tasks.Application.Board.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Board.Handler.Commands
{
    public class CreateBoardCommandResponse
    {
        public BoardOutputDto Board { get; set; }

        public CreateBoardCommandResponse(BoardOutputDto output)
        {
            Board = output;
        }
    }
}
