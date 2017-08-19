using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Statcal
{
    class StatisticCalculate //define new object type
    {
        public List<double> Memory { get; } = new List<double> { };
        public void sort() {
            Memory.Sort();
        }
        public void generate(int Number_Length, int Number_Size, double seed, bool negative = false,bool decimal_enable = false,int verbose_level = 1/*,bool random = false*/) {
            for (int Start = 1; Start <= Number_Size; Start++) {
                Random rnd = new Random(DateTime.Now.Millisecond);
                int Negative_calculate = 0;
                if(negative == true)
                {
                    Negative_calculate = -1;
                }
                double number = rnd.Next((Negative_calculate*(Number_Length+1)),(10^Number_Length)+1);
                if (decimal_enable == true) {
                    number =  Convert.ToDouble((number+"." + rnd.Next().ToString()));

                }
                if (seed != 0)
                {
                    number = Math.Pow(Math.E, seed) * (/*Math.Log*/((Math.Pow(number - seed, seed)))) / Math.Pow(Math.PI , seed);
                }
                    Thread.Sleep(verbose_level);
                Enter(number);
                Console.WriteLine("["+Start+"/"+Number_Size+"]"+number+" Has been generated");
            }

        }
        public double FindMode()
        {
            return (Memory.GroupBy(n => n).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault());
        }
        public void Enter(double Number_To_Add)
        {
            Memory.Add(Number_To_Add);

        }
        public double FindMean() {
            return(Memory.Average());
        }
        public double FindMedian()
        {
            List<double> MemorySort = Memory;
            MemorySort.Sort();
            //Memory.Count();
            double MedIndex = (Memory.Count()+1)/2;
            double ZEROPOINTFIVE = 0.5;
            double result = -1;
            if (MedIndex % 1 != 0) {// Int32 MedIndexLower = MedIndex - ZEROPOINTFIVE;
              result =  (MemorySort[Convert.ToInt32(MedIndex - ZEROPOINTFIVE)]+ MemorySort[Convert.ToInt32(MedIndex + ZEROPOINTFIVE)])/2;
                
            }
            if (MedIndex % 1 == 0)
            {
                result = MemorySort[Convert.ToInt32(MedIndex)];

            }
                return (result);
        }
        public double FindMax()
        {
            return (Memory.Max());
        }
        public double FindMin()
        {
            return (Memory.Min());
        }
        public void Edit(int IndexToEdit, double NumberToReplace) {
            Memory[IndexToEdit] = NumberToReplace;

        }
        public void Delete(int IndexToDelete) {
            Memory.RemoveAt(IndexToDelete);
        }
        public void Clear() {
            Memory.Clear();
        }
        public double FindSD()
        {
            double average = Memory.Average();
            double sumOfSquaresOfDifferences = Memory.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / Memory.Count);
            return (sd);
        }


    }
}
