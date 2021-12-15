using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    public class Garage
    {
 
        //attribut
        private List<Vehicule> _vehicules;
        private List<Options> _options;
        private List<Moteur> _moteurs;
        //constructeur
        public Garage()
        {
            _vehicules = new List<Vehicule>();
            _options = new List<Options>();
           _moteurs = new List<Moteur>();

        }
        //getter && setter
        public List<Vehicule> _Vehicules { get => _vehicules; set => _vehicules = value; }
        public List<Options> Options { get => _options; set => _options = value; }
        public List<Moteur> Moteurs { get => _moteurs; set => _moteurs = value; }

        public void addVehicule(Vehicule vehicule)
        {
            _vehicules.Add(vehicule);
        }
        //méthode
        
        public void afficherVehicules()
        {
            foreach (Vehicule vehicule in _vehicules)
            {
                vehicule.afficherInfos();
            }
        }
        // add to list 
        public void addOption(Options option)// créer instance
        {

            Options.Add(option);
        }
        public void addMoteur(Moteur moteur)// créer instance
        {

            Moteurs.Add(moteur);
        }
        // méthode afficher de menu
        public void afficherMarques()
        {
            foreach (Vehicule vehicule in _vehicules)
            {
                string marques = vehicule.Marque;
                Console.WriteLine("Marque : {0}" , marques);
            }
        }
        public void afficherTypeMoteur()
        {
            foreach (Moteur moteur in Moteurs)
            {
                string moteurs = moteur.Type + " "+ moteur.Puissance;
                Console.WriteLine("Moteurs : {0} kW", moteurs);
            }
        }
        public void afficherOptions()
        {
            foreach (Options option in Options)
            {
                string options = option.Nom + " " + option.Prix;
                Console.WriteLine("Options : {0} euros", options);
            }
        }
   
        public void createVehicule()
        {


            int choix = 0;
            string txt ="";
            //Vehicule newVehicule = new Vehicule();
            Console.WriteLine("Veuillez rentrer le nom de véhicule :");
            string name = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer le prix du véhicule :");
            txt = Console.ReadLine();
            try
            {
                decimal prix = Convert.ToDecimal(txt);
            }
            catch (FormatException)
            {
                throw new FormatException("Vous n'avez pas saisie un decimal !");
            }
            txt = "";
            Console.WriteLine("Veuillez rentrer la marque du véhicule :");
            string marque = Console.ReadLine();
            //MOteur
            afficherTypeVehicule();
            Console.WriteLine("Veuillez rentrer le type de véhicule que vous souhaitez créer :");
            txt = Console.ReadLine();
            
            try
            {
                
                choix = Convert.ToInt32(txt);
                if (choix < 1 || choix > 3)
                {
                    throw new OutofChoixException();
                }
            }
            catch (FormatException)
            {
                throw new FormatException("Vous n'avez pas saisie un int !");
            }
            catch (OutofChoixException e)
            {
                Console.WriteLine("Erreur !! "+ e.Message) ;
            }
            switch (choix)
            {
                case 1:
                    Console.WriteLine("Veuillez rentrer le nombre de chevaux fiscaux de la voiture :");
                    txt = Console.ReadLine();
                    try
                    {
                        int chevaux = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !");
                    }
                    Console.WriteLine("Veuillez rentrer le nombre de portes de la voiture :");
                    txt = Console.ReadLine();
                    try
                    {
                        int portes = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !");
                    }
                    Console.WriteLine("Veuillez rentrer la taille du coffre de la voiture :");
                    txt = Console.ReadLine();
                    try
                    {
                        double coffre = Convert.ToDouble(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un double !");
                    }
                    //Voiture newVoiture = new Voiture(name, prix,marque,m)
                    break;
                case 2:
                   
                    break;
                case 3:
                   
                    break;
            }
            

        }
        public void afficherTypeVehicule()
        {
            Console.WriteLine("1.   Voitures");
            Console.WriteLine("2.   Motos");
            Console.WriteLine("3.   Camions");
        }

    }
}

