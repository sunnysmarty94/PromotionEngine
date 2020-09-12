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

        private List<IReceiver<Cart>> activePromotions;
        private PromotionHandler handler;
        [SetUp]
        public void Setup()
        {
            activePromotions = new List<IReceiver<Cart>>
            {
                new PromotionA(),
                new PromotionB(),
                new PromotionCD()
            };
            handler = new PromotionHandler(activePromotions.ToArray());
        }

        [Test]
        public void Case1()
        {
            var items = new List<char>
            {
                'A','B','C'
            };
            var cart = new Cart()
            {
                Items = SkuHelper.GetSkuList(items)
            };
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
            var cart = new Cart()
            {
                Items = SkuHelper.GetSkuList(items)
            };
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
            var cart = new Cart()
            {
                Items = SkuHelper.GetSkuList(items)
            };
            int actualOrderValue = handler.Handle(ref cart);
            Assert.AreEqual(280, actualOrderValue);
        }
    }
}