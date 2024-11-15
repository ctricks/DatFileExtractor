using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("*                                                                     *");
            Console.WriteLine("*              Welcome to DatFile Reader/Extractor                    *");
            Console.WriteLine("*                                                                     *");
            Console.WriteLine("***********************************************************************");

            string DirectoryPath = "C:\\DatFile";

            Console.WriteLine("\n\n\n");

            if (!Directory.Exists(DirectoryPath))
            {
                Console.WriteLine("Error: Cannot continue. Please create folder first in this path: " + DirectoryPath);
                Console.WriteLine("\n\nPress any key to terminate...");


                Console.ReadKey();
                Environment.Exit(0);
            }


            Console.WriteLine("Instruction : Put your .dat file in this directory "+ DirectoryPath + "\n\nPress Ctrl + C to terminate....\n\n");
            Console.WriteLine("\n\n");

            

            int counter = 5;
            

            clsFunction MyFunction = new clsFunction();

            do
            {
                Console.Write("\rCheck file...." + counter);
                Console.Write("\r");
                

                counter--;

                Thread.Sleep(1000);

                
                if (counter == 0)
                {
                    Console.Write("\rCheck file...." + counter);
                    Thread.Sleep(1000);

                    if(MyFunction.CheckFile(DirectoryPath))
                    {
                        int filecount = 0;
                        string FileNameToProcess = MyFunction.GetFileName(DirectoryPath);

                        if (FileNameToProcess == null)
                        {
                            counter = 5;
                            Console.SetCursorPosition(0, 17);
                            continue;
                        }

                        filecount = MyFunction.GetFileDat(DirectoryPath);
                        string DisplayUI = string.Empty;

                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tFile Found: " + filecount;
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tFilename: " + FileNameToProcess;
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tReading File....";
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tFile Content....\n";
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        DisplayUI = MyFunction.ReadDatFile(FileNameToProcess);
                        MyFunction.ExtractMyDate(DisplayUI, DirectoryPath);
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tDone Reading....";
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);                        
                        MyFunction.PlacedDone(FileNameToProcess);
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tPlaced Done....";
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        Console.WriteLine(DisplayUI);                        
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tPut it on DONE....";
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                        DisplayUI = DateTime.Now.ToString("yyyy-dd-mm hh:mm:ss") + "\tDone Processing....\n\n";
                        Console.WriteLine(DisplayUI);
                        MyFunction.LogActivity(FileNameToProcess, DisplayUI);
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 17);
                    }

                    counter = 5;
                }
                    
            } while (1 == 1);


        }
    }
}
