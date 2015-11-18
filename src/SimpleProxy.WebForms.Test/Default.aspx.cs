using SimpleProxy.WebForms.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleProxy.WebForms.Test
{
    public partial class Default : System.Web.UI.Page
    {
        private static List<Foo> _foos = new List<Foo>(new Foo[] { new Foo { Id = 1, Bar = "Bar1" }, new Foo { Id = 2, Bar = "Bar2" } });
        private static int _nextId = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static IEnumerable<Foo> GetAllFoos()
        {
            return _foos;
        }
        
        [WebMethod]
        public static Foo GetFooById(int id) 
        {
            return _foos.FirstOrDefault(x => x.Id == id);
        }

        [WebMethod]
        public static void AddFoo(Foo foo)
        {
            foo.Id = _nextId;
            _nextId++;
            _foos.Add(foo);
        }

        [WebMethod]
        public static void UpdateFoo(int id, Foo value)
        {
            value.Id = id;
            lock (_foos)
            {
                Foo old = _foos.FirstOrDefault(x => x.Id == id);
                int index = _foos.IndexOf(old);
                _foos[index] = value;
            }
        }

        [WebMethod]
        public static void DeleteFoo(int id)
        {
            lock (_foos)
            {
                Foo old = _foos.FirstOrDefault(x => x.Id == id);
                _foos.Remove(old);
            }
        }
    }
}