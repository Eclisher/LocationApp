<?php

class Objet {
    public string $nom;
    public int $prixParHeure;

    public function __construct(string $nom, int $prixParHeure) {
        $this->nom = $nom;
        $this->prixParHeure = $prixParHeure;
    }
}