using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagerPeople.Models;

namespace ManagerPeople.Data
{
    public class ManagerPeopleContext : DbContext
    {
        public ManagerPeopleContext (DbContextOptions<ManagerPeopleContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
