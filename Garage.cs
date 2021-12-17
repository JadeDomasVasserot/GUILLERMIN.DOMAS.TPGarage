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
            _Vehicules.Sort();
            foreach (Vehicule vehicule in _vehicules)
            {
                vehicule.afficherInfos();
                
            }
        }
        // add to list 
        public void addOptionList(Options option)// créer instance
        {

            Options.Add(option);
        }
        public void createOption(Vehicule veh)
        {
            int choix = 0;
            string txt = "";
            decimal prix = 0;
            Console.WriteLine("Veuillez rentrer le nom de l'option :");
            string name = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer le prix de l'option :");
            txt = Console.ReadLine();
            try
            {
               prix = Convert.ToDecimal(txt);
            }
            catch (FormatException)
            {
                throw new FormatException("Vous n'avez pas saisie un decimal !\n");
            }
            Options optionNew = new Options(name,prix);
            veh.addOptions(optionNew);
        }
        public void addMoteur(Moteur moteur)// créer instance
        {
            Moteurs.Add(moteur);

        }
        public Moteur createMoteur()
        {
            int choix = 0;
            int puissance = 0;
            double coffre = 0;
            string txt = "";
            Type type = Type.Electrique;
            Console.WriteLine("Veuillez rentrer la puissance du moteur :");
            txt = Console.ReadLine();
            try
            {
                puissance = Convert.ToInt32(txt);
            }
            catch (FormatException)
            {
                throw new FormatException("Vous n'avez pas saisie un int !\n");
            }
            Console.WriteLine("1. Essence : {0}", Type.Essence);
            Console.WriteLine("2. Diesel : {0}", Type.Diesel);
            Console.WriteLine("3. Electrique : {0}", Type.Electrique);
            Console.WriteLine("4. Hybride  : {0}", Type.Hybride);
            txt = Console.ReadLine();
            try
            {

                choix = Convert.ToInt32(txt);
                if (choix < 0 || choix > 4)
                {
                    throw new OutofChoixException("Le choix n'est pas compris entre 1 et 4 \n");
                }
            }
            catch (FormatException)
            {
                throw new FormatException("Vous n'avez pas saisie un int !\n");
            }
            switch (choix)
            {
                case 1:
                    type = Type.Essence;
                    break;
                case 2:
                    type = Type.Diesel;
                    break;
                case 3:
                    type = Type.Electrique;
                    break;
                case 4:
                    type = Type.Hybride;
                    break;

            }
            Moteur MoteurNew = new Moteur(puissance, type);
            Moteurs.Add(MoteurNew);
            return MoteurNew;
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
            string marque = "";
            decimal prix = 0;
            int chevaux = 0;
            int portes = 0;
            double coffre = 0;
            int siege = 0;
            int cylindree = 0;
            int essieux = 0;
            int poidCharge = 0;
            double volumeCharge;

            int choix = 0;
            string txt ="";
            //Vehicule newVehicule = new Vehicule();
            Console.WriteLine("Veuillez rentrer le nom de véhicule :");
            string name = Console.ReadLine();
            Console.WriteLine("Veuillez rentrer le prix du véhicule :");
            txt = Console.ReadLine();
            try
            {
                 prix = Convert.ToDecimal(txt);
            }
            catch (FormatException)
            {
                throw new FormatException("Vous n'avez pas saisie un decimal !\n");
            }
            txt = "";
            Console.WriteLine("Veuillez rentrer la marque du véhicule :");
             marque = Console.ReadLine();
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
                throw new FormatException("Vous n'avez pas saisie un int !\n");
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
                         chevaux = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !\n");
                    }
                    Console.WriteLine("Veuillez rentrer le nombre de portes de la voiture :");
                    txt = Console.ReadLine();
                    try
                    {
                         portes = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !\n");
                    }
                    Console.WriteLine("Veuillez rentrer le nombre de siège de la voiture :");
                    txt = Console.ReadLine();
                    try
                    {
                        siege = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !\n");
                    }
                    Console.WriteLine("Veuillez rentrer la taille du coffre de la voiture :");
                    txt = Console.ReadLine();
                    try
                    {
                         coffre = Convert.ToDouble(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un double !\n");
                    }
                    Voiture newVoiture = new Voiture(name, prix, marque, createMoteur(), chevaux, portes, siege,coffre);
                    addVehicule(newVoiture);
                    newVoiture.afficherInfos();
                    break;
                case 2:
                    Console.WriteLine("Veuillez rentrer la cylindrée de la moto :");
                    txt = Console.ReadLine();
                    try
                    {
                        cylindree = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !\n");
                    }
                    Moto newMoto = new Moto(name, prix, marque, createMoteur(), cylindree);
                    addVehicule(newMoto);
                    newMoto.afficherInfos();
                    break;
                case 3:
                    Console.WriteLine("Veuillez rentrer le nombre d'essieux du camion :");
                    txt = Console.ReadLine();
                    try
                    {
                        essieux = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !\n");
                    }
                    Console.WriteLine("Veuillez rentrer le poids de chargement du camion :");
                    txt = Console.ReadLine();
                    try
                    {
                        poidCharge = Convert.ToInt32(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un Int !\n");
                    }
                    Console.WriteLine("Veuillez rentrer le volume de chargement du camion :");
                    txt = Console.ReadLine();
                    try
                    {
                        volumeCharge = Convert.ToDouble(txt);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Vous n'avez pas saisie un double !\n");
                    }
                    Camion newCamion = new Camion(name, prix, marque, createMoteur(),essieux,poidCharge,volumeCharge);
                    addVehicule(newCamion);
                    newCamion.afficherInfos();
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

