using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupal
{
    public class Jugador
    {
        private string nombre;
        private int dinero;
        private List<EstructuraBase> estructuras = new List<EstructuraBase>();

        public Jugador(string nombre, int dinero, int vida)
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

        public void MostrarEstructuras()
        {
            Console.WriteLine("El jugador " + nombre + " tiene las siguientes estructuras:");
            foreach (EstructuraBase estructura in estructuras)
            {
                Console.WriteLine(estructura.nombre);
            }
        }
    }
}
