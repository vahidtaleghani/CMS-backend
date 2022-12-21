namespace CMS.Server.Api
{
    using CMS.Server.BL;
    using CMS.Server.DL;
    using CMS.Server.Model;
    using CMS.Server.Model.ServerResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public ContractController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            //var response = this._cmsServerOperationHandler.IsContractActive("farasat-user-token");

            var response = this._cmsServerOperationHandler.IsContractActive(id);

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(response.Data));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            Contract contract = null;
            var body = JsonConvert.DeserializeObject<dynamic>(requestBody.ToString());

           var value = body["id"].Value;

            if (value != null)
            {
                contract = JsonConvert.DeserializeObject<Contract>(requestBody.ToString());
            }

            var response = this._cmsServerOperationHandler.CreateContract(contract);

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }
    }
}