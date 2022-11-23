// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/7/2021
// By: 5129153

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Abbey Mills", "457 Cat Road", "Chicago", 
                "IL", 60620); // Test Address 5
            Address a6 = new Address("Bacon Cheeseman", "7823 Burger Rd", "Los Angeles",
                "CA", 40392); // Test Address 6
            Address a7 = new Address("Porky Pig", "5639 Tree St", "Memphis", "Tennessee",
                34892); // Test Address 7
            Address a8 = new Address("Mario Luigi", "2940 Castle Place", "Destin", "Florida",
                79382); // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            Letter letter2 = new Letter(a5, a6, 7.0M); // letter test object 2
            GroundPackage gp2 = new GroundPackage(a7, a8, 5, 10, 6, 4); // ground test object 2
            NextDayAirPackage ndap2 = new NextDayAirPackage(a6, a4, 35, 10, 10, 15, 10.0M); // next day test object 2
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a1, a5, 10, 15, 20, 25, 
                TwoDayAirPackage.Delivery.Early); // two day test object 2

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(letter2);
            parcels.Add(gp2);
            parcels.Add(ndap2);
            parcels.Add(tdap2);

            WriteLine("Original List:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("====================");
            }
            Pause();

            // select all Parcels and order by destination zip (descending)
            var parcelByDestinationZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            // Display LINQ 
            WriteLine("Order by Destination Zip:");
            WriteLine("====================");
            foreach (Parcel p in parcelByDestinationZip)
                WriteLine(p);
            WriteLine("====================");
            Pause();

            // select all Parcels and order by cost (ascending)
            var parcelByCost =
                from p in parcels
                orderby p.CalcCost() ascending
                select p;

            // Display LINQ 
            WriteLine("Order by Cost:");
            WriteLine("===============");
            foreach (Parcel p in parcelByCost)
                WriteLine(p);
            WriteLine("===============");
            Pause();

            // select all Parcels and order by parcel type (ascending) and then cost (ascending)
            var parcelByTypeCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() ascending
                select p;

            // Display LINQ 
            WriteLine("Order by Type and Cost:");
            WriteLine("=======================");
            foreach (Parcel p in parcelByTypeCost)
                WriteLine(p);
            WriteLine("=======================");
            Pause();

            // select all AirPackage objects that are heavy and order by weight (descending)
            var airPackageHeavyByWeight =
                from p in parcels 
                let ap = p as AirPackage
                where (ap != null) && ap.IsHeavy()
                orderby ap.Weight descending
                select ap;

            // Display Air Package objects 
            WriteLine("Heavy AirPackage Objects, Ordered by Weight:");
            WriteLine("=============================================");
            foreach (AirPackage ap in airPackageHeavyByWeight)
                WriteLine(ap);
            WriteLine("=============================================");
            Pause();
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
