package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
	"time"
	"strconv"
)

type ObjetLouable struct {
	Nom          string
	PrixParHeure int
}

type Reservation struct {
	Objet ObjetLouable
	Date  time.Time
	Duree int
	Cout  int
}

type ReservationService struct {
	Historique []Reservation
}

func (rs *ReservationService) EstDisponible(objet ObjetLouable, debut time.Time, duree int) bool {
	fin := debut.Add(time.Duration(duree) * time.Hour)

	for _, r := range rs.Historique {
		if r.Objet.Nom != objet.Nom {
			continue
		}
		rDebut := r.Date
		rFin := rDebut.Add(time.Duration(r.Duree) * time.Hour)

		if debut.Before(rFin) && fin.After(rDebut) {
			return false
		}
	}
	return true
}

func (rs *ReservationService) Reserver(objet ObjetLouable, date time.Time, duree int) {
	if !rs.EstDisponible(objet, date, duree) {
		fmt.Println("❌ Cet objet est déjà réservé à ce moment. Veuillez choisir un autre créneau.")
		return
	}
	cout := objet.PrixParHeure * duree
	reservation := Reservation{Objet: objet, Date: date, Duree: duree, Cout: cout}
	rs.Historique = append(rs.Historique, reservation)
	fmt.Printf("✅ Réservation confirmée pour %s à %s pendant %d heures.\n", objet.Nom, date.Format("2006-01-02 15:04"), duree)
	fmt.Printf("💰 Coût total : %d Ar\n", cout)
}

func (rs *ReservationService) AfficherHistorique() {
	fmt.Println("\n📜 Historique des réservations :")
	if len(rs.Historique) == 0 {
		fmt.Println("Aucune réservation effectuée.")
		return
	}
	for _, r := range rs.Historique {
		fmt.Printf("- %s | %s | %d h | %d Ar\n", r.Objet.Nom, r.Date.Format("2006-01-02 15:04"), r.Duree, r.Cout)
	}
}

func main() {
	reader := bufio.NewReader(os.Stdin)
	objets := []ObjetLouable{
		{"voiture", 10000},
		{"assiette", 2000},
		{"vélo", 5000},
		{"téléphone", 15000},
		{"ordinateur", 20000},
		{"maison", 50000},
	}

	service := ReservationService{}

	fmt.Println("🎉 Bienvenue dans notre système de location !")
	for {
		fmt.Println("\nVoici les objets disponibles :")
		for _, o := range objets {
			fmt.Printf("- %s (%d Ar/heure)\n", o.Nom, o.PrixParHeure)
		}

		fmt.Print("\nQuel objet voulez-vous louer ? (ou 'h' pour voir l'historique, 'q' pour quitter) : ")
		input, _ := reader.ReadString('\n')
		choix := strings.TrimSpace(strings.ToLower(input))

		if choix == "q" {
			break
		}

		if choix == "h" {
			service.AfficherHistorique()
			continue
		}

		var objet *ObjetLouable
		for i := range objets {
			if strings.ToLower(objets[i].Nom) == choix {
				objet = &objets[i]
				break
			}
		}
		if objet == nil {
			fmt.Println("❌ Objet inconnu.")
			continue
		}

		fmt.Print("Entrez la date et l'heure (format: yyyy-MM-dd HH:mm) : ")
		dateStr, _ := reader.ReadString('\n')
		dateStr = strings.TrimSpace(dateStr)
		date, err := time.Parse("2006-01-02 15:04", dateStr)
		if err != nil {
			fmt.Println("❌ Format de date invalide.")
			continue
		}
		if date.Before(time.Now()) {
			fmt.Println("❌ Vous ne pouvez pas réserver une date passée.")
			continue
		}

		fmt.Print("Durée (en heures) : ")
		dureeStr, _ := reader.ReadString('\n')
		dureeStr = strings.TrimSpace(dureeStr)
		duree, err := strconv.Atoi(dureeStr)
		if err != nil || duree <= 0 {
			fmt.Println("❌ Durée invalide.")
			continue
		}

		service.Reserver(*objet, date, duree)
	}

	fmt.Println("👋 Merci d’avoir utilisé notre service !")
}