using PromotionEngine.Entities;
using PromotionEngine.Handler;
using PromotionEngine.Handler.PromotionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            PromotionHandler handler = new PromotionHandler();
            handler.SetNext(new PromotionA());
            handler.SetNext(new PromotionB());
            handler.SetNext(new PromotionCD());
            List<char> items = new List<char>
            {
                'A',
                'A',
                'A',
                'B',
                'B',
                'C',
                'D'
            };
            var cart = new Cart
            {
                Items = SkuHelper.GetSkuList(items)
            };

            var val = handler.Handle(ref cart);
            var msg = val == 205 ? "Hurray!! Your promotions applied.Happy Saving"
                                : "There something wrong with your bill. Please contact admin.";
            Console.WriteLine(msg);
        }
    }
}
