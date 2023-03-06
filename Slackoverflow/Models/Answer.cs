namespace Slackoverflow.Models
{
    public class Answer
    {
        // Self properties
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        // FK properties
        public string? SlackUserId { get; set; }
        public int QuestionId { get; set; }

        // Navigation properties
        public virtual SlackUser? SlackUser { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<AnswerComment> AnswerComments { get; set; }
        public virtual ICollection<AnswerVote> AnswerVotes { get; set; }
    }
}
