using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slackoverflow.Models;

namespace Slackoverflow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerComment> AnswerComments { get; set; }
        public virtual DbSet<QuestionComment> QuestionComments { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionTag> QuestionTags { get; set; }
        public virtual DbSet<SlackUser> SlackUsers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<AnswerVote> AnswerVotes { get; set; }
        public virtual DbSet<QuestionVote> QuestionVotes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<QuestionTag>().HasKey(qt => new { qt.QuestionId, qt.TagId });

            builder.Entity<Question>()
                .HasOne(q => q.AcceptedAnswer)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey("Question", "AcceptedAnswerId");

            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .IsRequired(true);

            builder.Entity<AnswerVote>()
                .Property(av => av.VoteType)
                .HasDefaultValue(VoteType.Novote);

            builder.Entity<QuestionVote>()
                .Property(qv => qv.VoteType)
                .HasDefaultValue(VoteType.Novote);
        }
    }
}