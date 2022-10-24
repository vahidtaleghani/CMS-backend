namespace CMS.Server.Api
{
    using CMS.Server.BL;
    using CMS.Server.DL;
    using CMS.Server.Model;
    using CMS.Server.Model.ServerResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public CategoryController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            var category = JsonConvert.DeserializeObject<Category>(requestBody.ToString());
          
            var response = this._cmsServerOperationHandler.CreateCategory(category, "farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var response = this._cmsServerOperationHandler.ReadCategory("farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }
    }
}