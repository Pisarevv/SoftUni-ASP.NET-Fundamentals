using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Contracts
{
    public interface IProductService
    {
        public Task<ICollection<ProductViewModel>> AllAsync();
    }
}
