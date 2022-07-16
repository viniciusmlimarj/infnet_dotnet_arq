using MediatR;
using Tasks.Application.Board.Handler.Commands;
using Tasks.Application.Board.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Board.Handler
{
    public class BoardHandler : IRequestHandler<CreateBoardCommand, CreateBoardCommandResponse>,
                                IRequestHandler<GetAllBoardsQueryCommand, GetAllBoardsQueryCommandResponse>
    {
        private IBoardServices boardService;

        public BoardHandler(IBoardServices boardService)
        {
            this.boardService = boardService;
        }


        public async Task<CreateBoardCommandResponse> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.boardService.Create(request.Board);

            return new CreateBoardCommandResponse(dto);
        }

        public async Task<GetAllBoardsQueryCommandResponse> Handle(GetAllBoardsQueryCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.boardService.GetAll();

            return new GetAllBoardsQueryCommandResponse(dto);
        }
    }
}
