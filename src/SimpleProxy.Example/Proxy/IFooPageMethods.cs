using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProxy.Example.Proxy
{
    // WebForms PageMethods
    // Request parameters and responses are specified in a different manner, but this still works.
    [Resource("Default.aspx")]
    interface IFooPageMethods
    {
        // POST Default.aspx/GetAllFoos
        [HttpMethod(HttpMethod.Post)]
        [Resource("GetAllFoos")]
        GetAllFoosResponse FindAll();

        // POST Default.aspx/GetFooById
        [HttpMethod(HttpMethod.Post)]
        [Resource("GetFooById")]
        // the parameter is serialized and used as the request body
        GetFooByIdResponse GetById(FooByIdParameters parameters);

        // POST Default.aspx/AddFoo
        [HttpMethod(HttpMethod.Post)]
        [Resource("AddFoo")]      
        // the parameter is serialized and used as the request body
        void Add(AddParameters foo);

        // POST Default.aspx/UpdateFoo
        [HttpMethod(HttpMethod.Post)]
        [Resource("UpdateFoo")]
        // the parameter is serialized and used as the request body
        void Update(UpdateParameters parameters);

        // POST Default.aspx/DeleteFoo
        [HttpMethod(HttpMethod.Post)]
        [Resource("DeleteFoo")]
        // the parameter is serialized and used as the request body
        void Delete(FooByIdParameters parameters);
    }

    public class GetAllFoosResponse
    {
        public IEnumerable<Foo> D { get; set; }
    }

    public class GetFooByIdResponse
    {
        public Foo D { get; set; }
    }

    public class FooByIdParameters
    {
        public int id { get; set; }
    }

    public class AddParameters
    {
        public Foo foo { get; set; }
    }

    public class UpdateParameters
    {
        public int id { get; set; }
        public Foo value { get; set; }
    }
}
