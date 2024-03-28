
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.Configuration;


//Console.WriteLine("start insert");
//Console.WriteLine("start read");
Console.WriteLine("start program");
//generic function find by name
ShowDepartmentDetail(d => d.Name == "Cat");
//generic function find by id
ShowDepartmentDetail(d => d.Id == 1);
UpdateDepartmentById(1);
UpdateDepartmentByName("Pig");
//UpdateDepartment(d => d.Name == "Human", "AAA", "raise AAA");
UpdateEntity<Product>(p => p.Id == 6, p =>
{
	p.Name = "Latop";
});

UpdateEntity<Department>(d => d.Name == "Zebra", d =>
{
	d.Name = "Shark";
	d.Description = "raise Shark";
}
	);


UpdateEntity<Department>(d => d.Name == "AAA", d =>
{
	d.Name = "Zebra";
	d.Description = "raise Zebra";
});
var products = new List<Product>();
products.Add(new Product
{
	Id = 1,
	Name = "AA"
});
products.Add(new Product
{
	Id = 2,
	Name = "BB"
});
products.Add(new Product
{
	Id = 3,
	Name = "CC"
});

products.Add(new Product
{
	Id = 4,
	Name = "DD"
});
products.Add(new Product
{
	Id = 5,
	Name = "EE"
});

UpdateMultipleProducts(products);



static void insertProductData()
{
	using (var db = new EFCoreContext())
	{
		//insert data
		var product = new Product();
		product.Name = "Apple";
		db.Add(product);

		var product1 = new Product();
		product1.Name = "Banana";
		db.Add(product1);

		var product2 = new Product();
		product2.Name = "Computer";
		db.Add(product1);

		var product3 = new Product();
		product3.Name = "Grape";
		db.Add(product1);

		db.SaveChanges();
	}
}

//add range
static void insertDepartmentData()
{
	using (var db = new EFCoreContext())
	{
		List<Department> departments = new List<Department>();
		var department1 = new Department
		{
			Name = "Dog",
			Description = "raise Dog"
		};
		var department2 = new Department
		{
			Name = "Cat",
			Description = "raise Cat"
		};
		departments.Add(department1);
		departments.Add(department2);
		db.AddRange(departments);
		db.SaveChanges();
	}
}

static void showDepartmentDetailById(int id) //find by id
{
	using (var db = new EFCoreContext())
	{
		//var targetDepartment = db.Departments.Find(id);
		var targetDepartment = db.Departments.Where(d => d.Id == id).First();
		if (targetDepartment != null)
		{
			Console.WriteLine($"Dep. name {targetDepartment.Name}. do {targetDepartment.Description}");
		}
	}
}
static void showDepartmentDetailByName(string depName) //find by name
{
	using (var db = new EFCoreContext())
	{
		var targetDepartment = db.Departments.Where(d => d.Name == depName).First();
		if (targetDepartment != null)
		{
			Console.WriteLine($"Dep. name {targetDepartment.Name}. do {targetDepartment.Description}");
		}
	}
}


//generic funtion to Update 
static void UpdateEntity<T>(Func<T, bool> predicate, Action<T> action) where T : class
{
	using (var db = new EFCoreContext())
	{
		var entity = db.Set<T>().FirstOrDefault(predicate);
		if (entity != null)
		{
			action(entity);
			db.SaveChanges();
		}
	}
}

static void UpdateMultipleProducts(List<Product> products)
{
	using (EFCoreContext db = new EFCoreContext())
	{
		foreach (var item in products)
		{
			var product = db.Products.Where(p => p.Id == item.Id).FirstOrDefault();
			if (product != null) { product.Name = item.Name; }

		}
		db.SaveChanges();
	}
}



static void ShowDepartmentDetail(Func<Department, bool> predicate)
{
	using (var db = new EFCoreContext())
	{
		var targetDepartment = db.Departments.FirstOrDefault(predicate);
		if (targetDepartment != null)
		{
			Console.WriteLine($"Dep. name {targetDepartment.Name}. do {targetDepartment.Description}");
		}
	}
}


static void UpdateDepartment(Func<Department, bool> predicate, string name, string description)
{
	using (var db = new EFCoreContext())
	{
		var targetDepartment = db.Departments.FirstOrDefault(predicate);
		if (targetDepartment != null)
		{
			targetDepartment.Name = name;
			targetDepartment.Description = description;
			db.SaveChanges();
		}
	}
}

static void UpdateDepartmentById(int id)
{
	using (var db = new EFCoreContext())
	{
		var department = db.Departments.Where(d => d.Id == id).FirstOrDefault();
		if (department != null)
		{
			department.Name = "Pig";
			department.Description = "raise Pig";
			db.SaveChanges();
		}
	}
}
static void UpdateDepartmentByName(string name)
{
	using (var db = new EFCoreContext())
	{
		var department = db.Departments.Where(d => d.Name == name).FirstOrDefault();
		if (department != null)
		{
			department.Name = "Fish";
			department.Description = "raise Fish";
			db.SaveChanges();
		}
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

static void deleteData(int id)
{
	using (var db = new EFCoreContext())
	{
		Product product = db.Products.Find(id);
		db.Products.Remove(product);
		db.SaveChanges();
	}
}

