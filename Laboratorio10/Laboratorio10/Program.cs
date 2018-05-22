using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Runtime.InteropServices;

namespace Laboratorio10
{
    
    class Program
    {
        //[DllImport(@"c:\ClassLibrary1.dll")]
        //private static extern int ClassName(int b);
        static void Main(string[] args)
        {
            Assembly myassembly;
            myassembly = Assembly.LoadFile("ClassLibrary1.dll");

            Type[] types = myassembly.GetTypes();

            foreach (Type t in types)
            {
                try
                {
                    Console.WriteLine("type information for : " + t.FullName);
                    Console.WriteLine("\tBase Class : " + t.BaseType.FullName);
                    Console.WriteLine("\tIs Class : " + t.IsClass);
                    Console.WriteLine("\tIs Enum : " + t.IsEnum);
                    Console.WriteLine("\tAttributes : " + t.Attributes);
                    MethodInfo[] metodos = t.GetMethods();
                    foreach (MethodInfo m in metodos)
                    {
                        Console.WriteLine("method info: {0}\n" + t.GetMethod(m.Name));
                    }
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("Archivo vacio");
                }
            }
        }
    }
}
