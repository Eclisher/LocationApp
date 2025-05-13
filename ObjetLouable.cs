public class ObjetLouable
{
    public string Nom { get; }
    public int PrixParHeure { get; }

    public ObjetLouable(string nom, int prixParHeure)
    {
        Nom = nom;
        PrixParHeure = prixParHeure;
    }
}