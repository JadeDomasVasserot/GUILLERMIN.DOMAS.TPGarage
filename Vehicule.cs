using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{

    public abstract class Vehicule : IComparable <Vehicule> 
    {
        //attributs
        static public int IDinc = 0;
        private  int id;
        private string name;
        private decimal prixHT;
        private string marque;
        private Moteur moteur;
        private List<Options> _options;

        //constructeur
        public Vehicule( string name, decimal prixHT, string marque, Moteur moteur)
        {
            this.name = name;
            this.prixHT = prixHT;
            this.marque = marque;
            this.moteur = moteur;
            this._options = new List<Options>();
            IDinc++;
            this.id = IDinc;
            
        }

        //getter setter
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal PrixHT { get => prixHT; set => prixHT = value; }
        public string Marque { get => marque; set => marque = value; }
        public Moteur Moteur { get => moteur; set => moteur = value; }
        public List<Options> Options { get => _options; set => _options = value; }


        
       
        //methodes
        public virtual void afficherInfos()
        {
            Console.WriteLine("###########################");
            Console.WriteLine("                {0}:{1}",Id, Name);
            Console.WriteLine("Prix hors taxes et hors options : {0}", PrixHT);
            Console.WriteLine("Marque : {0}",  Marque);
            Console.WriteLine("Moteur : {0}", Moteur.afficherInfoMoteur());
            Console.WriteLine("Options : {0}",  afficherOptions());
            Console.WriteLine("Prix TTC et options : {0}", calculPrixTTC());

        }
      
        public string afficherOptions()
        {
            string stringOptions = "";
            foreach (Options element in Options) {
                stringOptions += element.Nom + " (" + element.Prix + " euros), ";
            }
            return stringOptions;
        }
        public void addOptions(Options option)
        {
            if (Options.Find(optionSearch => optionSearch == option) != null)
            {
                throw new ExistOptionException();
            }
            Options.Add(option);
        }
        public abstract decimal calculTaxe();
        public decimal calculPrixOptions()
        {
            decimal prixOption = 0;
            foreach (Options option in Options)
            {
               
                prixOption = prixOption + option.Prix;
            }
            return prixOption;
        }
        public decimal calculPrixTTC()
        {
            return prixHT + calculTaxe() + calculPrixOptions();
        }

        public int CompareTo(Vehicule other)
        {
       
            return prixHT.CompareTo(other.PrixHT);
        }
      

    }
}
