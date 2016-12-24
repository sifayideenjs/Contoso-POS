using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSale.Models;
using PointOfSale.Repositories;
using System.Linq;
using PointOfSale.DAL;

namespace PointOfSale.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void PopulateDataSet()
        {
            DataSet.PopulateDataSet();
        }
    }
}
