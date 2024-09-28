using System;
using System.Collections.Generic;

namespace EjercicioGrupal
{
    public class Jugador
    {
        public string nombre;
        public int dinero;
        public List<EstructuraBase> estructuras = new List<EstructuraBase>();

        public Jugador(string nombre, int dinero)
        {
            this.nombre = nombre;
            this.dinero = dinero;
        }

        public void ComprarEstructura(EstructuraBase estructura)
        {
            if (dinero >= estructura.precio)
            {
                dinero -= estructura.precio;
                Console.WriteLine("Se ha comprado la estructura " + estructura.nombre);
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero para comprar la estructura " + estructura.nombre);
            }
        }


        public void CrearEstructura()
        {
            Console.WriteLine("\n¿Qué estructura quieres crear?");
            Console.WriteLine("1. Estructura de recolección (Precio: 20, Vida: 50, Dinero que recolecta: 10)");
            Console.WriteLine("2. Estructura de mantenimiento (Precio: 30, Vida: 40, Capacidad extra: 1)");
            Console.WriteLine("3. Estructura de defensa (Precio: 50, Vida: 60, Daño: 15)");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ComprarEstructura(new EstructuraRecolectora("Recolectora", 20, 50, 10));
                    break;

                case "2":
                    ComprarEstructura(new EstructuraMantenimiento("Mantenimiento", 30, 40, 1));
                    break;

                case "3":
                    ComprarEstructura(new EstructuraDefensiva("Defensiva", 50, 60, 15));
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }

        public void MostrarEstructuras()
        {
            Console.WriteLine("El jugador " + nombre + " tiene las siguientes estructuras:");
            foreach (EstructuraBase estructura in estructuras)
            {
                Console.WriteLine(estructura.nombre + " - Vida: " + estructura.vida);
            }
        }

        public List<EstructuraBase> ObtenerEstructuras()
        {
            return estructuras;
        }

        public void PasarTurno()
        {
            foreach (var estructura in estructuras)
            {
                estructura.HabilidadDeLaEstructura(dinero);
            }
        }

        public void PerderEstructura(EstructuraBase estructura)
        {
            if (estructura.vida <= 0)
            {
                estructuras.Remove(estructura);
                Console.WriteLine("Se ha perdido la estructura " + estructura.nombre);
            }
        }

        public void MostrarEstado()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Dinero: " + dinero);
        }

        public bool TieneEstructuras()
        {
            return estructuras.Count > 0;
        }


    }
}
