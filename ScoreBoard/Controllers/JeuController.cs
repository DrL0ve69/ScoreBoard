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
            ViewBag.Action = "Ajouter";
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter(Jeu jeu)
        {
            ViewBag.Action = "Ajouter";
            if (ModelState.IsValid)
            {
                _jeuRepository.Ajouter(jeu);
                return RedirectToAction("Index");
            }
            return View(jeu);
        }
        // GET: Jeu/Modifier/5
        public IActionResult Modifier(int id)
        {
            try 
            {
                Jeu? jeu = _jeuRepository.GetJeu(id);
                if (jeu == null)
                {
                    return NotFound($"Jeu with ID {id} not found.");
                }
                ViewBag.Action = "Modifier";
                return View("Ajouter",jeu);
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception (ex) if necessary
                return NotFound($"Jeu with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Modifier(Jeu jeu)
        {
            ViewBag.Action = "Modifier";
            if (ModelState.IsValid)
            {
                _jeuRepository.Modifier(jeu);
                return RedirectToAction("Index");
            }
            return View(jeu);
        }
        public IActionResult Supprimer(int id)
        {
            try 
            {
                _jeuRepository.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception (ex) if necessary
                return NotFound($"Jeu with ID {id} not found.");
            }
        }
    }
}
