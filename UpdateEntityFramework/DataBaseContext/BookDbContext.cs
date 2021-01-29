using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateEntityFramework.Mdels;

namespace UpdateEntityFramework.DataBaseContext
{
    public class BookDbContext:DbContext
    {
        public BookDbContext() : base("Test") { }
        public DbSet <Book> Books { get; set; }
        public DbSet<Janr> Janrs { get; set; }
    }
}
