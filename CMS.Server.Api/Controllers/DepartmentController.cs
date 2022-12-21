namespace CMS.Server.Api
{
    using CMS.Server.BL;
    using CMS.Server.Model;
    using CMS.Server.Model.ServerResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    //using System.Text.Json;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly CMSServerOperationsHandler _cmsServerOperationHandler;
        public DepartmentController()
        {
            this._cmsServerOperationHandler = new CMSServerOperationsHandler();
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Info>> Get(int id)
        {
            var activeIds = this._cmsServerOperationHandler.ReadAllActiveId().Data;

            if (activeIds.Contains(id))
            {
                var DepartmentStatus = this._cmsServerOperationHandler.ReadDepartment(id);

                if (DepartmentStatus.IsExecuted)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(DepartmentStatus));
                }

                return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(DepartmentStatus.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse("Error")));
        }
       

        [HttpPost]
        public ActionResult Post(object requestBody)
        {
            var departments = JsonConvert.DeserializeObject<List<Department>>(requestBody.ToString());

            var response = this._cmsServerOperationHandler.CreateDepartment(departments);

            if (response.IsExecuted)
            {
                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
            }

            return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(new ServerResponse(response.Message)));
        }
    }
}