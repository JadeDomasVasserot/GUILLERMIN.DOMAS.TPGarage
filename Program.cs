using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILLERMIN.DOMAS.TPGarage
{
    class Program
    {
       
        static void Main(string[] args)
        {
           
           
            //Création Moteur
            Moteur moteurElectrique = new Moteur(100, Type.Electrique);
            Moteur moteurEssence = new Moteur(150, Type.Essence);
            Moteur moteurDiesel = new Moteur(90, Type.Diesel);
            Moteur moteurHybride = new Moteur(160, Type.Hybride);
            //Création Options
            Options ecran = new Options("Ecran Navigation", 300m);
            Options climatisation = new Options("climatisation", 100m);
            Options gps = new Options("gps", 80m);
            Options vitresAuto = new Options("Vitres Automatisées", 45m);
            Options radio = new Options("Radio", 20m);
            Options phareXenon = new Options("phares Xenon", 110);
            Options pluieDetect = new Options("Detecteur de pluie", 45);
            Options compteurCarbon = new Options("Compteur Carbone", 320);
            Options echappement = new Options("Pot d'echappement Akrapovic", 500);
           
            //création Voiture
            Voiture RenaultCapture = new Voiture("Capture", 19000, "Renault", moteurElectrique, 80, 5, 5, 30.1);
            Voiture Peugeot208 = new Voiture( "208", 19000, "Peugeot", moteurHybride, 50, 3, 4, 15.1);
            //Création Moto
            Moto GSXR = new Moto( "GSXR 1000", 10000, "Suzuki", moteurEssence, 6);
            Moto MT07 = new Moto( "MT-07", 7000, "Yamaha", moteurEssence, 5);
            //Création Camion
            Camion RenaultTZgm = new Camion("TZgm", 50000, "Renault", moteurEssence,  3, 7000, 20.3);
            Camion DailyIveco = new Camion( "Daily", 30000, "Iveco", moteurDiesel, 2 , 5600, 19.1);
            //Ajouter option

            RenaultCapture.addOptions(climatisation);
            Peugeot208.addOptions(gps);
            Peugeot208.addOptions(phareXenon);
            GSXR.addOptions(gps);
            GSXR.addOptions(ecran);
            MT07.addOptions(compteurCarbon);
            MT07.addOptions(echappement);
            RenaultTZgm.addOptions(compteurCarbon);
            DailyIveco.addOptions(pluieDetect);
            DailyIveco.addOptions(radio);

            Console.WriteLine("\n=========================Avant=Tri=========================\n");
            Garage garage1 = new Garage();
            garage1.addVehicule(DailyIveco);
            garage1.addVehicule(Peugeot208);
            garage1.addVehicule(RenaultCapture);
            garage1.addVehicule(RenaultTZgm);
            garage1.addVehicule(MT07);
            garage1.addVehicule(GSXR);
            garage1.afficherVehicules();
            Console.WriteLine("\n=========================Après=Tri========================\n");
            garage1._Vehicules.Sort();
            garage1.afficherVehicules();
            Console.WriteLine("\n=========================MENU========================\n");
            garage1.addOption(ecran);
            garage1.addOption(climatisation);
            garage1.addOption(gps);
            garage1.addOption(vitresAuto);
            garage1.addOption(radio);
            garage1.addOption(phareXenon);
            garage1.addOption(pluieDetect);
            garage1.addOption(compteurCarbon);
            garage1.addOption(echappement);

            //Add Moteur
            garage1.addMoteur(moteurDiesel);
            garage1.addMoteur(moteurHybride);
            garage1.addMoteur(moteurEssence);
            garage1.addMoteur(moteurElectrique);


            Menu Menu= new Menu (garage1);
            Menu.start();
            Console.ReadKey();
        }
    }
}
