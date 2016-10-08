using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Repositories
{
 public interface IUnitOfWork
    {
        void Save();
        void CreateOrder(IEnumerable<ProductOrdered> products, int supplierID, int warehouseID);
        void AcceptOrder(int orderId);
        void CreateRecipe(Recipe recipe, List<ProductRecipe> products);
        void CreateProduct(Product product, int UnitId, int ProductCategoryId);
    }

}
