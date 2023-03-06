using Microsoft.AspNetCore.Identity;

namespace Slackoverflow.Models
{
    public class SlackUser : IdentityUser
    {
        // Self properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation properties
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QuestionComment> QuestionComments { get; set; }
        public virtual ICollection<AnswerComment> AnswerComments { get; set; }
        public virtual ICollection<QuestionVote> QuestionVotes { get; set; }
        public virtual ICollection<AnswerVote> AnswerVotes { get; set; }
    }
}
