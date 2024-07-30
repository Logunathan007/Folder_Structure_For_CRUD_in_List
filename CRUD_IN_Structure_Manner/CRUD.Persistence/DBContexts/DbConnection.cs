
using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD.Persistence.DBContexts
{
    public class DbConnection : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbConnection(DbContextOptions options) : base(options)
        {
            Console.WriteLine("Logunathan");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
