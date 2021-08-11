using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.EntityFrameworkCore
{
    public interface IFreePOSRepo
    {
        IUserRepo Users { get; }
    }
}
