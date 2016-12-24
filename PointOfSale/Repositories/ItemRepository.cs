using PointOfSale.Interfaces;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private POSDBContext context;

        public ItemRepository(POSDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Item> Get()
        {
            return context.Items.ToList();
        }

        public Item GetByID(int id)
        {
            return context.Items.Find(id);
        }

        public void Insert(Item item)
        {
            context.Items.Add(item);
        }

        public void Delete(int ID)
        {
            Item item = context.Items.Find(ID);
            context.Items.Remove(item);
        }

        public void Update(Item customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}