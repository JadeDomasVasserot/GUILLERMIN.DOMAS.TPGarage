using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    class Camion : Vehicule
    {
        //Attributs
        private int nbEssieux;
        private int poidsChargement;
        private double volumeChargement;



        //Constructeurs
        public Camion(string name, decimal prix, string marque, Moteur moteur, int nbEssieux, int poidsChargement, double volumeChargement) :
            base ( name,  prix,  marque,  moteur)
        {
            this.NbEssieux = nbEssieux;
            this.PoidsChargement = poidsChargement;
            this.VolumeChargement = volumeChargement;
        }


        // GetterS & Setters
        public int NbEssieux { get => nbEssieux; set => nbEssieux = value; }
        public int PoidsChargement { get => poidsChargement; set => poidsChargement = value; }
        public double VolumeChargement { get => volumeChargement; set => volumeChargement = value; }


        // Méthodes:
        public override decimal calculTaxe()
        {
            return NbEssieux * 50;
        }
        public override void afficherInfos()
        {
            base.afficherInfos();
            Console.WriteLine("Il y a : {0}  essieux", NbEssieux);
            Console.WriteLine("Il y a : {0}  kilos", PoidsChargement);
            Console.WriteLine("Il y a : {0}  m³", VolumeChargement);
            Console.WriteLine("###########################");
        }
    }
}
