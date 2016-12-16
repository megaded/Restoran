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
        void ProductDispocal(IEnumerable<DisposalProduct> disposalProducts,int locationID,int reasonID);
      
    }
}
