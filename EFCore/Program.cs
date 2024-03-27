
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

//Console.WriteLine("start insert");
//Console.WriteLine("start read");
Console.WriteLine("start update");
updateProduct(1);
updateProduct(2);


static void insertdata()
{
	using (var db = new EFCoreContext())
	{
		//insert data
		Product product = new Product();
		product.Name = "Casey Yang";
		db.Add(product);

		var product1 = new Product();
		product1.Name = "Dong Yang";
		db.Add(product1);

		db.SaveChanges();
	}
}



static void readdata()
{
	using (var db = new EFCoreContext())
	{

		List<Product> products = db.Products.ToList();
		foreach (var p in products)
		{
			Console.WriteLine("{0} {1}", p.Id, p.Name);
		}

	}
}

static void updateProduct(int id)
{
	using (var db = new EFCoreContext())
	{
		Product product = db.Products.FirstOrDefault(p => p.Id == id);
		if (product != null)
		{
			// Update the product's name
			product.Name = "Better Pen Drive" + id.ToString() + id.ToString();

			// Save changes to the database
			db.SaveChanges();
		}
	}
	return;
}



