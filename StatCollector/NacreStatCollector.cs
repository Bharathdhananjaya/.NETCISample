using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace StatCollector
{
    class NacreStatCollector : AbstractStatCollector<NacreRow>,IStatCollector<NacreRow>
    {
       
        private string Source = null;
        public List<StatsEntity> statsEntity = new List<StatsEntity>();
        private List<string> indicatorCollection=new List<String>{"Id","DealId","Name"};
        AbstractStatCollector<NacreRow> abstractStatCollector;

        private Dictionary<string,Func<string, List<NacreRow>, KeyValuePair<string, int>>> indicatorAction;
        private Dictionary<string, Func<string, List<NacreRow>, List<KeyValuePair<string, int>>>> indicatorActionList; 

        public NacreStatCollector()
        {
            abstractStatCollector = new AbstractStatCollector<NacreRow>();
            InvokeFunc();                   
            Source = "NACRE";           
        }

        private void InvokeFunc()
        {
            indicatorAction = new Dictionary<string, Func<string, List<NacreRow>, KeyValuePair<string, int>>>();
            indicatorActionList = new Dictionary<string, Func<string, List<NacreRow>, List<KeyValuePair<string, int>>>>();
            //indicatorAction.Add("DealId", new StatsAggregatorDistinct<double>().ExecuteAggregator<NacreRow>);         
            indicatorActionList.Add("Version",new StatsAggregatorDistictByGroup().ExecuteAggregator<NacreRow>);          
           
        }

        public void CollectStats(List<NacreRow> nacreList)
        {           
            int index = 0;
            Parallel.ForEach(indicatorAction,
                kvp => { statsEntity.Add(this.abstractStatCollector.FillStatsEntity(nacreList, kvp.Value(kvp.Key, nacreList))); }
                );

            

            //foreach(var kvp in indicatorActionList)
            //{
            //    statsEntity.Add(this.abstractStatCollector.FillStatsEntity(nacreList,kvp.Value(kvp.Key,nacreList)));
            //}





            var assignTheList = statsEntity;
        }
        
    }




    [StatsCollectorAttribute(Name = "NacreStatCollector")]
    class NacreRow : Attribute
    {
       
        public int Id { get; set; }
        public int DealId { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }  
    }

    class StatsCollectorAttribute :Attribute
    {
        public string Name { get; set; }
    }



   
}

namespace Test
{
    public class TestAttribute : Attribute
    {
        public int TheNumber;

        public string Name;

        public TestAttribute(int number)
        {
            TheNumber = number;
        }

        public void PrintOut()
        {
            Console.WriteLine("\tTheNumber = {0}", TheNumber);
            Console.WriteLine("\tName = \"{0}\"", Name);
        }
    }

}