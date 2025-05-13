use chrono::{DateTime, Duration, Local};
use crate::entities::{ObjetLouable, Reservation};

pub struct ReservationService {
    pub historique: Vec<Reservation>,
}

impl ReservationService {
    pub fn new() -> Self {
        ReservationService {
            historique: Vec::new(),
        }
    }

    pub fn reserver(
        &mut self,
        objet: ObjetLouable,
        date_heure: DateTime<Local>,
        duree_heures: u32) -> u32 {
        let reservation = Reservation {
            objet: objet.clone(),
            date_heure,
            duree_heures,
        };
        self.historique.push(reservation);
        objet.prix_par_heure * duree_heures
    }

    pub fn afficher_historique(&self) {
        println!("\n📜 Rental history:");
        for r in &self.historique {
            println!(
                "- {} reserved at {} for {} hour(s)",
                r.objet.nom,
                r.date_heure.format("%Y-%m-%d %H:%M"),
                r.duree_heures
            );
        }
    }

    pub fn est_disponible(&self, objet: &ObjetLouable, date_debut: DateTime<Local>, duree_heures: u32) -> bool {
        let date_fin = date_debut + Duration::hours(duree_heures as i64);

        for reservation in &self.historique {
            if reservation.objet.nom == objet.nom {
                let debut_exist = reservation.date_heure;
                let fin_exist = debut_exist + Duration::hours(reservation.duree_heures as i64);

                if date_debut < fin_exist && date_fin > debut_exist {
                    return false;
                }
            }
        }
        true
    }
}
