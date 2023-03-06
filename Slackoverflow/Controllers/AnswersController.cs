using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slackoverflow.Data;
using Slackoverflow.Models;
using Slackoverflow.Models.ViewModels;

namespace Slackoverflow.Controllers
{
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _um;
        public AnswersController(ApplicationDbContext context, UserManager<IdentityUser> um)
        {
            _db = context;
            _um = um;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnswerQuestion(int? id)
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

            return View(question);
        }

        [HttpPost]
        public IActionResult AnswerQuestion(AnswerQuestionModel vm)
        {
            Answer newAnswer = new();
            newAnswer.Body = vm.Body;
            newAnswer.QuestionId = vm.QuestionId;
            newAnswer.Date = DateTime.Now;

            newAnswer.SlackUserId = _um.GetUserId(User);

            return RedirectToAction("ViewQuestion", "Questions", new { id = vm.QuestionId });
        }
    }
}
