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
    public class DepartmentTypeController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public DepartmentTypeController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentType>> Get()
        {
            var DepartmentStatus = this._cmsServerOperationHandler.ReadAllDepartmentType();

            if (DepartmentStatus.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(DepartmentStatus));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize(new ServerResponse(DepartmentStatus.Message)));
        }
    }
}