SimpleProxy
======
Simple RealProxy implementation that dispatches method calls as HTTP requests to remote servers.

Features
======
- Quickly create a client for a REST service;
- Can be used with anything that accepts and responds using JSON-formatted data;
- Manipulate headers sent along with requests, and inspect headers received in responses;
- Inspect other response information, like the HTTP status code, total time elapsed and content length;

Quick Instructions
======
Considering a remote URL like `http://some-server/api/foo`, where the fragment `foo` maps to a `FooController`:

1. Create an interface with methods that describe the requests and parameters you want to execute:

        public interface IFoo {
            public IEnumerable<Bar> GetAllBars();
            public void AddBar(Bar bar);
            public Bar GetBar(int id);
            // ...
        }
    
2. Decorate the interface with `ResourceAttribute`, specifying the fragment that corresponds to the controller:

        [Resource("foo")]
        public interface IFoo {

3. Decorate the method call with `HttpMethodAttribute` describing the HTTP verb used in the request:

            // GET /foo
            [HttpMethod(HttpMethod.Get)]
            public IEnumerable<Bar> GetAllBars();

            // POST /foo
            [HttpMethod(HttpMethod.Post)]
            public void Add(Bar bar);

4. For methods that should use parameter values as part of the query string, decorate them with `ResourceAttribute` specifying a fragment with format codes, and the list of parameters used in the query string:

            // GET /foo/1
            [Resource("{0}", "id")]
            public Bar GetBar(int id);

5. To create the proxy instance and make a request, call Proxy.For<T>, specifying the root url:

            var configuration = new ProxyConfiguration("http://some-server/api");
            var remote = Proxy.For<IFoo>(configuration);

            var allBars = remote.GetAllBars();

6. Optionally, add request headers to the configuration object before you create the proxy instance:

            configuration.RequestHeaders["Some-Header"] = "some value";
            var remote = Proxy.For<IFoo>(configuration);  // will always send Some-Header
            
7. Inspect response headers by obtaining a context when calling Proxy.For<T>:

            ProxyContext theContext;
            var remote = Proxy.For<IFoo>(configuration, out theContext);
            // make a request
            var responseHeaderValue = theContext.Requests.Last().ResponseHeaders["Some-Header"];


Samples
======
See src/SimpleProxy.Sample for usage examples.

License
======
Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.

