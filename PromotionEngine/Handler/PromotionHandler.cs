using PromotionEngine.Entities;
using PromotionEngine.Handler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Handler
{
    /// <summary>
    /// Promotion execution engine.
    /// </summary>
    public class PromotionHandler
    {
        private readonly IList<IReceiver<Cart>> receivers;

        /// <summary>
        /// Accepts array of Active promotions
        /// </summary>
        /// <param name="receivers"></param>
        public PromotionHandler(params IReceiver<Cart>[] receivers)
        {
            this.receivers = receivers;
        }

        public PromotionHandler()
        {
            this.receivers = new List<IReceiver<Cart>>();
        }
        /// <summary>
        /// This will execute all the active promotions on items in cart and return the final value 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int Handle(ref Cart cart)
        {
            try
            {
                int totalValue = 0;
                foreach (var receiver in receivers)
                {
                    if (!cart.Items.Exists(i => i.isProcessed == false))
                        break;
                    totalValue += receiver.Handle(ref cart);

                }
                var pendingItems = cart.Items.Where(i => i.isProcessed == false).ToList();
                if (pendingItems.Count == 0)
                    return totalValue;
                var val = pendingItems.Sum(s => s.Price);
                totalValue += val;
                return totalValue;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while applying promotions");
                return -1;
            }

        }

        /// <summary>
        /// Add promotion to be applied on the cart item
        /// </summary>
        /// <param name="next"></param>
        public void SetNext(IReceiver<Cart> next)
        {
            receivers.Add(next);
        }
    }
}
