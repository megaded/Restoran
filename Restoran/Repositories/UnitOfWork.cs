using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Entities;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public IUnitRepository UnitRep { get; private set; }
        public IProductRepository ProductRep { get; private set; }
        public IRecipeRepository RecipeRep { get; private set; }
        public ILocationRepository LocationRep { get; private set; }
        public IOrderRepository OrderRep { get; private set; }
        public ISupplierRepository SupplierRep { get; private set; }
        public IProductCategoryRepository ProductCategoryRep { get; private set; }
        public IMarketRepository MarketRep { get; private set; }
        public IProductSupplierRepository ProdSup { get; private set; }
        public IReasonRepository ReasonRep { get; private set; }
        public IDisposalProductRepository DProductRep { get; private set; }
        public IProductDisposalRepository ProductDRep { get; private set; }
        private RestoranContext context;
        public UnitOfWork(RestoranContext context, IUnitRepository unitRep, IProductRepository productRep, ILocationRepository locationRep, IOrderRepository orderRep, ISupplierRepository supplierRep, IProductCategoryRepository productCategoryRep, IRecipeRepository recipeRep, IMarketRepository marketRep, IProductSupplierRepository prodSup, IReasonRepository reasonRep, IDisposalProductRepository dProductRep, IProductDisposalRepository productDRep)
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
            ProdSup = prodSup;
            ReasonRep = reasonRep;
            DProductRep = dProductRep;
            ProductDRep = productDRep;
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
            order.SupplierId = supplierID;
            order.LocationId = warehouseID;
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

        public void CreateRecipe(Recipe recipe, List<ProductRecipe> products)
        {
            foreach (var product in products.Where(p => p.Value > 0 && p.Value != null))
            {
                recipe.Products.Add(new ProductRecipe
                {
                    ProductId = product.Product.ProductId,
                    Value = product.Value
                });
            }
            RecipeRep.Add(recipe);
            context.SaveChanges();
        }

        public void CreateProduct(Product product, int UnitId, int ProductCategoryId)
        {
            product.Unit = UnitRep.Get(UnitId);
            product.ProductCategory = ProductCategoryRep.Get(ProductCategoryId);
            ProductRep.Add(product);
        }

        public void ProductDispocal(IEnumerable<DisposalProduct> disposalProducts, int locationID, int reasonID)
        {
            ProductDisposal productDisposal = new ProductDisposal();
            productDisposal.Date = DateTime.Now;
            productDisposal.LocationId = locationID;
            productDisposal.ReasonId = reasonID;
            productDisposal.Products = new List<DisposalProduct>();
            foreach (var disposalProduct in disposalProducts)
            {
                var operation = new Operation();
                var product = context.ProductStorage.Where(x => x.ProductId == disposalProduct.ProductId &&x.LocationID==locationID).FirstOrDefault();
                if (product != null&& product.Value>=disposalProduct.Amount)
                {
                    operation.Date = DateTime.Now;
                    operation.Name = "Списание";
                    operation.Value = disposalProduct.Amount * -1;
                    operation.ProductId = disposalProduct.ProductId;
                    product.Value -= disposalProduct.Amount;
                    disposalProduct.Price = product.Price;
                    context.Operation.Add(operation);
                    context.Entry(product).State =EntityState.Modified;
                    productDisposal.Products.Add(disposalProduct);
                }
            }
            ProductDRep.Add(productDisposal);
            Save();
        }
    }
}
