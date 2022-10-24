using System;

namespace CMS.Models
{
	public class Comment
	{
        public Comment(int commentId, string commentText, DateTime commentDate, string userName, int contractId)
        {
            CommentId = commentId;
            CommentText = commentText;
            CommentDate = commentDate;
            UserName = userName;
            ContractId = contractId;
        }

        public int CommentId { get; set; }
		public string CommentText { get; set; }
		public DateTime CommentDate { get; set; }
		public string UserName { get; set; }
        public int ContractId { get; set; }
    }

}
