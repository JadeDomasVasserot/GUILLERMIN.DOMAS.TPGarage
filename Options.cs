using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    public class Options
    {
        //Attributs
        private string nom;
        private decimal prix;
        // Getters & Setters
        public string Nom { get => nom; set => nom = value; }
        public decimal Prix { get => prix; set => prix = value; }

        //Constructeur
        public Options(string nom, decimal prix)
        {
            this.nom = nom;
            this.prix = prix;
        }
        //Méthodes 
      
    }
}
