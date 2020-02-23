using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenetischeMutation
{
    public class RucksackGenManipulator
    {
        private List<Rucksack> _rucksacke;

        public RucksackGenManipulator(List<Rucksack> rucksacke)
        {
            _rucksacke = rucksacke;
        }

        /// <summary>
        /// Abschnitt 1 vom Besten und Abschnitt 2 vom Zweitbesten
        /// </summary>
        public List<Rucksack> MutateRucksackByAlgorithmn1(int anzahlDurchlauf)
        {
            for (int i = 0; i < anzahlDurchlauf; i++)
            {
                _rucksacke = _rucksacke.OrderByDescending(r => r.Fitness).ToList();
                Rucksack rucksackLowestFitness = _rucksacke.Last();
                _rucksacke.Remove(rucksackLowestFitness);
                Rucksack BestFitnessRucksack = _rucksacke[0];
                Rucksack SecondBestFitnessRucksack = _rucksacke[1];

                bool[] g1 = BestFitnessRucksack.GetGenomErsterAbschnitt();
                bool[] g2 = SecondBestFitnessRucksack.GetGenomZweiterAbschnitt();

                bool[] mutierterGenom = { g1[0], g1[1], g1[2], g1[3], g1[4], g2[0], g2[1], g2[2], g2[3], g2[4] };
                Rucksack neuerMutantenRucksack = new Rucksack(mutierterGenom);
                _rucksacke.Add(neuerMutantenRucksack);
            }

            return _rucksacke;
        }

        /// <summary>
        /// Abschnitt 1 vom Zweitbesten und Abschnitt 2 vom Besten
        /// </summary>
        public List<Rucksack> MutateRucksackByAlgorithmn2(int anzahlDurchlauf)
        {
            for (int i = 0; i < anzahlDurchlauf; i++)
            {
                _rucksacke = _rucksacke.OrderByDescending(r => r.Fitness).ToList();
                Rucksack rucksackLowestFitness = _rucksacke.Last();
                _rucksacke.Remove(rucksackLowestFitness);
                Rucksack BestFitnessRucksack = _rucksacke[0];
                Rucksack SecondBestFitnessRucksack = _rucksacke[1];

                bool[] g2 = BestFitnessRucksack.GetGenomErsterAbschnitt();
                bool[] g1 = SecondBestFitnessRucksack.GetGenomZweiterAbschnitt();

                bool[] mutierterGenom = { g1[0], g1[1], g1[2], g1[3], g1[4], g2[0], g2[1], g2[2], g2[3], g2[4] };
                Rucksack neuerMutantenRucksack = new Rucksack(mutierterGenom);
                _rucksacke.Add(neuerMutantenRucksack);
            }

            return _rucksacke;
        }

        /// <summary>
        /// Mit zufälligen Rucksack und zufälligen Abschnitt tauschen.
        /// </summary>
        public List<Rucksack> MutateRucksackByAlgorithmn3(int anzahlDurchlauf)
        {
            for (int i = 0; i < anzahlDurchlauf; i++)
            {
                _rucksacke = _rucksacke.OrderByDescending(r => r.Fitness).ToList();
                Rucksack rucksackLowestFitness = _rucksacke.Last();
                _rucksacke.Remove(rucksackLowestFitness);

                Random rng = new Random();
                int randomListIndexWithoutFirst = rng.Next(1, _rucksacke.Count);

                Rucksack bestFitnessRucksack = _rucksacke[0];
                Rucksack randomRucksack = _rucksacke[randomListIndexWithoutFirst];

                int randomAbschnitt = rng.Next(1, 3); // maxValue ist exklusive

                bool[] g1 = new bool[5];
                bool[] g2 = new bool[5];
                if (randomAbschnitt == 1)
                {
                    g1 = bestFitnessRucksack.GetGenomErsterAbschnitt();
                    g2 = randomRucksack.GetGenomZweiterAbschnitt();

                }
                else
                {
                    g1 = randomRucksack.GetGenomErsterAbschnitt();
                    g2 = bestFitnessRucksack.GetGenomZweiterAbschnitt();
                }

                bool[] mutierterGenom = { g1[0], g1[1], g1[2], g1[3], g1[4], g2[0], g2[1], g2[2], g2[3], g2[4] };
                Rucksack neuerMutantenRucksack = new Rucksack(mutierterGenom);
                _rucksacke.Add(neuerMutantenRucksack);
            }

            return _rucksacke;
        }

        /// <summary>
        /// zweier zufällige Punkte des besten Gen werden gekehrt.
        /// </summary>
        public List<Rucksack> MutateRucksackByAlgorithmn4(int anzahlDurchlauf)
        {
            for (int i = 0; i < anzahlDurchlauf; i++)
            {
                _rucksacke = _rucksacke.OrderByDescending(r => r.Fitness).ToList();
                Rucksack rucksackLowestFitness = _rucksacke.Last();
                _rucksacke.Remove(rucksackLowestFitness);

                Rucksack bestFitnessRucksack = _rucksacke[0];

                bool[] g1 = bestFitnessRucksack.GetGenomErsterAbschnitt();
                bool[] g2 = bestFitnessRucksack.GetGenomZweiterAbschnitt();
                bool[] mutierterGenom = { g1[0], g1[1], g1[2], g1[3], g1[4], g2[0], g2[1], g2[2], g2[3], g2[4] };
                Random rng = new Random();
                int randomGenomIndex = rng.Next(mutierterGenom.Length);
                int randomGenomIndex2;
                do
                {
                    randomGenomIndex2 = rng.Next(mutierterGenom.Length);
                } while(randomGenomIndex2 == randomGenomIndex);

                mutierterGenom[randomGenomIndex] = !mutierterGenom[randomGenomIndex];
                mutierterGenom[randomGenomIndex2] = !mutierterGenom[randomGenomIndex2];


                Rucksack neuerMutantenRucksack = new Rucksack(mutierterGenom);
                _rucksacke.Add(neuerMutantenRucksack);
            }

            return _rucksacke;
        }
    }
}
