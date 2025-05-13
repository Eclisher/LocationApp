<?php


require_once 'Objet.php';
require_once 'Reservation.php';
require_once 'ReservationService.php';


$service = new ServiceReservation();

$objets = [
    new Objet("voiture", 10000),
    new Objet("assiette", 2000),
    new Objet("vélo", 5000),
    new Objet("téléphone", 15000),
    new Objet("ordinateur", 20000),
    new Objet("maison", 50000),
];

echo "🎉 Bienvenue dans le Système de Location !\nObjets disponibles :\n";
foreach ($objets as $o) {
    echo "- {$o->nom} ({$o->prixParHeure} Ar/heure)\n";
}

while (true) {
    echo "\nEntrez le nom de l'objet à louer (ou 'h' pour l'historique, 'q' pour quitter) : ";
    $nom = strtolower(trim(readline()));

    if ($nom === 'q') break;
    if ($nom === 'h') {
        $service->afficherHistorique();
        continue;
    }

    $objet = null;
    foreach ($objets as $o) {
        if (strtolower($o->nom) === $nom) {
            $objet = $o;
            break;
        }
    }

    if (!$objet) {
        echo "❌ Objet inconnu.\n";
        continue;
    }

    echo "Entrez la date et l'heure (YYYY-MM-DD HH:MM) : ";
    $dateStr = trim(readline());
    $debut = DateTime::createFromFormat('Y-m-d H:i', $dateStr);
    if (!$debut || $debut < new DateTime()) {
        echo "❌ Date invalide ou dans le passé.\n";
        continue;
    }

    echo "Durée (en heures) : ";
    $duree = intval(trim(readline()));
    if ($duree <= 0) {
        echo "❌ Durée invalide.\n";
        continue;
    }

    $cout = $service->reserver($objet, $debut, $duree);
    if ($cout === null) {
        echo "❌ Cet objet est déjà réservé pendant cette période.\n";
    } else {
        echo "✅ Réservation réussie ! Coût : {$cout} Ar\n";
    }
}