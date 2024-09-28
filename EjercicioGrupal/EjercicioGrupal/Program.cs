using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador = new Jugador("Jugador1", 100);
            Juego juego = new Juego(jugador);

            juego.Iniciar();
        }
    }
}
