using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatCollector
{
    public  class AbstractStatCollector<T>
    {
        
        
        public AbstractStatCollector()
        {
         // Pass the context and other iteme require to fill in the     
        }

        public List<Func<string, List<T>, StatsEntity>> indicatorActionList;
        

        public StatsEntity FillStatsEntity(List<T> nonTradeEntity, KeyValuePair<string,int> kvp)
        {
            return new StatsEntity
            {
                key = kvp.Key,
                LogExecutionId = 0, // assign from the constructor
                Runid = 0, // assign from the constructor
                Value = kvp.Value.ToString()
            };
        }
    }
}


interface  IStatsAggregator<ToutPut>
{
    KeyValuePair<string, ToutPut> ExecuteAggregator<T>(string indicatorName, List<T> feedCollection);
    

}

interface IStatsGroupByAggregator
{
    List<KeyValuePair<string, int>> ExecuteAggregator<T>(string indicatorName, List<T> feedCollection);
}


class StatsAggregatorDistictByGroup 
{
     public List<KeyValuePair<string, int>> ExecuteAggregator<T>(string indicatorName, List<T> feedCollection)
    {
        //List<int> value = feedCollection.GroupBy(i => i.GetType().GetProperty(indicatorName).GetValue(i))
        //    .Select(n=>new{n.GetType().GetProperty(indicatorName).GetValue(i),n.Count()});

        var groupby = feedCollection.GroupBy(i => i.GetType().GetProperty(indicatorName)
            .GetValue(i)).Select(y => new
        {   Key = y.Key,
            Value = y.Count()
        });


        List<KeyValuePair<string, int>> kvpCollection = new List<KeyValuePair<string, int>>();


        foreach (var eachKVP in groupby)
        {
            kvpCollection.Add(new KeyValuePair<string, int>("COUNT_DISTINCT_" + indicatorName + eachKVP.Key, eachKVP.Value));
        }

        return kvpCollection;
    }


}

class StatsAggregatorAll<ToutPut> : IStatsAggregator<ToutPut>
{
    public KeyValuePair<string, ToutPut> ExecuteAggregator<T>(string indicatorName, List<T> feedCollection)
    {
        int value = feedCollection.Count();
        return new KeyValuePair<string, ToutPut>("COUNT_ALL", (ToutPut)Convert.ChangeType(value, typeof(ToutPut)));
    }


}
class StatsAggregatorDistinct<ToutPut> : IStatsAggregator<ToutPut>
{


    public KeyValuePair<string, ToutPut> ExecuteAggregator<T>(string indicatorName, List<T> feedCollection)
    {
        var value = feedCollection.Select(i => i.GetType().GetProperty(indicatorName).GetValue(i)).Distinct().Count();
        return new KeyValuePair<string, ToutPut>("COUNT_DISTINCT_", (ToutPut)Convert.ChangeType(value, typeof(ToutPut)));
    }


}
class StatsAggregatorNull<ToutPut> : IStatsAggregator<ToutPut> 
{
    public KeyValuePair<string, ToutPut> ExecuteAggregator<T>(string indicatorName, List<T> feedCollection)
    {
        int value = feedCollection.Where(i => i.GetType().GetProperty(indicatorName).GetValue(i) == null).Select(i => i).Count();
        return new KeyValuePair<string, ToutPut>("COUNT_NULL_", (ToutPut)Convert.ChangeType(value, typeof(ToutPut)));
    }



}