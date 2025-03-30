using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task1.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base("name=EmployeeDB")
		{

		}
		public DbSet<Employee> Employees { get; set; }

	}
}