use chrono::{DateTime, Local};

#[derive(Debug, Clone)]
pub struct ObjetLouable {
    pub nom: String,
    pub prix_par_heure: u32,
}

#[derive(Debug)]
pub struct Reservation {
    pub objet: ObjetLouable,
    pub date_heure: DateTime<Local>,
    pub duree_heures: u32,
}
