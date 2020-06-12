using Microsoft.EntityFrameworkCore;
using SimplesCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesCrud.Database
{
    public class SimplesCrudContext : DbContext
    {
        public SimplesCrudContext(DbContextOptions<SimplesCrudContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
