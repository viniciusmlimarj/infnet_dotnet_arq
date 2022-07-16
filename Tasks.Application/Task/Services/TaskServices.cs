using AutoMapper;
using Tasks.Application.Task.Dto;
using Tasks.Domain.Task.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tasks.Application.Task.Services
{
    internal class TaskServices : ITaskServices
    {
        private readonly ITaskRepository TaskRepository;
        private readonly IMapper mapper;

        public TaskServices(ITaskRepository TaskRepository, IMapper mapper)
        {
            this.TaskRepository = TaskRepository;
            this.mapper = mapper;
        }

        public async Task<TaskOutputDto> Create(TaskInputDto dto)
        {
            var Task = this.mapper.Map<Domain.Task.Task>(dto);

            await this.TaskRepository.Save(Task);

            return this.mapper.Map<TaskOutputDto>(Task);

        }

        public async Task<List<TaskOutputDto>> GetAll()
        {
            var Task = await this.TaskRepository.GetAll();

            return this.mapper.Map<List<TaskOutputDto>>(Task);
        }
    }
}
