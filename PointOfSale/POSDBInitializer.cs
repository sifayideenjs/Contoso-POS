using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class POSDBInitializer : CreateDatabaseIfNotExists<POSDBContext>
    {
        protected override void Seed(POSDBContext context)
        {
            base.Seed(context);
        }
    }
}
