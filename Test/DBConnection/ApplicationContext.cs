using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Project_Requirements.Models;

namespace Test_Project_Requirements.DBConnection
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<HistorySale> HistorySales { get; set; }
    }
}
