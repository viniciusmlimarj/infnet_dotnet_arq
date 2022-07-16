using Tasks.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Domain.Board.Repository
{
    public interface IBoardRepository : IRepository<Board>
    {
        Task<IEnumerable<Board>> GetAllBoard();
    }
}
