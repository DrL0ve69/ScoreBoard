using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JeuController : Controller
    {
        private IJeu _jeuRepository;
        public JeuController(IJeu jeuRepository)
        {
            _jeuRepository = jeuRepository;
        }
        public IActionResult Index()
        {
            return View(_jeuRepository.ListeJeux);
        }
    }
}
