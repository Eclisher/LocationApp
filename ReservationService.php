<?php

require_once 'Objet.php';
require_once 'Reservation.php';

class ServiceReservation {
    private array $historique = [];

    public function reserver(Objet $objet, DateTime $debut, int $duree): ?int {
        foreach ($this->historique as $res) {
            if (
                $res->objet->nom === $objet->nom &&
                $debut < $res->getFin() &&
                $res->debut < (clone $debut)->modify("+{$duree} hour")
            ) {
                return null;
            }
        }

        $reservation = new Reservation($objet, $debut, $duree);
        $this->historique[] = $reservation;
        return $objet->prixParHeure * $duree;
    }

    public function afficherHistorique(): void {
        if (empty($this->historique)) {
            echo "Aucune réservation pour le moment.\n";
            return;
        }

        foreach ($this->historique as $res) {
            echo "- {$res->objet->nom}: {$res->debut->format('Y-m-d H:i')} pour {$res->duree}h\n";
        }
    }
}