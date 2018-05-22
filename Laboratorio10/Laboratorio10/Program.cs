using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary1;

using System.Runtime.InteropServices;

namespace Laboratorio10
{
    
    class Program
    {
        //[DllImport(@"c:\ClassLibrary1.dll")]
        //private static extern int ClassName(int b);
        static void Main(string[] args)
        {

            //Pregunta 1

            Person persona = new Person();
            Car auto = new Car();
            Address clave = new Address();
            List<Type> types = new List<Type>(persona.GetType(), auto.GetType(), clave.GetType());

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
                    PropertyInfo[] properties = t.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        Console.WriteLine("Property Name: {0}\n", property.Name);
                        Console.WriteLine("Property Type Name: {0}\n", property.PropertyType.Name);
                        Console.WriteLine("Property Type FullName: {0}\n", property.PropertyType.FullName);
                        Console.WriteLine("Can we read the property?: {0}\n", property.CanRead.ToString());
                        Console.WriteLine("Can we write the property?: {0}\n", property.CanWrite.ToString());
                    }
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("Archivo vacio");
                }
            }



            // Pregunta 2
            List<Person> personas = new List<Person>();
            List<Car> autos = new List<Car>();
            List<Address> Propiedades = new List<Address>();
            while (true)
            {
                Console.WriteLine("menu:");
                Console.WriteLine("1.Inscribir persona");
                Console.WriteLine("2.Inscribir Propiedad");
                Console.WriteLine("3.Inscribir automovil");
                Console.WriteLine("4.Salir");
                string eleccion = Console.ReadLine();
                if (eleccion == "1")
                {
                    Console.WriteLine("Ingrese el Primer nombre de la persona:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Ingrese el Apellido de la persona:");
                    string LastNAme = Console.ReadLine();
                    Console.WriteLine("Ingrese el rut de la persona:");
                    string rut = Console.ReadLine();
                    Console.WriteLine("Ingrese el cumpleaños de la persona:");
                    DateTime datebirth = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingrese la calle de la direccion:");
                    string Street = Console.ReadLine();
                    Console.WriteLine("Ingrese el numero de la calle de la direccion:");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Address propiedad;
                    foreach (Address a in Propiedades)
                    {
                        if ((a.Street == Street) & (a.Number == number))
                        {
                            propiedad = a;
                            break;
                        }
                    }
                    Console.WriteLine("Ingrese el rut del primer pariente:");
                    string rut1 = Console.ReadLine();
                    Console.WriteLine("Ingrese el rut del segundo pariente");
                    string rut2 = Console.ReadLine();
                    Person person1;
                    Person person2;
                    foreach (Person p in personas)
                    {
                        if (rut1 == p.Rut)
                        {
                            person1 = p;
                            break;
                        }
                    }
                    foreach (Person p in personas)
                    {
                        if (rut2 == p.Rut)
                        {
                            person2 = p;
                            break;
                        }
                    }
                    Person personanueva = new Person(firstName, LastNAme, datebirth, propiedad, rut, person1, person2);
                    personas.Add(personanueva);

                }
                if (eleccion == "2")
                {
                    Console.WriteLine("");
                }
                if (eleccion == "3")
                {

                }
                if (eleccion == "4")
                {
                    break;
                }
            }

        }
    }
}
