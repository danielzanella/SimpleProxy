namespace SimpleProxy.WebApi.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using SimpleProxy.WebApi.Test.Models;

    public class FooController : ApiController
    {
        private static List<Foo> _foos = new List<Foo>(new Foo[] { new Foo { Id = 1, Bar = "Bar1" }, new Foo { Id = 2, Bar = "Bar2" } });
        private static int _nextId = 3;

        // GET api/foo
        public IEnumerable<Foo> Get()
        {
            return _foos;
        }

        // GET api/foo/5
        public Foo Get(int id)
        {
            return _foos.FirstOrDefault(x => x.Id == id);
        }

        // POST api/foo
        public void Post([FromBody]Foo value)
        {
            lock (_foos)
            {
                value.Id = _nextId;
                _nextId++;
                _foos.Add(value);
            }
        }

        // PUT api/foo/5
        public void Put(int id, [FromBody]Foo value)
        {
            value.Id = id;
            lock (_foos)
            {
                Foo old = _foos.FirstOrDefault(x => x.Id == id);
                int index = _foos.IndexOf(old);
                _foos[index] = value;
            }
        }

        // DELETE api/foo/5
        public void Delete(int id)
        {
            lock (_foos)
            {
                Foo old = _foos.FirstOrDefault(x => x.Id == id);
                _foos.Remove(old);
            }
        }
    }
}
