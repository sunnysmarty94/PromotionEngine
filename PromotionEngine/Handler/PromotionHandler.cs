using PromotionEngine.Entities;
using PromotionEngine.Handler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Handler
{
    public class PromotionHandler
    {
        private readonly IList<IReceiver<Cart>> receivers;
        public PromotionHandler(params IReceiver<Cart>[] receivers)
        {
            this.receivers = receivers;
        }

        public PromotionHandler()
        {
            this.receivers = new List<IReceiver<Cart>>();
        }
        public int Handle(ref Cart cart)
        {
            int totalValue = 0;
            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");

                if (cart.Items.Exists(i => i.isProcessed == false))
                {
                    totalValue += receiver.Handle(ref cart);
                }
                else
                {
                    break;
                }
            }
            var pendingItems = cart.Items.Where(i => i.isProcessed == false).ToList();
            if (pendingItems.Count > 0)
            {
                var val = pendingItems.Sum(s => s.Price);
                totalValue += val;
            }
            return totalValue;
        }

        public void SetNext(IReceiver<Cart> next)
        {
            receivers.Add(next);
        }
    }
}
