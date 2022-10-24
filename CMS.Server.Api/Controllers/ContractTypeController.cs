namespace CMS.Server.Api
{
    using CMS.Server.BL;
    using CMS.Server.Model;
    using CMS.Server.Model.ServerResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ContractTypeController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public ContractTypeController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContractType>> Get()
        {
            var contractType = this._cmsServerOperationHandler.ReadAllContractType();

            if (contractType.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(contractType));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize(new ServerResponse(contractType.Message)));
        }
    }
}