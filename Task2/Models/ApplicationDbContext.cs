using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task2.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base("name=EmployeeDB")
		{

		}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}