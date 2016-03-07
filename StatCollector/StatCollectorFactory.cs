using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Dynamic;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace StatCollector
{
     public  class StatCollectorFactory : StatCreator
    {
         public override IStatCollector<T> Create<T>()
         {
             string classObject = null;
             IStatCollector<T> returnInstance = null;
             Dictionary<Type,string> dictionary=new Dictionary<Type,string>();
             dictionary.Add(typeof(TradeRow),"TradeStatCollector");
             dictionary.Add(typeof(NacreRow), "NacreStatCollector");
                         
             var attr = Attribute.GetCustomAttributes(typeof(T));
            string typeName = attr.OfType<StatsCollectorAttribute>().FirstOrDefault().Name;
                  if (dictionary.TryGetValue(typeof(T), out classObject))
             {
                 //AssemblyName assemblyName = Assembly.GetAssembly(typeof(IStatCollector)).FullName.
                 Type type = Type.GetType(typeof(Program).Assembly.GetName().Name + "." + typeName);
                 returnInstance = (IStatCollector<T>)Activator.CreateInstance(type);
             }

             return returnInstance;
         }

    }
}
