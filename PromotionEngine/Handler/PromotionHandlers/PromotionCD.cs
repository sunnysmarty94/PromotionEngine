﻿using PromotionEngine.Entities;
using PromotionEngine.Handler.Interface;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Handler.PromotionHandlers
{
    public class PromotionCD : IReceiver<Cart>
    {
        public int Handle(ref Cart cart)
        {
            try
            {
                int value = 0;

                var unprocessedC = cart.Items
                                    .Where(x => x.Name == 'C' && x.isProcessed == false);
                var unprocessedD = cart.Items
                                    .Where(x => x.Name == 'D' && x.isProcessed == false);
                if (unprocessedC.Count() == 0 || unprocessedD.Count() == 0)
                    return value;
                var minPair = Math.Min(unprocessedC.Count(), unprocessedD.Count());
                for (var i = 0; i < minPair; i++)
                {
                    var skuC = unprocessedC.First(x => x.isProcessed == false && x.Name == 'C');
                    var skuD = unprocessedD.First(x => x.isProcessed == false && x.Name == 'D');
                    skuC.isProcessed = true;
                    skuD.isProcessed = true;
                    value += 30;
                }
                return value;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while applying" + this.GetType().Name);
                throw;
            }

        }
    }
}
