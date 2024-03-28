using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
	public class EFCoreContext : DbContext
	{
		private string connectString;

		public EFCoreContext() : base()
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("appsetting.json", optional: false);
			var configure = builder.Build();

			connectString = configure.GetConnectionString("SQLServerConnection").ToString();
		}
		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectString);
		}

		public DbSet<Product> Products { get; set; }

		//new talbe
		public DbSet<Department> Departments { get; set; }

	}
}
