using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JeuController : Controller
    {
        private IJeuRepository _jeuRepository;
        public JeuController(IJeuRepository jeuRepository)
        {
            _jeuRepository = jeuRepository;
        }
        public IActionResult Index()
        {
            return View(_jeuRepository.ListeJeux);
        }
        public IActionResult Details(int id)
        {
            try 
            {
                return View(_jeuRepository.GetJeu(id));
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception (ex) if necessary
                return NotFound($"Jeu with ID {id} not found.");
            }

        }
        // GET: Jeu/Ajouter
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter(Jeu jeu)
        {
            if (ModelState.IsValid)
            {
                _jeuRepository.Ajouter(jeu);
                return RedirectToAction("Index");
            }
            return View(jeu);
        }
    }
}
