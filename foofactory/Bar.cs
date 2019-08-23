using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foofactory
{
    public class Bar
    {

        public IFooFactory FooFactory { get; set; }
        public IList<IFoo> Execute()
        {
            return this.FooFactory.GetAll();
        }
    }
}
