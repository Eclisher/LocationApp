<?php

class Reservation {
    public Objet $objet;
    public DateTime $debut;
    public int $duree;

    public function __construct(Objet $objet, DateTime $debut, int $duree) {
        $this->objet = $objet;
        $this->debut = $debut;
        $this->duree = $duree;
    }

    public function getFin(): DateTime {
        $fin = clone $this->debut;
        return $fin->modify("+{$this->duree} hour");
    }
}