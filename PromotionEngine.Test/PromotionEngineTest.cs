using NUnit.Framework;
using System.Collections.Generic;

namespace PromotionEngine.Test
{
    public class PromotionEngineTest
    {
        private Dictionary<char, int> priceTable;
        private List<KeyValuePair<char, int>> priceList;
        [SetUp]
        public void Setup()
        {
            priceList = new List<KeyValuePair<char, int>>()
            {
                new KeyValuePair<char, int>('A',50),
                new KeyValuePair<char, int>('B',30),
                new KeyValuePair<char, int>('C',20),
                new KeyValuePair<char, int>('D',15)
            };
            priceTable = new Dictionary<char, int>(priceList);
        }

        [Test]
        public void TestCase1()
        {
            int actualOrderValue = 10;//
            Assert.AreEqual(100, actualOrderValue);
        }
        [Test]
        public void Case2()
        {
            int actualOrderValue = 10;//
            Assert.AreEqual(370, actualOrderValue);

        }
        [Test]
        public void Case3()
        {
            int actualOrderValue = 10;//
            Assert.AreEqual(280, actualOrderValue);
        }
    }
}