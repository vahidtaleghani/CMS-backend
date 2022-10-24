namespace CMS.Server.Model
{
    using System;
    public class Comment
    {
        public Comment(int id, string text, DateTime date, string username, int contractId)
        {
            Id = id;
            Text = text;
            Date = date;
            Username = username;
            ContractId = contractId;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
        public int ContractId { get; set; }
    }

}
