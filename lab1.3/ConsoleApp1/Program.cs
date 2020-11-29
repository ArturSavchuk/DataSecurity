using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    class Program
    {
        private static string DecodeSubstitution(string input, string keyAlphabet)
        {
           string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
           string output = string.Empty;

            if (Alphabet.Length != keyAlphabet.Length)
                return output;

            for (int i = 0; i < input.Length; ++i)
            {
                int oldCharIndex = Alphabet.IndexOf(char.ToUpper(input[i]));
                
                if (oldCharIndex >= 0)
                    output += char.IsUpper(input[i]) ? char.ToUpper(keyAlphabet[oldCharIndex]) : keyAlphabet[oldCharIndex];
                else
                    output += input[i];
            }
            return output;
        }

        public static void CountIndexForEnglishText(string text)
        {
            //string text = File.ReadAllText(@".\..\..\..\text_for_trigrams analysys.txt");
            text = Regex.Replace(text, "[-.?!')(,: ]", "").ToUpper(); ;
            double fit_index = 0;
            for (int i = 0; i < text.Length - 2; i++)
            {
                fit_index += GeneticAlgorithm.trigrams[text.Substring(i, 3)];
            }
            Console.WriteLine((fit_index / text.Length - 2));
        }

        //public static void CountTerminateCond()
        //{
        //    string text = File.ReadAllText(@".\..\..\..\text_for_trigrams analysys.txt");
        //    text = Regex.Replace(text, "[-.?!')(,: ]", "").ToUpper(); ;
        //    double fit_index = 0;
        //    for (int i = 0; i < text.Length - 2; i++)
        //    {
        //        fit_index += GeneticAlgorithm.trigrams[text.Substring(i, 3)];
        //    }
        //    Console.WriteLine((fit_index / text.Length - 2));
        //}

        static class GeneticAlgorithm
        {
            public static string ciphertext = File.ReadAllText(@".\..\..\..\text.txt");
            private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public static int keyLenght = 26;
            public static Dictionary<string, double> trigrams;
            public static double sum = 0;

            //calculated using triagram analysis for article about Life on Mars
            public static double expected_index = -3.556834764489;


            public static List<string> GeneratePopulation(int pop_size)
            {
                List<string> population = new List<string>();
                for (int i = 0; i < pop_size; i++)
                {
                    population.Add(GenerateRandomKey());
                }
                return population;
            }
            private static string GenerateRandomKey()
            {

                string key = String.Empty;
                char ch;


                Random random = new Random(Guid.NewGuid().GetHashCode());
                for (int i = 0; i < Alphabet.Length; i++)
                {

                    do
                    {
                        ch = Alphabet[random.Next(Alphabet.Length)];
                    }
                    while (key.Contains(ch));
                    key += ch;
                }
                return key;
            }
            public static void ParseTrigrams()
            {
                Dictionary<string, double>  t_trigrams = new Dictionary<string, double>();
                string[] tr_grams = File.ReadAllLines(@"./../../../english_trigrams.txt");
                double sum_of_values = 0;
                foreach (string line in tr_grams)
                {
                    double val = Convert.ToDouble(line.Split(' ')[1]);
                    t_trigrams.Add(line.Split(' ')[0], val);
                    sum_of_values += val;
                }
                SetTrigramIndices(t_trigrams, sum_of_values);
            }

            public static void SetTrigramIndices(Dictionary<string, double> t_trigrams, double sum_of_values)
            {
                trigrams = new Dictionary<string, double>();
                foreach (var k_val in t_trigrams)
                {
                    trigrams.Add(k_val.Key, Math.Log10(k_val.Value / sum_of_values));
                }

            }

            //fitness function

            public static double GetFitness(string individ)
            {
                double fitness;
                double fit_index = 0;
                string deciphered_str = DecodeSubstitution(ciphertext, individ);
                for (int i = 0; i < deciphered_str.Length - 2; i++)
                {
                    try
                    {
                        string t = deciphered_str.Substring(i, 3);
                        fit_index += trigrams[t];
                    }
                    catch (Exception){}
                }
                
                fit_index /= (deciphered_str.Length - 2);
               
                fitness = Math.Abs(fit_index - expected_index);
                
                return fitness;
            }
            public static List<double> CountPopulationFitness(List<string> population)
            {
                List<double> indices = new List<double>();
                foreach (string str in population)
                {
                    indices.Add(GetFitness(str)); 
                }
                return indices;
            }
            public static int GetIndexOfMin(List<double> fitness_indices)
            {
                double min = Double.MaxValue;
                int min_index = 0;
                for (int  i = 0; i < fitness_indices.Count; i++)
                {
                    if(min > fitness_indices[i])
                    {
                        min = fitness_indices[i];
                        min_index = i;
                    }
                }
                return min_index;
            }

            //selection function
            public static List<string> GetHighestFitnessIndivids(int n, List<string> population)
            {
                List<double> indices = CountPopulationFitness(population);
                List<string> HighestFitnessIndivids = new List<string>();
                
                for (int i = 0; i < n; i++)
                {
                    int min_index = GetIndexOfMin(indices);
                    HighestFitnessIndivids.Add(population[min_index]);
                    indices.RemoveAt(min_index);
                }
                return HighestFitnessIndivids;
            }

            //crossover 
            public static List<string> PositionBasedCrossover(List<string> HighestFitnessIndivids)
            {
                List<string> new_individs = new List<string>();
                for (int i = 0; i < HighestFitnessIndivids.Count * 2; i++)
                {
                    Random random = new Random(Guid.NewGuid().GetHashCode());

                    int i1 = random.Next(HighestFitnessIndivids.Count);
                    int i2 = random.Next(HighestFitnessIndivids.Count);

                    while (i1 == i2) i2 = random.Next(HighestFitnessIndivids.Count);
                    string child = Crossover(HighestFitnessIndivids[i1], HighestFitnessIndivids[i2]);
                    new_individs.Add(child);
                }
                HighestFitnessIndivids.AddRange(new_individs);
                return HighestFitnessIndivids;
            }
            private static string Swap(int i1, int i2, string individ)
            {
                StringBuilder str = new StringBuilder(individ);
                char t = str[i1];
                str[i1] = str[i2];
                str[i2] = t;
                return str.ToString();
            }
            private static string Crossover(string item1, string item2)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                string new_item = String.Empty;
                int slice_point = random.Next(item1.Length - 2);
                for(int i = 0; i < slice_point; i++)
                {
                    new_item += item1[i];
                }
                for(int i = slice_point; i < item1.Length; i++)
                {
                    if (new_item.Contains(item2[i]))
                    {
                        continue;
                    }
                    new_item += item2[i];
                }
                for(int i = slice_point; i < item1.Length; i++)
                {
                    if (new_item.Contains(item1[i]))
                    {
                        continue;
                    }
                    new_item += item1[i];
                }
                
                return new_item;

            }

            //mutation
            public static void MutatePopulation(List<string> population)
            {
                for (int i = 0; i < population.Count; i++)
                {
                    Random random = new Random(Guid.NewGuid().GetHashCode());

                    int rnd = random.Next(100);
                    if (rnd % 2 == 0)
                    {
                        population[i] = MakeMutation(population[i]);
                    }
                }
            }

            private static string MakeMutation(string item)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int i1 = random.Next(item.Length);
                int i2 = random.Next(item.Length);
                item = Swap(i1, i2, item);
                return item;
            }

                   
        }


        static void Main()
        {
            string text = File.ReadAllText(@".\..\..\..\text.txt");
            GeneticAlgorithm.ParseTrigrams();
            List<string> pop =  GeneticAlgorithm.GeneratePopulation(500);
            List<double> ind = GeneticAlgorithm.CountPopulationFitness(pop);
            string l = GeneticAlgorithm.GetHighestFitnessIndivids(1, pop)[0];
           
            while(true)
            {
                List<string> best = GeneticAlgorithm.GetHighestFitnessIndivids(250, pop);
                List<string> children = GeneticAlgorithm.PositionBasedCrossover(best);
                GeneticAlgorithm.MutatePopulation(children);
                pop = children;
                l = GeneticAlgorithm.GetHighestFitnessIndivids(1, pop)[0];
                Console.WriteLine(GeneticAlgorithm.GetFitness(l));
                Console.WriteLine(DecodeSubstitution(text, l));
            }            
        }
    }
}


