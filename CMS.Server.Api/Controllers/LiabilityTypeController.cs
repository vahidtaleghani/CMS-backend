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
    public class LiabilityTypeController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public LiabilityTypeController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContractStatus>> Get()
        {
            var liabilityTypeResponse = this._cmsServerOperationHandler.ReadAllContractType();

            if (liabilityTypeResponse.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(liabilityTypeResponse));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize(new ServerResponse(liabilityTypeResponse.Message)));
        }
    }
}