using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatCollector
{
    public abstract class StatCreator
    {
        public abstract IStatCollector<T> Create<T>();
    }
}
