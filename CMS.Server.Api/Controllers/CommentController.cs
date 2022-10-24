namespace CMS.Server.Api
{
    using CMS.Server.BL;
    using CMS.Server.Model;
    using CMS.Server.Model.ServerResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;


    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public CommentController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            var comment = JsonConvert.DeserializeObject<Comment>(requestBody.ToString());

            var response = this._cmsServerOperationHandler.CreateComment(comment, "farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get()
        {
            var response = this._cmsServerOperationHandler.ReadComment("farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }
    }
}