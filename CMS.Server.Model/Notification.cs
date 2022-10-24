namespace CMS.Server.Model
{
    using System;
    public class Notification
    {
        public Notification(int id, DateTime date, int notificationTypeId, string email, bool isRepeatitionAllowed, int contractId)
        {
            Id = id;
            Date = date;
            NotificationTypeId = notificationTypeId;
            Email = email;
            IsRepeatitionAllowed = isRepeatitionAllowed;
            ContractId = contractId;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NotificationTypeId { get; set; }
        public string Email { get; set; }
        public bool IsRepeatitionAllowed { get; set; }
        public int ContractId { get; set; }
    }
}