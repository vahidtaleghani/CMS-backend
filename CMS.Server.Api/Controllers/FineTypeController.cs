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
    public class FineTypeController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public FineTypeController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpGet]
        public ActionResult<IEnumerable<FineType>> Get()
        {
            var FineStatus = this._cmsServerOperationHandler.ReadFineType();

            if (FineStatus.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(FineStatus));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize(new ServerResponse(FineStatus.Message)));
        }
    }
}