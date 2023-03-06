namespace Slackoverflow.Models
{
    public class Tag
    {
        // Self properties
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
    }
}
