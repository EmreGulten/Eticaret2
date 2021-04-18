using System;
using System.Collections.Generic;
using System.Text;
using API.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DataContext
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions db):base(db)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
