using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProxy.Example.Proxy
{
    [Resource("foo2")]
    public interface IFooRest2 : IFooRest
    {
        // This interface is here just so we can change the resource name
    }
}
