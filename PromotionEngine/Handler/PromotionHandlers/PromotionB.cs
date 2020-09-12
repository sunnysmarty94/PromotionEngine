using PromotionEngine.Entities;
using PromotionEngine.Handler.Interface;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Handler.PromotionHandlers
{
    public class PromotionB : IReceiver<Cart>
    {
        public int Handle(ref Cart cart)
        {
            int value = 0;
            var unprocessed = cart.Items
                                .Where(x => x.Name == 'B' && x.isProcessed == false)
                                .ToList();
            var loop = unprocessed.Count / 2;
            var skip = 0;
            for (var i = 0; i <= loop; i++)
            {
                var processingList = unprocessed.Skip(skip).Take(2);
                if (processingList.Count() == 2)
                {
                    foreach (var p in processingList)
                    {
                        p.isProcessed = true;
                    }
                    value += 45;
                }
                skip += 2;
            }
            return value;
        }
    }
}
