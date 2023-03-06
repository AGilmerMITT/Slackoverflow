namespace Slackoverflow.Models
{
    public enum VoteType
    {
        Upvote = 1,
        Novote = 0,
        Downvote = -1
    }

    public class Vote
    {
        // Self properties
        public int Id { get; set; }
        public VoteType VoteType { get; set; }

        // FK properties
        public string SlackUserId { get; set; }

        // Navigation properties
        public virtual SlackUser SlackUser { get; set; }
    }

    public class QuestionVote : Vote
    {
        // FK properties
        public int QuestionId { get; set; }

        // Navigation properties
        public virtual Question Question { get; set; }
    }

    public class AnswerVote : Vote
    {
        // FK properties
        public int AnswerId { get; set; }

        // Navigation properties
        public virtual Answer Answer { get; set; }
    }
}
