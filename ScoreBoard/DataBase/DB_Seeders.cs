using ScoreBoard.Models;

namespace ScoreBoard.DataBase;

public static class DB_Seeders
{
    private static List<Jeu> _listeSeedJeux = new List<Jeu>()
    {
                new Jeu {Nom = "The Legend of Zelda: Breath of the Wild", DateSortie = new DateTime(2017, 3, 3), Description = "Jeu d'action-aventure en monde ouvert", JoueurId = 1, ScoreJoueur = 60, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Super Mario Odyssey", DateSortie = new DateTime(2017, 10, 27), Description = "Jeu de plateforme en monde ouvert", JoueurId = 1, ScoreJoueur = 50, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Red Dead Redemption 2", DateSortie = new DateTime(2018, 10, 26), Description = "Jeu d'action-aventure en monde ouvert dans le Far West", JoueurId = 1, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Assassin's Creed Odyssey", DateSortie = new DateTime(2018, 10, 5), Description = "Jeu d'action-aventure en monde ouvert dans la Grèce antique", JoueurId = 2, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "God of War", DateSortie = new DateTime(2018, 4, 20), Description = "Jeu d'action-aventure en monde ouvert inspiré de la mythologie nordique", JoueurId = 2, ScoreJoueur = 30, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Cyberpunk 2077", DateSortie = new DateTime(2020, 12, 10), Description = "Jeu de rôle en monde ouvert futuriste", JoueurId = 3, ScoreJoueur = 70, DateEnregistrement = DateTime.Now},
                new Jeu {Nom = "The Last of Us Part II", DateSortie = new DateTime(2020, 6, 19), Description = "Jeu d'action-aventure et de survie post-apocalyptique", JoueurId = 4,  ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Animal Crossing: New Horizons", DateSortie = new DateTime(2020, 3, 20), Description = "Jeu de simulation de vie en monde ouvert", JoueurId = 4, ScoreJoueur = 10, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Doom Eternal", DateSortie = new DateTime(2020, 3, 20), Description = "Jeu de tir à la première personne", JoueurId = 4, ScoreJoueur = 90, DateEnregistrement = DateTime.Now },
                new Jeu {Nom = "Ghost of Tsushima", DateSortie = new DateTime(2020, 7, 17), Description = "Jeu d'action-aventure en monde ouvert dans le Japon féodal", JoueurId = 5, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                new Jeu 
                {
                    Nom = "Hades", DateSortie = new DateTime(2020, 9, 17), Description = "Jeu de rôle d'action roguelike", JoueurId = 5, ScoreJoueur = 40, DateEnregistrement = DateTime.Now 
                }
    };

    private static List<Joueur> _listeSeedJoueurs = new List<Joueur>()
    {
        
        new Joueur 
        { 
            Nom = "Dupont", Prenom = "Jean", Equipe = "AAAA",
            Telephone = "613-898-8989", Courriel = "LeJohnny@scoreboard.ca"
        },
        new Joueur 
        { 
            Nom = "Martin", Prenom = "Marie", Equipe = "BBBB",
            Telephone = "999-999-999", Courriel = "Marie999@scoreboard.ca"
        },
        new Joueur
        {
            Nom = "Hubert", Prenom = "Hubert", Equipe = "CCC",
            Telephone = "819-989-6969", Courriel = "hubhub@scoreboard.ca"
        },
        new Joueur
        {
            Nom = "Martin", Prenom = "Jean-Louis", Equipe = "BBBB",
            Telephone = "4204206969", Courriel = "LeGrosJoef@scoreboard.ca"
        },
        new Joueur
        {
            Nom = "Simpson", Prenom = "Homer", Equipe = "AAAA",
            Telephone = "819-989-6969", Courriel = "hubhub@scoreboard.ca"
        },
        new Joueur
        {
            Nom = "Gatineau", Prenom = "Gino", Equipe = "BBBB",
            Telephone = "4204206969", Courriel = "LedoubleG@scoreboard.ca"
        }
    };
    public static void Seed(IApplicationBuilder appBuilder) 
    {
        DB_ScoreBoardContext context = appBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<DB_ScoreBoardContext>();

        if (!context.Joueurs.Any())
        {
            context.Joueurs.AddRange(_listeSeedJoueurs);
            context.SaveChanges();
        }
        if (!context.Jeux.Any())
        {
            List<int> idRecharges = new List<int>();
            _listeSeedJoueurs.ForEach(joueur => idRecharges.Add(joueur.Id));

            int compteur = 0;

            foreach (Jeu jeu in _listeSeedJeux) 
            {
                if (compteur >= idRecharges.Count()) compteur = 0;
                jeu.JoueurId = idRecharges[compteur];
                // Associer le joueur à chaque jeu en utilisant l'ID du joueur
                jeu.Joueur = _listeSeedJoueurs.FirstOrDefault(j => j.Id == jeu.JoueurId);
                compteur++;
            }
            context.Jeux.AddRange(_listeSeedJeux);
            context.SaveChanges();
        }
    }
}
