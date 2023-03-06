namespace Slackoverflow.Models
{
    public class Comment
    {
        // Self properties
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        
        // FK properties
        public string SlackUserId { get; set; }

        // Navigation properties
        public virtual SlackUser SlackUser { get; set; }
    }

    public class QuestionComment : Comment
    {
        // FK properties
        public int QuestionId { get; set; }

        // Navigation properties
        public virtual Question Question { get; set; }
    }

    public class AnswerComment : Comment
    {
        // FK properties
        public int AnswerId { get; set; }

        // Navigation properties
        public virtual Answer Answer { get; set; }
    }
}
