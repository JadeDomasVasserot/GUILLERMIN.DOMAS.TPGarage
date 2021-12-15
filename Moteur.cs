using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    public class Moteur 
    {
        //Attributs
        private int puissance;
        private Type type;

        //constructeur
        public Moteur(int puissance, Type type)
        {
            this.Puissance = puissance;
            this.Type = type;
        }
        // Getters & Setters 
        public int Puissance { get => puissance; set => puissance = value; }
        public Type Type { get => type; set => type = value; }
        //Méthodes
        public string afficherInfoMoteur()
        {
          
            return Type+" de " + Puissance + " kW";


        }
    }
    public enum Type
    {
       Diesel,
       Essence,
       Hybride,
       Electrique
    }
    
}
