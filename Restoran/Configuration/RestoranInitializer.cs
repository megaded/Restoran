using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Restoran;

namespace Restoran
{
    public class RestoranInitializer : DropCreateDatabaseAlways<RestoranContext>
    {
        protected override void Seed(RestoranContext context)
        {
            List<ProductCategory> categoryes = new List<ProductCategory>();
            for (int i = 1; i < 5; i++)
            {
                categoryes.Add(new ProductCategory { Name = $"Категория {i}" });
            }
            context.ProductCategory.AddRange(categoryes);

            Reason reason1 = new Reason() { Name = "Порча" };
            Reason reason2 = new Reason() { Name = "Питание персонала" };
            Reason reason3 = new Reason() { Name = "Проработка" };
            context.Reason.AddRange(new List<Reason>() { reason1, reason2, reason3 });
            context.SaveChanges();

            Unit UnitKg = new Unit() { Name = "Килограмм", Symbol = "Кг" };
            Unit UnitL = new Unit() { Name = "Литр", Symbol = "Л" };
            context.Unit.Add(UnitKg);
            context.Unit.Add(UnitL);
            context.SaveChanges();

            ProductCategory cat1 = new ProductCategory { Name = "Мясо" };
            ProductCategory cat2 = new ProductCategory { Name = "Молоко" };
            ProductCategory cat3 = new ProductCategory { Name = "Бакалея" };
            context.ProductCategory.Add(cat1);
            context.ProductCategory.Add(cat2);
            context.ProductCategory.Add(cat3);
            context.SaveChanges();

            List<Product> products = new List<Product>();
            Random random = new Random();
            for (int i = 1; i < 10; i++)
            {
                int indexUnit = random.Next(1, 3);
                int indexCat = random.Next(1, 5);
                products.Add(new Product { Name = $"Продукт {i}", UnitId = indexUnit, ProductCategoryId = indexCat });
            }
            context.Product.AddRange(products);

            Product p1 = new Product() { Name = "Молоко", ProductCategory = cat2, Unit = UnitL, Description = "Молоко коровье" };
            Product p2 = new Product() { Name = "Сахар", ProductCategory = cat3, Unit = UnitKg, Description = "Са́хар — бытовое название сахарозы. Тростниковый и свекловичный сахар является важным пищевым продуктом. Обычный сахар относится к углеводам, которые считаются ценными питательными веществами, обеспечивающими организм необходимой энергией." };
            Product p3 = new Product() { Name = "Баранина", ProductCategory = cat1, Unit = UnitKg };
            Product p4 = new Product() { Name = "Рис", ProductCategory = cat3, Unit = UnitKg };
            Product p5 = new Product() { Name = "Соль", ProductCategory = cat3, Unit = UnitKg, Description = "Пова́ренная соль, или соль пищевая, — пищевой продукт. В измельчённом виде представляет собой бесцветные кристаллы." };
            Product p6 = new Product() { Name = "Масло растительное", ProductCategory = cat3, Unit = UnitL };
            context.Product.AddRange(new List<Product> { p1, p2, p3, p4, p5, p6 });
            context.SaveChanges();

            Market market1 = new Market() { Name = "Рынок 1" };
            Market market2 = new Market() { Name = "Рынок 2" };
            Market market3 = new Market() { Name = "Рынок 3" };
            context.Market.Add(market1);
            context.Market.Add(market2);
            context.Market.Add(market3);

            Supplier sup1 = new Supplier()
            {
                Name = "Марр",
                Markets = new List<Market>() { market1, market3, market2 },
                Products = new List<ProductSupplier>()
            };

            ProductSupplier ps1 = new ProductSupplier() { Product = p1, Price = 1m, Supplier = sup1, Market = market1 };
            ProductSupplier ps2 = new ProductSupplier() { Product = p2, Price = 11m, Supplier = sup1, Market = market1 };
            ProductSupplier ps3 = new ProductSupplier() { Product = p3, Price = 111m, Supplier = sup1, Market = market1 };
            ProductSupplier ps4 = new ProductSupplier() { Product = p4, Price = 1111m, Supplier = sup1, Market = market1 };

            ProductSupplier psp5 = new ProductSupplier() { Product = p1, Price = 2m, Supplier = sup1, Market = market2 };
            ProductSupplier psp6 = new ProductSupplier() { Product = p2, Price = 22m, Supplier = sup1, Market = market2 };
            ProductSupplier psp7 = new ProductSupplier() { Product = p3, Price = 222m, Supplier = sup1, Market = market2 };
            ProductSupplier psp8 = new ProductSupplier() { Product = p4, Price = 2222m, Supplier = sup1, Market = market2 };

            sup1.Products.Add(ps1);
            sup1.Products.Add(ps2);
            sup1.Products.Add(ps3);
            sup1.Products.Add(ps4);
            sup1.Products.Add(psp5);
            sup1.Products.Add(psp6);
            sup1.Products.Add(psp7);
            sup1.Products.Add(psp8);
            Supplier sup2 = new Supplier()
            {
                Name = "Уренхольт",
                Markets = new List<Market>() { market2, market3 },
                Products = new List<ProductSupplier>()
            };
            Supplier sup3 = new Supplier()
            {
                Name = "ТД Ням-ням",
                Markets = new List<Market>() { market3, market1 },
                Products = new List<ProductSupplier>()
            };
            context.Supplier.Add(sup1);
            context.Supplier.Add(sup2);
            context.Supplier.Add(sup3);
            context.SaveChanges();

            Recipe recipe1 = new Recipe()
            {
                Name = "Молоко+Сахар",
                Products = new List<ProductRecipe>
                { new ProductRecipe {Product= p1,Value=0.01 },new ProductRecipe {Product= p2 ,Value=0.2} }
            };
            Recipe recipe2 = new Recipe()
            {
                Name = "Баранина+Соль",
                Products = new List<ProductRecipe>
                { new ProductRecipe { Product = p3,Value=0.001 }, new ProductRecipe { Product = p5,Value=100 } }
            };
            Recipe recipe3 = new Recipe()
            {
                Name = "Молоко+Баранина",
                Products = new List<ProductRecipe>
                {   new ProductRecipe {Product= p1,Value=1341 }, new ProductRecipe {Product= p3 ,Value=0.0001} }
            };
            context.Recipe.Add(recipe1);
            context.Recipe.Add(recipe2);
            context.Recipe.Add(recipe3);
            context.SaveChanges();

            Location warehouse = new Location()
            {
                Name = "Склад Манеж",
                Market = market1,
                Recipes = new List<Recipe> { recipe1 }
            };
            Location warehouse2 = new Location()
            {
                Name = "Склад Трубная",
                Market = market2,
                Recipes = new List<Recipe>() { recipe2 }
            };
            context.Location.Add(warehouse);
            context.Location.Add(warehouse2);
            context.SaveChanges();
            ProductStorage pss1 = new ProductStorage { Product = p1, Value = 10, Price = 20, LocationID = 1 };
            ProductStorage pss2 = new ProductStorage { Product = p2, Value = 20, Price = 40, LocationID = 1 };
            ProductStorage pss3 = new ProductStorage { Product = p3, Value = 50, Price = 100, LocationID = 1 };
            ProductStorage pss4 = new ProductStorage { Product = p4, Value = 1, Price = 2000, LocationID = 1 };
            ProductStorage pss5 = new ProductStorage { Product = p5, Value = 445, Price = 54, LocationID = 1 };
            ProductStorage pss6 = new ProductStorage { Product = p6, Value = 343, Price = 10000, LocationID = 1 };
            context.ProductStorage.AddRange(new List<ProductStorage> { pss1, pss2, pss3, pss4, pss5, pss6 });





            ProductStorage ps7 = new ProductStorage { Product = p1, Value = 10, Price = 20, LocationID = 2 };
            ProductStorage ps8 = new ProductStorage { Product = p2, Value = 20, Price = 40, LocationID = 2 };
            ProductStorage ps9 = new ProductStorage { Product = p3, Value = 50, Price = 100, LocationID = 2 };
            ProductStorage ps10 = new ProductStorage { Product = p4, Value = 1, Price = 2000, LocationID = 2 };
            ProductStorage ps11 = new ProductStorage { Product = p5, Value = 445, Price = 54, LocationID = 2 };
            ProductStorage ps12 = new ProductStorage { Product = p6, Value = 343, Price = 10000, LocationID = 2 };
            context.ProductStorage.AddRange(new List<ProductStorage> { ps7, ps8, ps9, ps10, ps11, ps12 });
            context.SaveChanges();

            Location restoran1 = new Location
            {
                Name = "Однорукий повар",
                Market = market3,
                Recipes = new List<Recipe>() { recipe3 }
            };
            market1.Locations.Add(warehouse);
            market2.Locations.Add(warehouse2);
            market3.Locations.Add(restoran1);
            context.Location.Add(restoran1);
            context.SaveChanges();
        }
    }
}


