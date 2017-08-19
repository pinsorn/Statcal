using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statcal
{
    class Program //this is class named "Program"
    {
        static void Main(string[] args) //this is method called "Main"
        {
            Statcal.StatisticCalculate Calc = new StatisticCalculate { }; //define new varible type what is StatisticCalculate? let find out at StatisticCalculate.cs
            String Message="";
            Boolean Loop = true;
            String Memory_Display = "";
            int Memory_Index = 0;
            while (Loop == true) {
                Console.Clear();
                //var Calc_Member_Tostring = Calc.Memory;
                foreach (Double Calc_Member_ToString in Calc.Memory) {
                    Memory_Display = Memory_Display + "[" + Memory_Index + "]" + Calc_Member_ToString + " ";
                    Memory_Index++;
                }
                Console.WriteLine("Enter some number to add it to the List or use following command : FindMode FindMed FindMean FindSD FindMax FindMin Sort Edit Generate Help Exit"+ System.Environment.NewLine+"List Of Number"+Memory_Display + System.Environment.NewLine + Message+ System.Environment.NewLine);
                String Function_Command = Console.ReadLine();
                if (Function_Command.ToLower() == "findmed") {
                    Message = "Median = " + Calc.FindMedian();
                }
                else if (Function_Command.ToLower() == "help")
                {
                    Message = "Help Yourself";
                }
                else if (Function_Command.ToLower() == "sort")
                {
                    Calc.sort();
                    Message = "sorted numbers";
                }
                else if (Function_Command.ToLower() == "findmode")
                {
                    Message ="Mode = " + Calc.FindMode();
                }
                else if (Function_Command.ToLower() == "findsd")
                {
                    Message = "SD = " + Calc.FindSD();
                }
                else if (Function_Command.ToLower() == "findmean")
                {
                    Message ="Mean = " + Calc.FindMean();
                }
                else if (Function_Command.ToLower() == "findmax")
                {
                    Message ="Max = " + Calc.FindMax();
                }
                else if (Function_Command.ToLower() == "findmin")
                {
                    Message ="Min = " + Calc.FindMin();
                }
                else if (Function_Command.ToLower() == "exit")
                {
                    Loop = false;
                }
                else if (Function_Command.ToLower() == "generate")
                {
                    Console.WriteLine("(Warining!! this may take some times) Enter Configuration following "+System.Environment.NewLine+"NumberRange(Integer) NumberSize(Integer) Seed(Double) Negative(True/False) Decimal(True/False) Verbose(Integer!!enter 1 if you don't know)");
                    string input = Console.ReadLine();
                    List<string> input_splited = new List<string>(input.Split(' '));
                    int NumberLength = Convert.ToInt32(input_splited[0]);
                    int NumberSize = Convert.ToInt32(input_splited[1]);
                    double seed = Convert.ToDouble(input_splited[2]);
                    bool Negative = false;
                    bool Dec = false;
                    if (input_splited[3].ToLower() == "true") {
                        Negative = true;
                    }
                    if (input_splited[4].ToLower() == "true")
                    {
                        Dec = true;
                    }
                    Calc.generate(NumberLength,NumberSize,seed,Negative,Dec,Convert.ToInt32(input_splited[5]));
                    Message = "Numbers generating were success";
                }
                else if (Function_Command.ToLower() == "edit")
                {
                    Console.WriteLine("usage Edit Index , Del Index or Clear else will cancel");
                    String Input = Console.ReadLine();
                    if (Input.ToLower().StartsWith("edit ")==true) {
                        int IndextoEdit = Convert.ToInt32(Input.Replace("edit ", ""));
                        Console.WriteLine("Enter number to replace at the index");
                        double NumbertoReplace = Convert.ToDouble(Console.ReadLine());
                        Calc.Edit(IndextoEdit, NumbertoReplace);
                        Message = "Index " + IndextoEdit + " Edited to " + NumbertoReplace;
                    }
                    if (Input.ToLower().StartsWith("del ") == true)
                    {
                        int IndextoEdit = Convert.ToInt32(Input.Replace("del ", ""));
                        //double NumbertoReplace = Convert.ToDouble(Console.ReadLine());
                        Calc.Delete(IndextoEdit);
                        Message = "Index " + IndextoEdit + " Has been deleted";
                    }
                    if (Input == "clear")
                    {
                        // int IndextoEdit = Convert.ToInt32(Input.Replace("edit ", ""));
                        //double NumbertoReplace = Convert.ToDouble(Console.ReadLine());
                        Calc.Clear();
                        Message = "Memory has been cleared";
                    }
                    //Message = "Don't Leave the input blank";
                }
                else if (Function_Command == "")
                {
                    Message = "Don't Leave the input blank";
                }
                else { try {
                        Calc.Enter(Convert.ToDouble(Function_Command));
                        Message =Function_Command + " Has added to List";

                    } catch (Exception ex) { Message = ex.ToString(); /*throw ex;/* Loop = false; Console.ReadLine(); */} }
                Memory_Index = 0;
                Memory_Display = "";
            }
            
        }
    }
}
