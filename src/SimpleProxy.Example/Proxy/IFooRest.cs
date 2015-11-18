using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProxy.Example.Proxy
{
    // WebApi usage
    // Either have the interface/class have the same name as the controller to use the default /api/{controller} scheme
    // (if the controller is named FooController, create a class named Foo to have an url like /api/Foo)
    // or use the Resource attribute to name it here 
    // (if you don't include the /api fragment here, you can add /api to the root url in the ProxyConfiguration object)
    [Resource("foo")]
    public interface IFooRest
    {
        // Method names are free form in this case

        // GET /foo
        [HttpMethod(HttpMethod.Get)]
        IEnumerable<Foo> FindAll();


        // GET /foo/1
        [HttpMethod(HttpMethod.Get)]

        // hoist a parameter from the request contents to the url
        [Resource("{0}", "id")]
        Foo GetById(int id);


        // POST /foo
        [HttpMethod(HttpMethod.Post)]
        
        // the parameter is serialized and used as the request body
        void Add(Foo foo);

        // PUT /foo/1
        [HttpMethod(HttpMethod.Put)]

        // hoist one parameter, and have the other be serialized and used as the request body
        [Resource("{0}", "id")]
        void Update(int id, Foo value);

        // DELETE /foo/1
        [HttpMethod(HttpMethod.Delete)]
        [Resource("{0}", "id")]
        void Delete(int id);
    }
}
