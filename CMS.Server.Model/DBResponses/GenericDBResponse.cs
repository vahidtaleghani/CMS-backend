namespace CMS.Server.Model.DBResponses
{
    public class GenericDBResponse
    {
        public GenericDBResponse(bool isExecuted, string message)
        {
            this.IsExecuted = isExecuted;
            this.Message = message;
        }

        public bool IsExecuted { get; }
        public string Message { get; }
    }
}
