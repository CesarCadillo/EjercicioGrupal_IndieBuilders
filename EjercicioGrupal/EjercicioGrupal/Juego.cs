using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioGrupal
{
    public class Juego
    {
        private Jugador jugador;
        private List<Enemigo> enemigos = new List<Enemigo>();
        private int fibonacciActual = 1; // Inicializa en 1 para generar enemigos
        private int fibonacciAnterior = 0;

        public Juego(Jugador jugador)
        {
            this.jugador = jugador;
        }

        public void Iniciar()
        {
            int turnosSobrevividos = 0;

            while (jugador.TieneEstructuras())
            {
                Console.Clear();
                turnosSobrevividos++;
                Console.WriteLine($"\n--- Turno {turnosSobrevividos} ---");
                Console.WriteLine($"Dinero: {jugador.dinero}");
                jugador.MostrarEstructuras();
                MostrarEnemigos(enemigos);
                MenuDelJugador();
                TurnoEnemigo();
                if (!jugador.TieneEstructuras())
                {
                    Console.WriteLine($"Has sobrevivido {turnosSobrevividos} turnos.");
                    Console.WriteLine("¡Has perdido! Te has quedado sin estructuras.");
                    Console.ReadLine();
                    break;
                }

            } while (true);
        }

        public void MostrarEnemigos(List<Enemigo> enemigos)
        {
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
                EstructuraBase objetivo = jugador.estructuras.Find(e => e is EstructuraDefensiva)
                    ?? jugador.estructuras.Find(e => e is EstructuraMantenimiento)
                    ?? jugador.estructuras.Find(e => e is EstructuraRecolectora);

                if (objetivo != null)
                {
                    enemigo.AtacarEstructura(objetivo);
                }
            }

            foreach (var estructura in jugador.estructuras)
            {
                if (estructura is EstructuraRecolectora)
                {
                    jugador.dinero += ((EstructuraRecolectora)estructura).dineroQueRecolecta;
                }
            }

            jugador.estructuras.RemoveAll(e => !e.EstaViva());

            enemigos.RemoveAll(e => !e.EstaVivo());
        }

        private void CrearEnemigos()
        {
            int nuevosEnemigos = fibonacciActual;

            int siguienteFibonacci = fibonacciActual + fibonacciAnterior;
            fibonacciAnterior = fibonacciActual;
            fibonacciActual = siguienteFibonacci;

            for (int i = 0; i < nuevosEnemigos; i++)
            {
                enemigos.Add(new Enemigo("Enemigo " + (enemigos.Count + 1), 30, 10));
            }

            Console.WriteLine($"Se han creado {nuevosEnemigos} enemigos.");
        }
        private void MenuDelJugador()
        {
            
        }

        private void MostrarEnemigos()
        {
            Console.WriteLine("Enemigos:");
            foreach (var enemigo in enemigos)
            {
                Console.WriteLine(enemigo.nombre + " - Vida: " + enemigo.vida);
            }
        }
    }
}
