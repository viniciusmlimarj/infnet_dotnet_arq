using Microsoft.EntityFrameworkCore;
using Tasks.Domain.User;
using Tasks.Domain.User.Repository;
using Tasks.Infrastructure.Database;
using Tasks.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TasksContext context) : base(context)
        {

        }

        public async Task<User> GetUserByPassword(string username, string password)
        {
            return await this.FindOneByCriteria(x => x.Email.Value == username 
                                                  && x.Password.Value == password);
        }
    }
}
