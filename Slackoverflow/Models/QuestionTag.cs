namespace Slackoverflow.Models
{
    public class QuestionTag
    {
        // FK properties
        public int QuestionId { get; set; }
        public int TagId { get; set; }

        // Navigation properties
        public virtual Question Question { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
