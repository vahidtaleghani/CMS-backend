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
    public class ContractorController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public ContractorController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            var contractor = JsonConvert.DeserializeObject<Contractor>(requestBody.ToString());

            var response = this._cmsServerOperationHandler.CreateContractor(contractor, "farasat-user-token");

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = this._cmsServerOperationHandler.ReadContractor("farasat-user-token");

            if (response.IsExecuted)
            {
                var serializedData = JsonConvert.SerializeObject(response.Data);
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }
    }
}