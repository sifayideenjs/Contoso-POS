using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> Get();
        Item GetByID(int Id);
        void Insert(Item item);
        void Delete(int ID);
        void Update(Item item);
        void Save();
    }
}
