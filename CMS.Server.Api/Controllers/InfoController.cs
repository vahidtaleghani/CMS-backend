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
    public class InfoController : AbstractController<Info>
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public InfoController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }
        public override Task<ActionResult> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override ActionResult<IEnumerable<Info>> Get()
        {
            var response = this._cmsServerOperationHandler.ReadInfoByUserToken("farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }


        public override ActionResult Post(object requestBody)
        {
            var info = JsonConvert.DeserializeObject<Info>(requestBody.ToString());

            var response = this._cmsServerOperationHandler.CreateInfo(info, "farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }

        public override Task<ActionResult> Put(string requestBody)
        {
            throw new System.NotImplementedException();
        }
    }
}