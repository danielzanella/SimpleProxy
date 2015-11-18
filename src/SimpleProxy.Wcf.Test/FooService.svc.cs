using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleProxy.Wcf.Test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FooService : IFooService
    {
        private static List<Foo> _foos = new List<Foo>(new Foo[] { new Foo { Id = 1, Bar = "Bar1" }, new Foo { Id = 2, Bar = "Bar2" } });
        private static int _nextId = 3;

        // GET api/foo
        public IEnumerable<Foo> FindAll()
        {
            return _foos;
        }

        // GET api/foo/5
        public Foo GetById(string id)
        {
            int theId = 0;
            int.TryParse(id, out theId);
            return _foos.FirstOrDefault(x => x.Id == theId);
        }

        // POST api/foo
        public void Insert(Foo value)
        {
            lock (_foos)
            {
                value.Id = _nextId;
                _nextId++;
                _foos.Add(value);
            }
        }

        // PUT api/foo/5
        public void Update(string id, Foo value)
        {
            int theId = 0;
            int.TryParse(id, out theId);

            value.Id = theId;
            lock (_foos)
            {
                Foo old = _foos.FirstOrDefault(x => x.Id == theId);
                int index = _foos.IndexOf(old);
                _foos[index] = value;
            }
        }

        // DELETE api/foo/5
        public void Delete(string id)
        {
            int theId = 0;
            int.TryParse(id, out theId);

            lock (_foos)
            {
                Foo old = _foos.FirstOrDefault(x => x.Id == theId);
                _foos.Remove(old);
            }
        }
    }
}
