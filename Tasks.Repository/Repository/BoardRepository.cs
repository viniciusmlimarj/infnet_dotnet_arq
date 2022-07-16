using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Board;
using Tasks.Domain.Board.Repository;
using Tasks.Infrastructure.Database;
using Tasks.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Repository.Repository
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        public BoardRepository(TasksContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Board>> GetAllBoard()
        {
            return await Task.FromResult(this._set.Include(x => x.Tasks).AsEnumerable());
        }
    }
}
