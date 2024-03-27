using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
	public class EFCoreContext : DbContext
	{
		private const string connectString = "Server=localhost;Database=efcore_test;User Id=sa;Password=s55660513;TrustServerCertificate=True;";

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectString);
		}

        public DbSet<Product> Products { get; set; }


    }
}
