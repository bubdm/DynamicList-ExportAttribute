using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            //string assemName = args[1];
            string assemName = Assembly.GetExecutingAssembly().Location;
            
            try
            {
                Assembly assembly = Assembly.LoadFrom(assemName);
                DynamicList<Type> types = ClassEnumerator.GetPublicTypes(assembly);
                PrintTypesNames(types);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Файл не существует.\n{0}", ex);
            }
            catch(System.IO.FileLoadException ex)
            {
                Console.WriteLine("Не удалось загрузить файл.\n{0}", ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }

        static void PrintTypesNames(DynamicList<Type> types)
        {
            foreach(Type type in types)
            {
                Console.WriteLine(type.FullName);
            }
            Console.WriteLine();
        }
    }
}
