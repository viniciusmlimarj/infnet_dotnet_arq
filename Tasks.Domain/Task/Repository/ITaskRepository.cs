using Tasks.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Domain.Task.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {

        Task<IEnumerable<Domain.Task.Task>> GetAllByBoard(Guid id);

        Task<IEnumerable<Domain.Task.Task>> GetAllByUser(Guid id);
    }
}
