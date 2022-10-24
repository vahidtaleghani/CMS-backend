namespace CMS.Server.DL.DBConfig
{
    using Npgsql;
    using System.Data;

    public class CMSDBConnection
    {
        private readonly DBConfigData _configData;

        public CMSDBConnection(DBConfigData configData)
        {
            this._configData = configData;
        }

        protected IDbConnection Connect
        {
            get =>(new NpgsqlConnection($"Server={_configData.Host};Port={_configData.Port};User Id={_configData.Username};Password={_configData.Password};Database={_configData.Database}"));
        }
    }
}