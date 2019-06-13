using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ancient.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int FeedbackUserId { get; set; }
        public int FeedbackPoetryId { get; set; }
        public string FeedbackContent { get; set; }
    }
}
