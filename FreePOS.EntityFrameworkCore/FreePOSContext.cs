using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.EntityFrameworkCore
{
    public class FreePOSContext : DbContext
    {
        public FreePOSContext(DbContextOptions<FreePOSContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;user=root;database=freepos;port=3306;password=brk@1234");
        //}
    }
}
