using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemConsoler.BLL.Models;

namespace SystemConsoler.BLL.Context
{
    public partial class ConsolerContext : DbContext
    {
        public ConsolerContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<User> Users { get; set; }

    }
}
