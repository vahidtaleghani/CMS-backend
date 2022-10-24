namespace CMS.Server.Api
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<T> : ControllerBase where T : class
    {
        [HttpGet]
        public abstract ActionResult<IEnumerable<T>> Get();

        [HttpPost]
        public abstract ActionResult Post(object requestBody);

        [HttpPut]
        public abstract Task<ActionResult> Put(string requestBody);

        [HttpDelete("{id}")]
        public abstract Task<ActionResult> Delete(int id);
    }
}