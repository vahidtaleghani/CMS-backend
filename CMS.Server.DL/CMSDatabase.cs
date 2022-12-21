using CMS.Server.DL.DBConfig;
using CMS.Server.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Server.DL
{
    public class CMSDatabase
    {
        private readonly DBConfigData _configData;


        public CMSDatabase()
        {
            IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile(@"C:\Users\Farasat\source\repos\CMS-backend\CMS.Server.Api\appsettings.json", false, true)
        .Build();

            var section = config.GetSection(nameof(DBConfigData));

            this._configData = section.Get<DBConfigData>();

            this.ContractRepository = new ContractRepository(this._configData);

        }

        public IContractRepository ContractRepository { get; private set; }
    }
}