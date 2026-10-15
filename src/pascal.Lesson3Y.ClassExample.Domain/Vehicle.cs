using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Runtime.Serialization;
using System.Text;

namespace pascal.Lesson3E.ClassExample.Domain
{
    /// <summary>
    /// Ogni veicolo è caratterizzato da:
    /// Una targa(LicensePlate)
    /// Il chilometraggio attuale(OdometerKm)
    /// La tariffa giornaliera di noleggio(DailyRate)
    /// Il livello percentuale di carburante nel serbatoio(FuelLevelPercentage)
    /// Il Modello deve:
    /// Impedire la creazione di veicoli con valori incoerenti(es.targa non valida, chilometri o tariffe negative).
    /// Permetta di registrare i viaggi effettuati, incrementando il chilometraggio e riducendo il carburante residuo.
    /// Consentire di effettuare il rifornimento fino a un massimo del 100 % della capienza del serbatoio.
    /// </summary>
    public class Vehicle
    {
        private string _licensePlate;
        private int _odometerKm;
        private double _dailyRate;
        private double _fuelLevelPercentage;

        public static double MaxFuelLevelPercentage { get; } = 100.0;
        public string LicensePlate 
        { 
            get
            {
                return _licensePlate;
            }
            private set
            {
                // controllo lunghezza
                if (value.Length != 7)
                    throw new ArgumentException($"value not allowed {nameof(LicensePlate)}: {value}");
                // controllo lettere
                if (!char.IsLetter(value[0]) || !char.IsLetter(value[1]) || !char.IsLetter(value[5]) || !char.IsLetter(value[6]))
                    throw new ArgumentException($"value not allowed {nameof(LicensePlate)}: {value}");
                // controllo numeri
                if (!char.IsDigit(value[2]) || !char.IsDigit(value[3]) || !char.IsDigit(value[4]))
                    throw new ArgumentException($"value not allowed {nameof(LicensePlate)}: {value}");
            }
        }
        public int OdometerKm
        {
            get
            { return _odometerKm; }
            private set
            { 
                if (value < 0) 
                    throw new ArgumentException($"value not allowed {nameof(OdometerKm)}: {value} ");

                _odometerKm = value;
            }
        }
        public double DailyRate 
        { 
            get
            { return _dailyRate; }
            private set
            {
                if(value < 0)
                    throw new ArgumentException($"value not allowed {nameof(DailyRate)}: {value} ");
                _dailyRate = value;
            }
        }

        public double FuelLevelPercentage 
        {  
            get
            { return _fuelLevelPercentage; }
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException($"value not allowed {nameof(FuelLevelPercentage)}: {value} ");
                
                _fuelLevelPercentage = value;
            }
        }

        
        /// <summary>
        /// metodo costruttore che inizializza la targa del veicolo
        /// </summary>
        /// <param name="licensePlate"></param>
        public Vehicle(string licensePlate)
        {            
            LicensePlate = licensePlate; //chiama al set
        }

        /// <summary>
        /// metodo costruttore che inizializza la targa del veicolo, il contachilometri, il prezzo giornaliero e il livello di carburante
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="odometerKm"></param>
        /// <param name="dailyRate"></param>
        /// <param name="fuelLevelPercentage"></param>
        public Vehicle(string licensePlate, int odometerKm, double dailyRate, double fuelLevelPercentage) 
        {
            LicensePlate = licensePlate;
            OdometerKm = odometerKm; //chiamata al set
            DailyRate = dailyRate;
            FuelLevelPercentage = fuelLevelPercentage;
        }

        public void RegisterData(int consumedKm, double consumedFuel)
        {
            //controlli sui parametri (argument)
            if (consumedKm <= 0)
                throw new ArgumentException($"value not allowed {nameof(consumedKm)}: {consumedKm} ");
            if (consumedFuel < 0)
                throw new ArgumentException($"value not allowed {nameof(consumedFuel)}: {consumedFuel} ");

            //aggiorno lo stato dell'oggetto
            OdometerKm += consumedKm; //chiamata al set
            FuelLevelPercentage -= consumedFuel; //chiamate set
        }
       

    }
}