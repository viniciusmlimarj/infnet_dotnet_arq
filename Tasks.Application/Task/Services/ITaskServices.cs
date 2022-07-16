using Tasks.Application.Task.Dto;

namespace Tasks.Application.Task.Services
{
    public interface ITaskServices
    {
        Task<TaskOutputDto> Create(TaskInputDto dto);
        Task<List<TaskOutputDto>> GetAll();
    }
}