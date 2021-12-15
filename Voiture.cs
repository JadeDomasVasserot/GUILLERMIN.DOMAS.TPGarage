using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    class Voiture : Vehicule
    {

        //Attributs
        private int chevauxFiscaux;
        private int nbPortes;
        private int nbSiege;
        private double tailleCoffre;
        //Constructeurs
        public Voiture(string name, decimal prix, string marque, Moteur moteur, int chevauxFiscaux, int nbPortes, int nbSiege, double tailleCoffre) :
            base(name, prix, marque, moteur)
        {
            this.ChevauxFiscaux = chevauxFiscaux;
            this.NbPortes = nbPortes;
            this.NbSiege = nbSiege;
            this.TailleCoffre = tailleCoffre;
        }
        // GetterS & Setters
        public int ChevauxFiscaux { get => chevauxFiscaux; set => chevauxFiscaux = value; }
        public int NbPortes { get => nbPortes; set => nbPortes = value; }
        public int NbSiege { get => nbSiege; set => nbSiege = value; }
        public double TailleCoffre { get => tailleCoffre; set => tailleCoffre = value; }
        // Méthodes:
        public override void afficherInfos()
        {
            base.afficherInfos();
            Console.WriteLine("Il y a : {0} sièges", NbSiege);
            Console.WriteLine("Il y a : {0} chevaux fiscaux", ChevauxFiscaux);
            Console.WriteLine("Il y a : {0} portes", NbPortes);
            Console.WriteLine("La taille du coffre fait : {0} m³ ", NbSiege);
            Console.WriteLine("###########################");
        }
        public override decimal calculTaxe()
        {
            return ChevauxFiscaux * 10;
        }
    }
}
