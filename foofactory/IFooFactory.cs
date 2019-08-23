using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foofactory
{
    public interface IFooFactory
    {
        IList<IFoo> GetAll(int id);
        void Save(IFoo foo);
    }
}
