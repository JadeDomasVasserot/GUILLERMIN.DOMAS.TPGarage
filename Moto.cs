using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    class Moto : Vehicule
    {
        //attributs
        private int cylindre;

        //constructeur
        public Moto(string name, decimal prixHT, string marque, Moteur moteur,int cylindre) : base(name, prixHT, marque, moteur)
        {
            this.cylindre = cylindre;
        }

        public int Cylindre { get => cylindre; set => cylindre = value; }

        //methodes
        public override decimal calculTaxe()
        {
            return (decimal)Math.Truncate(Cylindre  *  0.3);
        }
        public override void afficherInfos()
        {
            base.afficherInfos();
            Console.WriteLine("Il y a : {0} cylindrée", Cylindre);
            Console.WriteLine("###########################");
        }
    }
}
