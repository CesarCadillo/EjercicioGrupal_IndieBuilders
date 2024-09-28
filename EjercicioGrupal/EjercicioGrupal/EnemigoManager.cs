using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupal
{
    public class EnemigoManager
    {
        private int turno = 0;
        private List<Enemigo> enemigos = new List<Enemigo>();
        private int[] fibonacci = { 0, 1 };

        public void CrearEnemigos()
        {
            int numEnemigos = fibonacci[turno % 2]; 
            for (int i = 0; i < numEnemigos; i++)
            {
                enemigos.Add(new Enemigo("Enemigo " + (enemigos.Count + 1), 20, 10));
                Console.WriteLine("Se ha creado un Enemigo.");
            }

            fibonacci[turno % 2] = fibonacci[0] + fibonacci[1];
            turno++;
        }

        public void AtacarEstructuras(List<EstructuraBase> estructuras)
        {
            if (estructuras.Count == 0)
            {
                Console.WriteLine("No hay estructuras para atacar.");
                return;
            }

            foreach (var enemigo in enemigos)
            {
                if (enemigo.EstaMuerto()) continue;

                // Ataca la primera estructura de defensa, si no hay, ataca las otras en el orden adecuado.
                EstructuraBase objetivo = estructuras.Find(e => e is EstructuraDefensiva)
                                  ?? estructuras.Find(e => e is EstructuraMantenimiento)
                                  ?? estructuras.Find(e => e is EstructuraRecolectora);

                if (objetivo != null)
                {
                    enemigo.AtacarEstructura(objetivo);
                    if (objetivo.vida <= 0)
                    {
                        estructuras.Remove(objetivo);
                    }
                }
            }
        }

        public void MostrarEnemigos()
        {
            foreach (var enemigo in enemigos)
            {
                Console.WriteLine(enemigo.MostrarNombre() + " - Vida: " + enemigo.MostrarVida());
            }
        }

        public bool ListaVacia()
        {
            return enemigos.Count == 0;
        }
    }
}
