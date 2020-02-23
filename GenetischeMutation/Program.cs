using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace GenetischeMutation
{
   
    class Program
    {
        static void Main(string[] args)
        {
            // Start Genome definieren
            bool[] genom1 = { false, false, false, true, false, false, true, true, true, false };
            bool[] genom2 = { false, true, false, false, true, false, true, true, false, true };
            bool[] genom3 = { true, true, false, true, true, false, true, true, false, true };
            bool[] genom4 = { true, false, false, true, true, false, true, false, true, true };

            List<Rucksack> rucksaecke = new List<Rucksack>(new[]
                                                           {
                                                               new Rucksack(genom1),
                                                               new Rucksack(genom2),
                                                               new Rucksack(genom3),
                                                               new Rucksack(genom4)
                                                           });

            RucksackGenManipulator genManipulator = new RucksackGenManipulator(rucksaecke);
            // RucksackGenManipulator besitzt 4 verschiedene Algorithmen. Algorithmus 4 ergibt bestes Resultat.
            List<Rucksack> newRucksack = genManipulator.MutateRucksackByAlgorithmn4(100); 

            WriteRucksackInhalt(newRucksack);
            Console.ReadKey();
        }

        /// <summary>
        /// Console Output der Rucksäcke
        /// </summary>
        static void WriteRucksackInhalt(List<Rucksack> rucksaecke)
        {
            for(int i = 0; i < rucksaecke.Count(); i++)
            {
                int rucksacknr = i + 1;
                Console.WriteLine($"Rucksack {rucksacknr} Masse: {rucksaecke[i].Gesamtmasse}");
                Console.WriteLine($"Rucksack {rucksacknr} Wert: {rucksaecke[i].Gesamtwert}");
                Console.WriteLine($"Rucksack {rucksacknr} Fitness: {rucksaecke[i].Fitness}");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
