using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        var reservationService = new ReservationService();

        var objets = new ObjetLouable[]
        {
            new ObjetLouable("Voiture", 10000),
            new ObjetLouable("Assiette", 2000),
            new ObjetLouable("Vélo", 5000),
            new ObjetLouable("Tente", 15000),
            new ObjetLouable("Ordinateur", 20000),
            new ObjetLouable("Caméra", 30000),
            new ObjetLouable("Projecteur", 25000),
        };

        Console.WriteLine("🎉 Bienvenue dans notre système de location !");
        Console.WriteLine("Voici les objets disponibles :");
        foreach (var obj in objets)
        {
            Console.WriteLine($"- {obj.Nom} ({obj.PrixParHeure} Ar/heure)");
        }

        while (true)
        {
            Console.WriteLine("\n🔸 Commandes disponibles :");
            Console.WriteLine("  l - Louer un objet");
            Console.WriteLine("  h - Voir l'historique des réservations");
            Console.WriteLine("  q - Quitter");

            Console.Write("👉 Que voulez-vous faire ? ");
            string commande = Console.ReadLine().Trim().ToLower();

            if (commande == "q")
                break;  

            else if (commande == "h")
            {
                reservationService.AfficherHistorique();
            }

            else if (commande == "l")
            {
                try
                {
                    Console.Write("\nQuel objet voulez-vous louer ? ");
                    string nom = Console.ReadLine().Trim().ToLower();
                    ObjetLouable objet = null;

                    foreach (var o in objets)
                    {
                        if (o.Nom.ToLower() == nom)
                        {
                            objet = o;
                            break;
                        }
                    }

                    if (objet == null)
                        throw new ArgumentException("❌ Objet inconnu.");

                    Console.Write("Entrez la date et l'heure (yyyy-MM-dd HH:mm) : ");
                    string dateStr = Console.ReadLine();
                    DateTime debut = DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                    if (debut < DateTime.Now)
                        throw new ArgumentException("La date de début doit être dans le futur.");

                    Console.Write("Durée (en heures) : ");
                    int duree = int.Parse(Console.ReadLine());

                    reservationService.ReserverObjet(objet, debut, duree);

                    int cout = objet.PrixParHeure * duree;
                    Console.WriteLine($"💰 Coût total : {cout} Ar");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erreur : {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("❌ Commande inconnue. Veuillez réessayer.");
            }
        }

        Console.WriteLine("👋 Merci d’avoir utilisé notre service !");
    }
}