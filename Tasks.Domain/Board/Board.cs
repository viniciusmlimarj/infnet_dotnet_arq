using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Domain.Board
{
    public class Board
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public virtual IList<Task.Task> Tasks { get; set; }
        
    }
}
