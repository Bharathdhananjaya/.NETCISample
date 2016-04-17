using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatCollector
{
    public interface IStatCollector<T>
    {       
        void CollectStats(List<T> nonTradeCollection);
    }
}
