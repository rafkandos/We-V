using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace wevi.Models
{
    public class WevDbContext : DbContext
    {
        public WevDbContext(DbContextOptions<WevDbContext> options) : base(options)
        {

        }

        //public DbSet<Admin> Admin { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<HistoryEvent> HistoryEvent { get; set; }
        public DbSet<HistoryProduct> HistoryProduct { get; set; }
    }
}
