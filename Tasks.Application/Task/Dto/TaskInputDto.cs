using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Board.Dto;

namespace Tasks.Application.Task.Dto
{
    public record TaskInputDto(string Title, string Description, Boolean Done, UserInputDto user, BoardInputDto board);

}