using System.Collections.Generic;
using System.Web.Http;

namespace LightInject_issue_330.Controllers
{
    public class Foo : IFoo {}

    public interface IFoo {}

    public class ValuesController : ApiController
    {
        private readonly IFoo foo;
        private readonly IBar bar;

        public ValuesController(IFoo foo, IBar bar)
        {
            this.foo = foo;
            this.bar = bar;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value) {}

        // PUT api/values/5
        public void Put(int id, [FromBody] string value) {}

        // DELETE api/values/5
        public void Delete(int id) {}
    }
}