using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Server.Model.DBResponses
{
    public class CreateResponse : GenericDBResponse
    {
        public CreateResponse(bool isExecuted, string message) : base(isExecuted, message)
        {
        }
    }
}
