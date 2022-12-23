using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectLibrary;

namespace ProjectUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDataModel()
        {
            List<Dictionary<string, string>> listData = new List<Dictionary<string, string>> { new Dictionary<string, string> { { "country", "Sweden" }, { "country", "United Kingdom" } } };
            DataModel modelData = new DataModel { Data = listData };
            List<string> resList = new List<string>();
            List<string> compList = new List<string>{"Sweden", "United Kingdom" };
            foreach (var country in modelData.Data)
            {
                resList.Add(country["country"]);
            }
            Assert.AreEqual(resList, compList);
        }

    }
}
