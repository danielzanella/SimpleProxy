using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleProxy.Wcf.Test
{
    [ServiceContract]
    public interface IFooService
    {
        [OperationContract]
        [WebGet(UriTemplate = "")]
        IEnumerable<Foo> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "/{id}")]
        Foo GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "")]
        void Insert(Foo foo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/{id}")]
        void Update(string id, Foo foo);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void Delete(string id);
    }

    [DataContract]
    public class Foo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Bar { get; set; }
    }
}
