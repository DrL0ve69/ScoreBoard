using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

namespace ScoreBoard.Controllers
{
    public class StatsController : Controller
    {
        private IJeuRepository _jeuRepository;
        private IJoueurRepository _joueurRepository;
        public StatsController(IJeuRepository jeuRepository, IJoueurRepository joueurRepository)
        {
            _jeuRepository = jeuRepository;
            _joueurRepository = joueurRepository;
        }
        public IActionResult Index()
        {
            DataViewmodel dataViewModel = new DataViewmodel
            {
                Joueurs_VM = _joueurRepository.ListeJoueurs
                    .OrderBy(j => -j.Jeux.Sum(jeu=> jeu.ScoreJoueur)).ToList(),
                Jeux_VM = _jeuRepository.ListeJeux,
               
            };
            return View(dataViewModel);
        }
    }
}
