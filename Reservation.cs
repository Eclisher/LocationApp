using System;

public class Reservation
{
    public ObjetLouable Objet { get; }
    public DateTime DateHeureDebut { get; }
    public int DureeHeures { get; }

    public Reservation(ObjetLouable objet, DateTime dateHeureDebut, int dureeHeures)
    {
        Objet = objet;
        DateHeureDebut = dateHeureDebut;
        DureeHeures = dureeHeures;
    }

    public int CalculerCout()
    {
        return Objet.PrixParHeure * DureeHeures;
    }

    public override string ToString()
    {
        return $"{Objet.Nom} réservé le {DateHeureDebut:yyyy-MM-dd HH:mm} pendant {DureeHeures}h - {CalculerCout()} Ar";
    }
}