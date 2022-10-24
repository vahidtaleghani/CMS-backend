namespace CMS.Server.Model.DBResponses
{
    public class ReadResponse<T> : GenericDBResponse
    {
        public ReadResponse(bool isExecuted, string message, T data) : base(isExecuted, message)
        {
            this.Data = data;
        }

        public T Data { get; }
    }
}