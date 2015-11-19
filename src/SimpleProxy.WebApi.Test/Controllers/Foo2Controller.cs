namespace SimpleProxy.WebApi.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using SimpleProxy.WebApi.Test.Models;
    using System.Net.Http;
    using System.Net;
    using System.Web.Http.Description;
    using System;

    public class Foo2Controller : ApiController
    {
        private static List<Foo> _foos = new List<Foo>(new Foo[] { new Foo { Id = 1, Bar = "Bar1" }, new Foo { Id = 2, Bar = "Bar2" } });
        private static int _nextId = 3;

        // GET api/foo
        [ResponseType(typeof(IEnumerable<Foo>))]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_foos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/foo/5
        [ResponseType(typeof(Foo))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = _foos.FirstOrDefault(x => x.Id == id);

                if (null != result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            } 
        }

        // POST api/foo
        public IHttpActionResult Post([FromBody]Foo value)
        {
            try
            {
                lock (_foos)
                {
                    value.Id = _nextId;
                    _nextId++;
                    _foos.Add(value);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/foo/5
        public IHttpActionResult Put(int id, [FromBody]Foo value)
        {
            try
            {
                value.Id = id;
                lock (_foos)
                {
                    Foo old = _foos.FirstOrDefault(x => x.Id == id);

                    if (null == old) return NotFound();

                    int index = _foos.IndexOf(old);
                    _foos[index] = value;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/foo/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                lock (_foos)
                {
                    Foo old = _foos.FirstOrDefault(x => x.Id == id);

                    if (null == old) return NotFound();

                    _foos.Remove(old);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
