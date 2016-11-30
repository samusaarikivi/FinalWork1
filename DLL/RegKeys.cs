using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DLL
{
    //! A dll class.
    /*!
      Dll class that provides functions for FinalWork Main
    */
    public class RegKeys
    {
        //! Registry used for this assignment
        static string registry = "FinalWork\\SamuSaarikivi";
        //! HKEY_CURRENT_USER\FinalWork\SamuSaarikivi\ is the location of registry

        /**
         * Read function,
         * Requires one argument
         */
        public static void Read(string name)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registry);
            //! Read name with value provided by args[1]
            Console.WriteLine(key.GetValue(name));
            key.Close();
        }
        /**
         * List function,
         * Lists all names with values.
         */
        public static void List()
        {
            Console.WriteLine();
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registry))
            {
                //! List names and values from registry
                foreach (String subkeyName in key.GetValueNames())
                {
                    if (subkeyName.Length > 5)
                    {
                        //! if name length is over 5 characters
                        //! add one tab less to keep values in line
                        Console.WriteLine("  " + subkeyName + "\t\t" + key.GetValue(subkeyName));
                    }
                    else
                    {
                        //! add three tabs after names with 5 or less characters
                        Console.WriteLine("  " + subkeyName + "\t\t\t" + key.GetValue(subkeyName));
                    }
                }
            }
        }
        /**
         * Write function,
         * Writes A name with value to registry,
         * Requires two arguments.
         */
        public static void Write(string name, string value)
        {
            //! add name with value provided by args[1], args[2]
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registry);
            key.SetValue(name, value);
            //! Show just added name with value 
            Console.WriteLine("\nName: " + name + " with value: " + value + " set to registry.");
            key.Close();
        }
        /**
         * Delete function
         * Deletes name and value provided by argument
         */
        public static void Delete(string name)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registry, true))
            {
                //! Delete name with value provided by args[1]
                key.DeleteValue(name);
                //! Show just deleted name if it is deleted
                Console.WriteLine((string)key.GetValue(name, name + " is deleted"));
            }
        }
    }
}
