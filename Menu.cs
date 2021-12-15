using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    public class Menu
    {
        //Attribut
        private Garage garage;
        private Vehicule vehiculeSelected;
        //Getter & Setter
        public Garage GarageMenu { get => garage; set => garage = value; }
        public Vehicule VehiculeSelected { get => vehiculeSelected; set => vehiculeSelected = value; }

        //constructeur
        public Menu(Garage garage)
        {
            this.garage = garage;
            this.vehiculeSelected = null;
        }
        //methodes

        public void start()
        {

            int choix = -1;
            while (choix != 0)
            {
                afficherMenu();
                try
                {
                    choix = -1;
                    choix = GetChoixMenu();
                }

                catch (MenuException e)
                {
                    Console.WriteLine("Erreur !! " + e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erreur !! " + e.Message);
                }
                switch (choix)
                {
                    case 0:
                        break;
                    case 1:
                        garage.afficherVehicules();
                        break;
                    case 2:
                        try
                        {
                            garage.createVehicule();
                        }
                        catch (FormatException e)
                        {
                            Console.Write("Erreur !!!" + e.Message);
                        }
                        catch(OutofChoixException e)
                        {
                            Console.Write("Erreur !!!" + e.Message);
                        }
                        catch(ChoixVehiculeException e)
                        {
                            Console.Write("Erreur !! " + e.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            RemoveVehicule();
                        }
                        catch (ResearchNullException e)
                        {
                            Console.WriteLine("Erreur {0}", e.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            VehiculeSelected = selectVehByName();
                        }
                        catch (ResearchNullException e)
                        {
                            Console.WriteLine("Erreur {0}", e.Message);
                        } 
                        break;
                    case 5:
                        int choixSelect = choixSelected();
                        if (choixSelect == 1)
                        {
                            try
                            {
                                if (VehiculeSelected == null)
                                {
                                    throw new ResearchNullException();
                                }
                                Console.WriteLine(VehiculeSelected.afficherOptions());
                                Console.WriteLine("Pour un cout total d'options de : {0}", VehiculeSelected.calculPrixOptions());
                            }
                            catch (ResearchNullException e)
                            {
                                Console.WriteLine("Erreur : {0}", e.Message);
                            }
                        }
                        else if (choixSelect == 2)
                        {
                            try
                            {
                                Vehicule veh = selectVehByName();
                                Console.WriteLine(veh.afficherOptions());
                                Console.WriteLine("Pour un cout total d'options de : {0}", veh.calculPrixOptions());
                                if (veh == null)
                                {
                                    throw new ResearchNullException();
                                }
                                
                            }
                            catch (ResearchNullException e)
                            {
                                Console.WriteLine("Erreur : {0}", e.Message);
                            }
                        }
                        break;
                    case 6:
                        try
                        {
                            if (VehiculeSelected  ==  null) {
                                throw new ResearchNullException("Selectionner un vehicule d'abord !");
                            }
                            VehiculeSelected.addOptions(SelectOption());
                        }
                        catch (ResearchNullException e)
                        {
                            Console.WriteLine("Erreur : {0}", e.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            RemoveOptions();
                        }
                        catch (OptionNullExecption e)
                        {
                            Console.WriteLine("Erreur ! " + e.Message);
                        }
                        break;
                    case 8:
                        garage.afficherOptions();
                        break;
                    case 9:
                        garage.afficherMarques();
                        break;
                    case 10:
                        garage.afficherTypeMoteur();
                        break;
                    case 11:
                        break;
                    default:
                        break;
                }
            }

        }
        public int getChoix()
        {
            Console.WriteLine("Faites votre choix :");
            string choix = Console.ReadLine();
            try
            {
                return Convert.ToInt32(choix);
            }
            catch (FormatException)
            {
                throw new FormatException("Le nombre saisie n'est pas un nombre !");
            }

        }
        public int GetChoixMenu()
        {
            int choix = getChoix();
            if (choix < 0 || choix > 11)
            {
                throw new MenuException();
            }
            return choix;
        }
        public void afficherMenu()
        {
            if (vehiculeSelected!=null) { 
                Console.WriteLine("\n Véhicule selectionné : {0}\n", VehiculeSelected.Name);
            }

            Console.WriteLine("1.   Afficher les véhicules");
            Console.WriteLine("2.   Ajouter un véhicule");
            Console.WriteLine("3.   Supprimer un véhicule");
            Console.WriteLine("4.   Sélectionner un véhicule");
            Console.WriteLine("5.   Afficher les options d'un véhicule");
            Console.WriteLine("6.   Ajouter des options à un véhicule");
            Console.WriteLine("7.   Supprimer des options à un véhicule");
            Console.WriteLine("8.   Afficher les options");
            Console.WriteLine("9.   Afficher les marques");
            Console.WriteLine("10.   Afficher les types de moteurs");
            Console.WriteLine("11.   Sauvegarder le garage");
            Console.WriteLine("0.   Quitter l'application");
        }
        public Vehicule selectVehByName()
        {
            GarageMenu.afficherVehicules();
            Console.WriteLine("Entrer le nom du vehicule :");
            string nomChoix = Console.ReadLine();
            
            Vehicule choix = GarageMenu._Vehicules.Find(veh => veh.Name == nomChoix);
            try
            { 
                if(choix==null)
                {
                    throw new ResearchNullException();
                }
                choix.afficherInfos();
                return choix;
            }
            catch (ResearchNullException)
            {
                throw new ResearchNullException();
            }
        }
        public void RemoveVehicule()
        {
            int choixselect = choixSelected();
            switch (choixselect) {
                case 1:
                    GarageMenu._Vehicules.Remove(vehiculeSelected);
                    Console.WriteLine("Véhicule supprimer");
                    break;
                case 2:
                    GarageMenu._Vehicules.Remove(selectVehByName());
                    Console.WriteLine("Véhicule supprimer");
                    break;
            }
         }
        public void RemoveOptions()
        {
            vehiculeSelected.afficherOptions();
            int choixselect = choixSelected();
            Console.WriteLine("Quelle option souhaitez-vous supprimer ?");
            string nomChoix = Console.ReadLine();
            Options choixOption = GarageMenu.Options.Find(option => option.Nom == nomChoix);
            try
            {
                if (nomChoix == null)
                {
                    throw new OptionNullExecption();
                }
            }
            catch (OptionNullExecption)
            {
                throw new OptionNullExecption();
            }
            catch (ResearchNullException)
            {
                throw new ResearchNullException();
            }
            switch (choixselect)
            {
                   
                case 1:                  
                    VehiculeSelected.Options.Remove(choixOption);
                    Console.WriteLine("Option supprimée");
                    break;
                case 2:
                    Vehicule veh = selectVehByName();
                    veh.afficherOptions();
                    veh.Options.Remove(choixOption);
                    Console.WriteLine("Option supprimée");
                    break;
            }
        }
        public int choixSelected()
        {
            string txt = "";
            int choixselect = 0;
            Console.WriteLine("1. Voulez-vous effectue une action sur le véhicule choisi ?");
            Console.WriteLine("2. Ou rentrer le nom du véhicule !");
            txt = Console.ReadLine();
            try
            {
                choixselect = Convert.ToInt32(txt);
                if (choixselect < 1 || choixselect > 2)
                {
                    throw new ChoixSelectOrNotException();
                }

            }
            catch (ChoixSelectOrNotException)
            {
                throw new ChoixSelectOrNotException();
            }
            return choixselect;
        }
        public Options SelectOption()
        {
            Console.WriteLine("Voici la liste des options :");
            GarageMenu.afficherOptions();
            Console.WriteLine("Entrer le nom de l'option :");
            string nomChoix = Console.ReadLine();

            Options choix = this.GarageMenu.Options.Find(op => op.Nom == nomChoix);
            try
            {
                if (choix == null)
                {
                    throw new ResearchNullException();
                }
                return choix;
            }
            catch (ResearchNullException)
            {
                throw new ResearchNullException("Aucune option ne comporte trouvé");
            }
        }

    }
    
    
    [Serializable]
    public class MenuException : Exception
    {
        public MenuException(): base ("Le choix n'est pas compris entre 0 et 11.")
        {
        }

    }
    [Serializable]
    public class OutofChoixException : Exception
    {
        public OutofChoixException() : base("Le choix n'est pas compris entre 1 et 3.")
        {
        }

    }
    [Serializable]
    public class ResearchNullException : Exception
    {
        public ResearchNullException() : base("Aucun Véhicule trouvé")
        {
        }
        public ResearchNullException(string message) : base(message)
        {
        }
    }
    [Serializable]
    public class ChoixVehiculeException : Exception
    {
        public ChoixVehiculeException() : base("Vous n'avez pas choisi de véhicule")
        {
        }

    }
    [Serializable]
    public class ChoixSelectOrNotException : Exception
    {
        public ChoixSelectOrNotException() : base("Vous n'avez pas choisi une option dans le menu")
        {
        }

    }
    [Serializable]
    public class OptionNullExecption : Exception
    {
        public OptionNullExecption() : base("Option invalide")
        {
        }

    }
}
