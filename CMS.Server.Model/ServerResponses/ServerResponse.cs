namespace CMS.Server.Model.ServerResponses
{
    public class ServerResponse
    {
        public ServerResponse(string message)
        {
            this.Message = message;
        }
        public string Message { get; } 
    }
}