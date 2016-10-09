using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatCollector
{
    class TradeStatCollector : IStatCollector<TradeRow>
  {
        public TradeStatCollector()
        {
                
        }
        public void CollectStats(List<TradeRow> tradeCollection)
        {
            Console.WriteLine(" Trade Collector");
        }

        public void CollectStats(List<TradeRow> nonTradeCollection, int dataType)
        {
            throw new NotImplementedException();
        }
  }

    class TradeRow
    {
    }
}
