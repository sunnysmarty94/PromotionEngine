using PromotionEngine.Handler;
using PromotionEngine.Handler.PromotionHandlers;
using System;

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

                
        }
    }
}
