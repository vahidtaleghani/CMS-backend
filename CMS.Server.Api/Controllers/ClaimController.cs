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
    public class ClaimController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public ClaimController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            var Claim = JsonConvert.DeserializeObject<Claim>(requestBody.ToString());

            var response = this._cmsServerOperationHandler.CreateClaim(Claim, "farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }


        [HttpGet]
        public ActionResult Get()
        {
            var response = this._cmsServerOperationHandler.ReadClaim("farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = this._cmsServerOperationHandler.DeleteClaim(id);

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }
    }
}