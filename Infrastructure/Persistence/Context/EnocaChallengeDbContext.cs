using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class EnocaChallengeDbContext : DbContext
    {
        public EnocaChallengeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products  { get; set; }
       
    }
}
