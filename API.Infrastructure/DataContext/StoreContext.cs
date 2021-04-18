using System;
using System.Collections.Generic;
using System.Text;
using API.Core.DbModels;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.DataContext
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions db):base(db)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
