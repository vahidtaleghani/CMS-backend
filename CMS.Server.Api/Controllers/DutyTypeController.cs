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
    public class DutyTypeController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public DutyTypeController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpGet]
        public ActionResult<IEnumerable<DutyType>> Get()
        {
            var dutyTypes = this._cmsServerOperationHandler.ReadDutyType();

            if (dutyTypes.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(dutyTypes));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize(new ServerResponse(dutyTypes.Message)));
        }
    }
}