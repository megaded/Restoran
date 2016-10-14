using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Repositories
{
    public class UnitOfWork : IDisposable,IUnitOfWork
    {
        public IUnitRepository UnitRep { get; private set; }
        public IProductRepository ProductRep { get; private set; }
        public IRecipeRepository RecipeRep { get; private set; }
        public ILocationRepository LocationRep { get; private set; }
        public IOrderRepository OrderRep { get; private set; }
        public ISupplierRepository SupplierRep { get; private set; }
        public IProductCategoryRepository ProductCategoryRep { get; private set; }
        public IMarketRepository MarketRep { get; private set; }
        private  RestoranContext context;
        public UnitOfWork(RestoranContext context, IUnitRepository unitRep, IProductRepository productRep, ILocationRepository locationRep, IOrderRepository orderRep, ISupplierRepository supplierRep, IProductCategoryRepository productCategoryRep, IRecipeRepository recipeRep,IMarketRepository marketRep)
        {
            this.context = context;
            UnitRep = unitRep;
            ProductRep = productRep;
            LocationRep = locationRep;
            RecipeRep = recipeRep;
            OrderRep = orderRep;
            SupplierRep = supplierRep;
            ProductCategoryRep = productCategoryRep;
            MarketRep = marketRep;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void CreateOrder(IEnumerable<ProductOrdered> products, int supplierID, int warehouseID)
        {
            Order order = new Order();
            order.Supplier = SupplierRep.Get(supplierID);
            order.Location= LocationRep.Get(warehouseID);
            products = products.Where(x => x.Value != 0);
            foreach (var product in products)
            {
                order.Products.Add(new ProductOrdered
                {
                    ProductId = product.ProductId,
                    Value = product.Value,
                    Price = product.Price
                });
            }
            OrderRep.Add(order);
            context.SaveChanges();
        }
        public void AcceptOrder(int orderId)
        {
            var order = OrderRep.Get(orderId);
            var prodAccept = order.Products;
            var warehouse = LocationRep.Get(order.LocationId);
            foreach (var item in prodAccept)
            {
                var prod = warehouse.Products.Where(p => p.Product.ProductId == item.Product.ProductId).FirstOrDefault();
                if (prod != null)
                {

                    prod.Value += item.Value;
                    prod.TotalQuantity += (decimal)item.Value;
                    prod.TotalPrice += item.Price * (decimal)item.Value;
                    prod.Price = prod.TotalPrice / prod.TotalQuantity;
                }
                else
                {
                    warehouse.Products.Add
                        (
                        new ProductStorage
                        {
                            Product = ProductRep.Get(item.Product.ProductId),
                            Value = item.Value,
                            Price = item.Price
                        });
                }
            }
            order.Accept = true;
            order.AcceptDate = DateTime.Today;     
        }             

        public void CreateRecipe(Recipe recipe,List<ProductRecipe> products)
        {
            foreach (var product in products.Where(p=>p.Value>0&&p.Value!=null))
            {
                recipe.Products.Add(new ProductRecipe
                {
                    ProductId=product.Product.ProductId,
                    Value = product.Value
                });
            }
            RecipeRep.Add(recipe);
            context.SaveChanges();
        }

        public void CreateProduct(Product product, int UnitId, int ProductCategoryId)
        {
            product.Unit= UnitRep.Get(UnitId);
            product.ProductCategory = ProductCategoryRep.Get(ProductCategoryId);
            ProductRep.Add(product);            
        }
    }
}
