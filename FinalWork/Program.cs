using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace FinalWork
{
    /********************************************//**
    *  Main Class
    ***********************************************/
    /*!
     * Utilizes functions provided by RegKeys dll.
     * Works with arguments, see help for more info
     */
    class Program
    {
        /**
        * Main Function
        */
        public static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "-h") /*!< Show help if no arguments are given or args[0] = "-h" */
            {
                string[] helps = new string[] 
                {
                        "-h for help",
                        "-r + argument for reading names registry",
                        "-w + two arguments for writing registry",
                        "-l for listing names registry",
                        "-d + argument for deleting a specific registry key"
                };
                foreach (string help in helps) /*!< display helps string[] array*/
                {
                    System.Console.WriteLine(help);
                }
            }
            if (args.Length > 0) /*!< if arguments other than "-h" are given use RegKeys functions */
            {
                switch (args[0])
                {
                    //! Read();
                    case "-r": /*!< Read(); */
                        //! if required args.Length is met
                        if (args.Length == 2) /*!< if required args.Length is met*/

                        {
                            RegKeys.Read(args[1]);
                        }
                        //! else give user a notice
                        else /*!< else give user a notice */
                        {
                            Console.WriteLine("\nCommand needs one argument!");
                        }                   
                        break;

                    case "-w":
                        //! if required args.Length is met
                        if (args.Length == 3)
                        {
                            RegKeys.Write(args[1], args[2]);
                        }
                        //! else give user a notice
                        else
                        {
                            Console.WriteLine("\nCommand needs two arguments!");
                        }
                        break;

                    case "-l":
                        if (args.Length == 1)
                        {
                            RegKeys.List();
                        }
                        else /*!< if aguments are given, give user a notice */
                        {
                            Console.WriteLine("\nCommand needs no arguments!");
                        }
                        break;

                    case "-d":
                        //! if required args.Length is met
                        if (args.Length == 2)
                        {
                            RegKeys.Delete(args[1]);
                        }
                        //! else give user a notice
                        else
                        {
                            Console.WriteLine("\nCommand needs one argument!");
                        }
                        break;
                }
            }
        }
    }
}
