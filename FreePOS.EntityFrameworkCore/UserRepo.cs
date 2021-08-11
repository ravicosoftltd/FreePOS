using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FreePOS.EntityFrameworkCore
{
    public class UserRepo :IUserRepo
    {
        private readonly FreePOSContext _db;
        public UserRepo(FreePOSContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _db.Users
                .ToListAsync();
        }
    }
}
