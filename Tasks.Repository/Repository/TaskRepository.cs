using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Task.Repository;
using Tasks.Infrastructure.Database;
using Tasks.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Repository.Repository
{
    public class TaskRepository : Repository<Domain.Task.Task>, ITaskRepository
    {
        public TaskRepository(TasksContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Domain.Task.Task>> GetAllByBoard(Guid id)
        {
            return (IEnumerable<Domain.Task.Task>) await this.FindOneByCriteria(x => x.Board.Id == id);
        }

        public async Task<IEnumerable<Domain.Task.Task>> GetAllByUser(Guid id)
        {
            return (IEnumerable<Domain.Task.Task>) await this.FindOneByCriteria(x => x.AssignedTo.Id == id);
        }
    }
}
