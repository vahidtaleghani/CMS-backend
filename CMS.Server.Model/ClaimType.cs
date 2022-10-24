using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Server.Model
{
    public class ClaimType
    {
        public ClaimType(int claimTypeId, string type)
        {
            ClaimTypeId = claimTypeId;
            Type = type;
        }

        public int ClaimTypeId { get; set; }
        public string Type { get; set; }
    }
}
