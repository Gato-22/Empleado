using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleado.modelos;

namespace Empleado
{
    public class Program
    {
        static void Main(string[] args)
        {
            //using (var context= new EmpleadosDbContext())
            //{
            //    var lista = context.Empleados.ToList();
            //    foreach (var empleado in lista)
            //    {
            //        Console.WriteLine($"{empleado.Nombre}  {empleado.Apellido}");
            //    }
            //    Console.WriteLine($"cantidad de registros: {lista.Count()}");
            //}
            //Console.ReadLine();
            bool continuar = true;
            do
            {
                Console.WriteLine("Bienvenido al menu principal.");
                Console.WriteLine("Seleccione 1 opcion:\nL = Listar Empleados\nA = Agregar Empleado\n" +
                    "B = Borrar Empleado\nE = Editar Empleado\nS = Salir Del Programa");
                var r = Console.ReadLine();
                if (r.ToLower() == "a")
                {
                    Console.Clear();
                    Console.WriteLine("Completar con datos:");
                    AgregarEmpleado();
                }
                else if (r.ToLower() == "b")
                {
                    Console.Clear();
                    BorrarEmpleado();

                }
                else if (r.ToLower() == "l")
                {
                    Console.Clear();
                    ListarEmpleados();
                }
                else if (r.ToLower() == "e")
                {
                    Console.Clear();
                    EditarEempleado();
                }
                else if (r.ToLower()=="s")
                {
                    continuar = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Error Contacte al administrador en sistemas!");
                }

                Console.ReadLine();
                Console.Clear();
            } while (continuar);
        }

        private static void ListarEmpleados()
        {
            using (var context = new EmpleadosDbContext())
            {
                var lista = context.Empleados.ToList();
                foreach (var e in lista)
                {
                    Console.WriteLine($"{e.Nombre}, {e.Apellido} y su edad es: {e.Edad}");
                }
                Console.WriteLine($"\nCantidad de registros: {context.Empleados.Count()}");
            }
        }

        private static void AgregarEmpleado()
        {
            using (var context = new EmpleadosDbContext())
            {
                //No se como hacerlo para que quede bien
                Console.WriteLine("Ingrese el nombre: ");
                var nombreEstudiante = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido: ");
                var apellidoEstudiante = Console.ReadLine();
                Console.WriteLine("Ingrese su edad: ");
                int edad= int.Parse(Console.ReadLine());


                var e = new modelos.Empleado()
                {
                    Nombre = nombreEstudiante,
                    Apellido = apellidoEstudiante,
                    Edad = edad
                };
                context.Empleados.Add(e);
                context.SaveChanges();
                Console.WriteLine("Registro Agregado");
            }
        }
        private static void BorrarEmpleado()
        {
            using (var context = new EmpleadosDbContext())
            {
                Console.WriteLine("Ingrese el ID del Empleado");
                var eID = int.Parse(Console.ReadLine());
                var empleado = context.Empleados.SingleOrDefault(e =>  e.EmpleadoId== eID);
                if (empleado != null)
                {
                    context.Empleados.Remove(empleado);
                    context.SaveChanges();
                    Console.WriteLine("Registro Borrado");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }
        private static void EditarEempleado()
        {
            using (var context = new EmpleadosDbContext())
            {
                Console.Write("ID del empleado a cambiar:");
                var id = int.Parse(Console.ReadLine());
                var empleado = context.Empleados.SingleOrDefault(e => e.EmpleadoId == id);
                Console.WriteLine("Nombre\nApellido\nEdad");
                if (empleado != null)
                {
                    empleado.Nombre = Console.ReadLine();
                    empleado.Apellido = Console.ReadLine();
                    empleado.Edad = int.Parse(Console.ReadLine());

                    context.SaveChanges();
                    Console.WriteLine("Registro editado");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
                
            }
        }
    }
    
}
