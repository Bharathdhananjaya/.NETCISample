using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Reflection;

namespace StatCollector
{
    class Program
    {
        static void Main(string[] args)
        {
                         

            var nacreFillList = new Program().FillNacreObject();      
            InvokeMethod1(nacreFillList);
            Console.WriteLine("End of parallel loops" );
            Console.Read();

        }
        private static void LoopFiniteTimes1()
        {
            for(int i=0;i<10000;i++)
            {
                Console.WriteLine("Loop1 - {0}", i);
            }
        }

        private T GetMyType<T>() 
        {
            Type t = typeof(T);
            var myObj = Activator.CreateInstance(t);
            return (T) myObj;
        }
    


        private List<NacreRow> FillNacreObject()
        {            
            var nacreList = new List<NacreRow>(){new NacreRow(){DealId=2,Id=5,Name="bharath",Version=1},
                                                new NacreRow(){DealId=3,Id=6,Name="pradhyun",Version=5},
                                               new NacreRow(){DealId=3,Id=6,Name="pradhyun",Version=5},
                                               new NacreRow(){DealId=5,Id=7,Version=5}};
            return nacreList;
        }

        private static void LoopFiniteTimes2()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Loop2 - {0}", i);
            }
        }


        private static void InvokeMethod1(List<NacreRow> nacreList)
        {
            var factoryObject = new StatCollectorFactory();
            IStatCollector<NacreRow> statCollector1 = factoryObject.Create<NacreRow>();
            //statCollector1.CollectStats(nacreList);
            

        }


        private static void InvokeMethod2()
        {
            var factoryObject = new StatCollectorFactory();
            IStatCollector<NacreRow> statCollector2 = factoryObject.Create<NacreRow>();
            //statCollector2.CollectStats();
        }


        
    }







}
