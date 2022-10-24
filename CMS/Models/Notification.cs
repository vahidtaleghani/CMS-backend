using System;

namespace CMS.Models
{
	public class Notification
	{
        public Notification(int notificationId, DateTime notificationDate, int notificationTypeId, string email, bool repetition, int contractId)
        {
            NotificationId = notificationId;
            NotificationDate = notificationDate;
            NotificationTypeId = notificationTypeId;
            Email = email;
            Repetition = repetition;
            ContractId = contractId;
        }

        public int NotificationId { get; set; }
        public DateTime NotificationDate { get; set; }
        public int NotificationTypeId { get; set; }
        public string Email { get; set; }
        public bool Repetition { get; set; }
        public int ContractId { get; set; }
    }
}
