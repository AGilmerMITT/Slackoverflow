namespace Slackoverflow.Models.ViewModels
{
    public class ViewQuestionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<string> Answers { get; set; } = new();
    }
}
