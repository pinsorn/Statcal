using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statcal
{
    class Program
    {
        static void Main(string[] args)
        {
            Statcal.StatisticCalculate Calc = new StatisticCalculate { };
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
                Console.WriteLine("Enter some number to add it to the List or use following command : FindMode FindMed FindMean FindSD FindMax FindMin Edit Exit"+ System.Environment.NewLine+"List Of Number"+Memory_Display + System.Environment.NewLine + Message+ System.Environment.NewLine);
                String Function_Command = Console.ReadLine();
                if (Function_Command.ToLower() == "findmed") {
                    Message = "Median = " + Calc.FindMedian();
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
