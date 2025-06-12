using ScoreBoard.Models;

namespace ScoreBoard.DataBase;

public static class DB_Seeders
{
    private static List<Joueur> _listeSeedJoueurs = new List<Joueur>()
    {
        
        new Joueur 
        { 
            Id = 1, Nom = "Dupont", Prenom = "Jean", Equipe = "A",
            Telephone = "613-898-8989", Courriel = "LeJohnny@gmail.com"
        },
        new Joueur 
        { 
            Id = 2, Nom = "Martin", Prenom = "Marie", Equipe = "B",
            Telephone = "999-999-999", Courriel = "Marie999@gmail.com" 
        },
        new Joueur
        {
            Id = 3, Nom = "Hubert", Prenom = "Hubert", Equipe = "A",
            Telephone = "819-989-6969", Courriel = "hubhub@gmail.com"
        },
        new Joueur
        {
            Id = 4, Nom = "Martin", Prenom = "Jean-Louis", Equipe = "B",
            Telephone = "4204206969", Courriel = "LeGrosJoef@gmail.com"
        }
    };
    public static void SeedJoueurs(IApplicationBuilder appBuilder) 
    {

    }
}
