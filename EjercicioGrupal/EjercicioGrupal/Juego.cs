using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupal
{
    public class Juego
    {
        private Jugador jugador;
        private List<Enemigo> enemigos = new List<Enemigo>();
        private int fibonacciActual = 0;
        private int fibonacciAnterior = 0;

        public Juego(Jugador jugador)
        {
            this.jugador = jugador;
        }

        public void Iniciar()
        {
            int turnosSobrevividos = 0;

            do
            {
                turnosSobrevividos++;
                Console.WriteLine($"\n--- Turno {turnosSobrevividos} ---");

                MenuDelJugador();

                TurnoEnemigo();

                if (!jugador.TieneEstructuras())
                {
                    Console.WriteLine($"Has sobrevivido {turnosSobrevividos} turnos.");
                    Console.WriteLine("¡Has perdido! Te has quedado sin estructuras.");
                    break;  
                }

            } while (true); 
        }

        private void MenuDelJugador()
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Ver estructuras");
            Console.WriteLine("2. Crear estructura");
            Console.WriteLine("3. Ver enemigos");
            Console.WriteLine("4. Pasar turno");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    jugador.MostrarEstructuras();
                    break;

                case "2":
                    jugador.CrearEstructura();
                    break;

                case "3":
                    MostrarEnemigos();
                    break;

                case "4":
                    jugador.PasarTurno();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void MostrarEnemigos()
        {
            Console.WriteLine("Enemigos:");
            foreach (var enemigo in enemigos)
            {
                Console.WriteLine(enemigo.nombre + " - Vida: " + enemigo.vida);
            }
        }

        private void TurnoEnemigo()
        {
            if (enemigos.Count == 0)
            {
                CrearEnemigos();
            }

            foreach (var enemigo in enemigos)
            {
                // Se le llama Coalescencia nula, se utiliza para devolver el valor del operando de la izquierda si este no es null o el de la derecha si lo es.
                EstructuraBase objetivo = jugador.estructuras.Find(e => e is EstructuraDefensiva)
                  ?? jugador.estructuras.Find(e => e is EstructuraMantenimiento)
                  ?? jugador.estructuras.Find(e => e is EstructuraRecolectora);

                if (objetivo != null)
                {
                    enemigo.AtacarEstructura(objetivo);
                }
            }

            enemigos.RemoveAll(e => !e.EstaVivo());
        }

        private void CrearEnemigos()
        {
            int nuevosEnemigos = fibonacciActual;

            fibonacciActual = fibonacciActual + fibonacciAnterior;
            fibonacciAnterior = fibonacciActual - fibonacciAnterior;

            for (int i = 0; i < nuevosEnemigos; i++)
            {
                enemigos.Add(new Enemigo("Enemigo " + (i + 1), 30, 10));
            }

            Console.WriteLine($"Se han creado {nuevosEnemigos} enemigos.");
        }
    }
}
