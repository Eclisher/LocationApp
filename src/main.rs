mod entities;
mod service;

use std::io::{self, Write};
use chrono::{DateTime, Local, TimeZone, NaiveDateTime};
use service::ReservationService;
use entities::ObjetLouable;

fn main() {
    let objets = vec![
        ObjetLouable { nom: "voiture".to_string(), prix_par_heure: 10_000 },
        ObjetLouable { nom: "assiette".to_string(), prix_par_heure: 2_000 },
        ObjetLouable { nom: "vélo".to_string(), prix_par_heure: 5_000 },
        ObjetLouable { nom: "téléphone".to_string(), prix_par_heure: 15_000 },
        ObjetLouable { nom: "ordinateur".to_string(), prix_par_heure: 20_000 },
        ObjetLouable { nom: "maison".to_string(), prix_par_heure: 50_000 },
    ];

    let mut service = ReservationService::new();

    println!("🎉 Welcome to the Rental System!");
    println!("Available items:");
    for obj in &objets {
        println!("- {} ({} Ar/hour)", obj.nom, obj.prix_par_heure);
    }

    loop {
        print!("\nEnter the name of the item to rent (or 'h' to view history): ");
        io::stdout().flush().unwrap();
        let mut nom = String::new();
        io::stdin().read_line(&mut nom).unwrap();
        let nom = nom.trim().to_lowercase();

        if nom == "h" {
            service.afficher_historique();
            continue;
        }

        let objet = objets.iter().find(|o| o.nom.to_lowercase() == nom);
        if objet.is_none() {
            println!("❌ Unknown item.");
            continue;
        }
        let objet = objet.unwrap().clone();

        print!("Enter date and time (yyyy-MM-dd HH:mm): ");
        io::stdout().flush().unwrap();
        let mut date_str = String::new();
        io::stdin().read_line(&mut date_str).unwrap();

        let date_result = NaiveDateTime::parse_from_str(date_str.trim(), "%Y-%m-%d %H:%M");
        if let Ok(naive) = date_result {
            let date_heure: DateTime<Local> = Local.from_local_datetime(&naive).unwrap();
            if date_heure < Local::now() {
                println!("❌ Error: Date is in the past.");
                continue;
            }

            print!("Duration (hours): ");
            io::stdout().flush().unwrap();
            let mut duree_str = String::new();
            io::stdin().read_line(&mut duree_str).unwrap();
            let duree: u32 = match duree_str.trim().parse() {
                Ok(n) => n,
                Err(_) => {
                    println!("❌ Invalid duration.");
                    continue;
                }
            };

            if service.est_disponible(&objet, date_heure, duree) {
                let cout = service.reserver(objet, date_heure, duree);
                println!("💰 Total cost: {} Ar", cout);
            } else {
                println!("❌ This item is already booked for that time period.");
            }

        } else {
            println!("❌ Invalid date format.");
        }

        print!("Do you want to make another reservation? (y/n): ");
        io::stdout().flush().unwrap();
        let mut again = String::new();
        io::stdin().read_line(&mut again).unwrap();
        if again.trim().to_lowercase() != "y" {
            break;
        }
    }

    println!("👋 Thank you for using our service!");
}
