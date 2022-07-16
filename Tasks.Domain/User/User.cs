using FluentValidation;
using Tasks.Domain.User.Rules;
using Tasks.Domain.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Task;

namespace Tasks.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public CPF CPF { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public virtual IList<Board.Board> Boards { get; set; }
        public virtual IList<Task.Task> Tasks { get; set; }

        public void Validate() => new UserValidator().ValidateAndThrow(this);
    }
}
