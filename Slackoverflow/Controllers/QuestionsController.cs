using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Slackoverflow.Data;
using Slackoverflow.Models;
using Slackoverflow.Models.ViewModels;

namespace Slackoverflow.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _um;

        public QuestionsController(ApplicationDbContext db, UserManager<IdentityUser> um)
        {
            _db = db;
            _um = um;
        }

        public IActionResult Index()
        {
            var allQuestions = _db.Questions.ToList();

            return View(allQuestions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AskQuestionModel vm)
        {
            Question newQuestion = new();
            newQuestion.Title = vm.Title;
            newQuestion.Body = vm.Body;
            newQuestion.Date = DateTime.Now;

            newQuestion.SlackUserId = _um.GetUserId(User);

            _db.Add(newQuestion);
            _db.SaveChanges();

            return View();
        }

        public IActionResult ViewQuestion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = _db.Questions.FirstOrDefault(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            ViewQuestionModel vm = new();

            vm.Id = question.Id;
            vm.Title = question.Title;
            vm.Body = question.Body;

            var answers = _db.Answers.Where(a => a.QuestionId == question.Id);
            foreach (var a in answers)
            {
                vm.Answers.Add(a.Body);
            }

            return View(vm);
        }
    }
}
