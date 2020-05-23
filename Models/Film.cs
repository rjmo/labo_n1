using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace labo_n1.Models
{
    public class Film
    {
        public int Id { get; set; }
        [DisplayName("Titre du film")]
        public string Titre { get; set; }
        [DisplayName("Durée du film")]
        public int Duree { get; set; }
        [DisplayName("Réalisateur")]
        public string Realisateur { get; set; }
        [DisplayName("Catégorie")]
        //public string Categorie { get; set; }
                  
        public Catego Categorie { get; set; }

    }
    public enum Catego
    {
        
        Action, Aventure, Comedie, Drame, Humour, Horreur, Suspense, ScienceFiction
    }

}