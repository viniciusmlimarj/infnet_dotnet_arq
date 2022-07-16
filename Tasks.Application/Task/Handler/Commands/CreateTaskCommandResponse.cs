using Tasks.Application.Task.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Task.Handler.Commands
{
    public class CreateTaskCommandResponse
    {
        public TaskOutputDto Task { get; set; }

        public CreateTaskCommandResponse(TaskOutputDto output)
        {
            Task = output;
        }
    }
}
