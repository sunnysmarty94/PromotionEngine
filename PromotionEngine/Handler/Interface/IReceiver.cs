using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Handler.Interface
{
    public interface IReceiver<T> where T : class
    {
        int Handle(ref T request);
    }
}
