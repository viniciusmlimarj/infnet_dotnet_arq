using MediatR;
using Tasks.Application.Task.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Task.Handler.Commands
{
    public class CreateTaskCommand: IRequest<CreateTaskCommandResponse>
    {
        public TaskInputDto Task { get; set; }

        public CreateTaskCommand(TaskInputDto input)
        {
            Task = input;
        }

    }
}
