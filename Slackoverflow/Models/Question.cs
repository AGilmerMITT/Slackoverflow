namespace Slackoverflow.Models
{
    public class Question
    {
        // Self properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        // FK properties
        public string? SlackUserId { get; set; }
        public int? AcceptedAnswerId { get; set; }

        // Navigation properties
        public virtual SlackUser? SlackUser { get; set; }
        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QuestionComment> QuestionComments { get; set; }
        public virtual ICollection<QuestionVote> QuestionVotes { get; set; }
        public virtual Answer? AcceptedAnswer { get; set; }
    }
}
