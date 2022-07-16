
using Tasks.Application.Board.Dto;

namespace Tasks.Application.Board.Services
{
    public interface IBoardServices
    {
        Task<BoardOutputDto> Create(BoardInputDto dto);
        Task<List<BoardOutputDto>> GetAll();
    }
}