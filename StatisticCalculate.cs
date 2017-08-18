using System;
using System.Collections.Generic;
using System.Linq;

namespace Statcal
{
    class StatisticCalculate
    {
        public List<double> Memory { get; } = new List<double> { };
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
