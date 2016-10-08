using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restoran;
namespace RestoranUnitTest
{

    [TestClass]
    public class WarehouseTest
    {
        [TestMethod]
        public void Create_Order()
        {
            Product p1 = new Product() { Name = "Молоко" };
            Product p2 = new Product() { Name = "Сахар" };
            Product p3 = new Product() { Name = "Баранина" };

            ProductStorage ps1 = new ProductStorage() { Product = p1, Price = 30, Value = 10 };
            ProductStorage ps2 = new ProductStorage() { Product = p2, Price = 450, Value = 1000 };
            ProductStorage ps3 = new ProductStorage() { Product = p3, Price = 1, Value = 500 };

            Supplier sup1 = new Supplier
            {
                Name = "Пятерочка",
                Products = new List<ProductSupplier>
                {
                   new ProductSupplier {Product=p1,Price=30 },
                   new ProductSupplier {Product=p2,Price=10 },
                   new ProductSupplier {Product=p3,Price=100 }
                }
            };
            Location target = new Location();
        //    target.CreateOrder(new List<ProductStorage> { ps1, ps2, ps3 },sup1);
            Assert.AreEqual(target.Orders.Count, 1);
            Assert.AreEqual(target.Orders[0].Products[0].Product.Name, "Молоко");
            Assert.AreEqual(target.Orders[0].Supplier.Name, "Пятерочка");

        }
        [TestMethod]
        public void Debit_Goods(Order order)
        {
          
        }
    }
}
