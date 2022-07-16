using MediatR;
using Tasks.Application.Task.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Task.Handler.Commands
{
    public class GetAllTasksQueryCommand : IRequest<GetAllTasksQueryCommandResponse>
    {

    }

    public class GetAllTasksQueryCommandResponse
    {
        public List<TaskOutputDto> Tasks { get; set; }

        public GetAllTasksQueryCommandResponse()
        {

        }

        public GetAllTasksQueryCommandResponse(List<TaskOutputDto> tasks)
        {
            Tasks = tasks;
        }
    }
}
