using Microsoft.EntityFrameworkCore;
using SpotifyLite.Domain.User;
using SpotifyLite.Domain.User.Repository;
using SpotifyLite.Infrastructure.Database;
using SpotifyLite.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SpotifyContext context) : base(context)
        {

        }

        public async Task<User> GetUserByPassword(string username, string password)
        {
            return await this.FindOneByCriteria(x => x.Email.Value == username 
                                                  && x.Password.Value == password);
        }
    }
}
