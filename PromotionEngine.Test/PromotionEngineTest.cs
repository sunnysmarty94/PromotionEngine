using NUnit.Framework;
using PromotionEngine.Entities;
using PromotionEngine.Handler;
using PromotionEngine.Handler.Interface;
using PromotionEngine.Handler.PromotionHandlers;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    public class PromotionEngineTest
    {
        private Dictionary<char, int> priceTable;
        private List<KeyValuePair<char, int>> priceList;
        private List<IReceiver<Cart>> activePromotions;
        private PromotionHandler handler;
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
            activePromotions = new List<IReceiver<Cart>>
            {
                new PromotionA(),
                new PromotionB(),
                new PromotionCD()
            };
            handler = new PromotionHandler(new PromotionA(),
                new PromotionB(),
                new PromotionCD());
        }

        [Test]
        public void Case1()
        {
            var items = new List<char>
            {
                'A','B','C'
            };
            var cart = new Cart();
            cart.Items = GetSkuList(items);
            int actualOrderValue = handler.Handle(ref cart);
            Assert.AreEqual(100, actualOrderValue);
        }
        [Test]
        public void Case2()
        {
            var items = new List<char>
            {
                'A','A','A','A','A','B','B','B','B','B','C'
            };
            var cart = new Cart();
            cart.Items = GetSkuList(items);
            int actualOrderValue = handler.Handle(ref cart);
            Assert.AreEqual(370, actualOrderValue);

        }
        [Test]
        public void Case3()
        {
            var items = new List<char>
            {
                'A','A','A','B','B','B','B','B','C','D'
            };
            var cart = new Cart();
            cart.Items = GetSkuList(items);
            int actualOrderValue = handler.Handle(ref cart);
            Assert.AreEqual(280, actualOrderValue);
        }

        private List<Sku> GetSkuList(List<char> items)
        {
            return items.Select(a => new Sku(a, priceTable[a])).ToList();
        }
    }
}