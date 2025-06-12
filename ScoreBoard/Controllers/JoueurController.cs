using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers;

public class JoueurController : Controller
{
    private IJoueurRepository _joueurRepository;
    public JoueurController(IJoueurRepository joueurRepository)
    {
        _joueurRepository = joueurRepository;
    }
    public IActionResult Index()
    {
        return View(_joueurRepository.ListeJoueurs);
    }
    // GET: Joueur/Modifier/5
    public IActionResult Modifier(int id)
    {
        Joueur? joueur = _joueurRepository.GetJoueur(id);
        if (joueur == null)
        {
            return NotFound();
        }
        return View(joueur);
    }
    [HttpPost]
    public IActionResult Modifier(Joueur joueur)
    {
        if (ModelState.IsValid)
        {
            _joueurRepository.Modifier(joueur);
            return RedirectToAction("Index");
        }
        return View(joueur);
    }
    // Action pour rediriger le joueur vers la page de confirmation de suppression
    public IActionResult SupprimerConfirmer(int id)
    {
        Joueur? joueur = _joueurRepository.GetJoueur(id);
        if (joueur == null)
        {
            return NotFound();
        }
        return View("Supprimer",joueur);
    }
    public IActionResult Supprimer(int id) 
    {
        _joueurRepository.Supprimer(id);
        return RedirectToAction("Index");
    }
}
