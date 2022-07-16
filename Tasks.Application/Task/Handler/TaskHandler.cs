using MediatR;
using Tasks.Application.Task.Handler.Commands;
using Tasks.Application.Task.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Task.Handler
{
    public class TaskHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>,
                                IRequestHandler<GetAllTasksQueryCommand, GetAllTasksQueryCommandResponse>
    {
        private ITaskServices taskService;

        public TaskHandler(ITaskServices taskService)
        {
            this.taskService = taskService;
        }


        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.taskService.Create(request.Task);

            return new CreateTaskCommandResponse(dto);
        }

        public async Task<GetAllTasksQueryCommandResponse> Handle(GetAllTasksQueryCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.taskService.GetAll();

            return new GetAllTasksQueryCommandResponse(dto);
        }
    }
}
