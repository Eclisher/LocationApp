using System;
using System.Collections.Generic;

public class ReservationService
{
    private readonly List<Reservation> reservations = new List<Reservation>();

    public bool EstDisponible(ObjetLouable objet, DateTime debut, int duree)
    {
        foreach (var r in reservations)
        {
            DateTime rDebut = r.DateHeureDebut;
            DateTime rFin = rDebut.AddHours(r.DureeHeures);
            DateTime demandeFin = debut.AddHours(duree);

            bool chevauchement = objet.Nom == r.Objet.Nom &&
                                 debut < rFin && demandeFin > rDebut;
            if (chevauchement)
                return false;
        }
        return true;
    }

    public void ReserverObjet(ObjetLouable objet, DateTime debut, int duree)
    {
        if (debut < DateTime.Now)
            throw new InvalidOperationException("❌ Impossible de réserver pour une date passée.");

        if (!EstDisponible(objet, debut, duree))
            throw new InvalidOperationException("❌ Cet objet est déjà réservé pour ce créneau.");

        reservations.Add(new Reservation(objet, debut, duree));
        Console.WriteLine("✅ Réservation confirmée !");
    }

    public void AfficherHistorique()
    {
        Console.WriteLine("\n📜 Historique des réservations :");
        if (reservations.Count == 0)
        {
            Console.WriteLine("Aucune réservation enregistrée.");
            return;
        }

        foreach (var r in reservations)
        {
            Console.WriteLine("- " + r.ToString());
        }
    }
}
