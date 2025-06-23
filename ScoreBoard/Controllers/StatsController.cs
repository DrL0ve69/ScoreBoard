using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /*
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
        */
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber
            )
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CourrielSortParm"] = sortOrder == "Courriel" ? "courriel_desc" : "Courriel";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            IQueryable<Joueur> joueurs = _joueurRepository.ListeJoueurs.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                joueurs = joueurs.Where(j => j.Nom.ToUpper().Contains(searchString.ToUpper()) ||
                    j.Prenom.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    joueurs = joueurs.OrderByDescending(j => j.Nom);
                    break;
                case "score_desc":
                    joueurs = joueurs.OrderByDescending(j => j.Jeux.Sum(jeu => jeu.ScoreJoueur));
                    break;
                case "courriel_desc":
                    joueurs = joueurs.OrderByDescending(j => j.Courriel);
                    break;
                default:
                    joueurs = joueurs.OrderBy(j => j.Nom);
                    break;
            }
            int pageSize = 1;

            return View(await PaginatedList<Joueur>.CreateAsync(joueurs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
    }
}
