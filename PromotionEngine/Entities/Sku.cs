using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Entities
{
    public class Sku
    {
        #region Private members
        private readonly char _name;
        private readonly int _price;
        private bool _isProcessed;
        #endregion
        public Sku(char name, int price, bool isProcessed = false)
        {
            _name = name;
            _price = price;
            _isProcessed = isProcessed;

        }

        public char Name => _name;
        public int Price => _price;
        public bool isProcessed
        {
            get
            {
                return _isProcessed;
            }
            set
            {
                _isProcessed = value;
            }
        }
    }
}
