using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.EntityFrameworkCore
{
    public class FreePOSRepo :IFreePOSRepo
    {
        private readonly DbContextOptions<FreePOSContext> _dbOptions;

        public FreePOSRepo(DbContextOptionsBuilder<FreePOSContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new FreePOSContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public IUserRepo Users => new UserRepo(
            new FreePOSContext(_dbOptions));

    }
}
