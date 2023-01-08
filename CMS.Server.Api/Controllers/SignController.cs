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
    public class SignController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public SignController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            var sign = JsonConvert.DeserializeObject<Sign>(requestBody.ToString());

            var response = this._cmsServerOperationHandler.CreateSign(sign);

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Info>> Get(int id)
        {
            var activeIds = this._cmsServerOperationHandler.ReadAllId().Data;

            if (activeIds.Contains(id))
            {
                var response = this._cmsServerOperationHandler.ReadSign(id);

                if (response.IsExecuted)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse("Error")));
        }
    }
}