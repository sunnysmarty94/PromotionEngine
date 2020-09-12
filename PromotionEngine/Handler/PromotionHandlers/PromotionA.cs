using PromotionEngine.Entities;
using PromotionEngine.Handler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Handler.PromotionHandlers
{
    public class PromotionA : IReceiver<Cart>
    {
        public int Handle(ref Cart cart)
        {
            try
            {
                int value = 0;
                var unprocessedA = cart.Items
                                    .Where(x => x.Name == 'A' && x.isProcessed == false)
                                    .ToList();
                var loop = unprocessedA.Count / 3;
                var skip = 0;
                for (var i = 0; i <= loop; i++)
                {
                    var processingList = unprocessedA.Skip(skip).Take(3);
                    if (processingList.Count() < 3)
                        break;
                    foreach (var p in processingList)
                    {
                        p.isProcessed = true;
                    }
                    value += 130;
                    skip += 3;
                }
                return value;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while applying"+ this.GetType().Name);
                throw;
            }
            
        }
    }
}
