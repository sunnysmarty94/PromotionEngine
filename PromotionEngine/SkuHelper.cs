using PromotionEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public static class SkuHelper
    {
        private static Dictionary<char, int> priceTable;
        private static List<KeyValuePair<char, int>> priceList;

        static SkuHelper(){
            priceList = new List<KeyValuePair<char, int>>()
            {
                new KeyValuePair<char, int>('A',50),
                new KeyValuePair<char, int>('B',30),
                new KeyValuePair<char, int>('C',20),
                new KeyValuePair<char, int>('D',15)
            };
            priceTable = new Dictionary<char, int>(priceList);
        }
        public static List<Sku> GetSkuList(List<char> items)
        {
            return items.Select(a => new Sku(a, priceTable[a])).ToList();
        }
    }
}
