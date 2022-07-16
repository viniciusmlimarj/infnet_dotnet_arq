using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Domain.Board.Repository;
using Tasks.Application.Board.Dto;

namespace Tasks.Application.Board.Services
{
    internal class BoardServices : IBoardServices
    {
        private readonly IBoardRepository BoardRepository;
        private readonly IMapper mapper;

        public BoardServices(IBoardRepository BoardRepository, IMapper mapper)
        {
            this.BoardRepository = BoardRepository;
            this.mapper = mapper;
        }

        public async Task<BoardOutputDto> Create(BoardInputDto dto)
        {
            var Board = this.mapper.Map<Domain.Board.Board>(dto);

            await this.BoardRepository.Save(Board);

            return this.mapper.Map<BoardOutputDto>(Board);

        }

        public async Task<List<BoardOutputDto>> GetAll()
        {
            var Board = await this.BoardRepository.GetAllBoard();

            return this.mapper.Map<List<BoardOutputDto>>(Board);
        }
    }
}
