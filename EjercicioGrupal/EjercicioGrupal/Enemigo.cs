using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupal
{
    public  class Enemigo
    {
        string nombre;
        int vida;
        int daño;

        public Enemigo(string nombre, int vida, int daño)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.daño = daño;
        }

        public string MostrarNombre()
        {
            return nombre;
        }

        public int MostrarVida()
        {
            return vida;
        }

        public void HacerDaño(int vidaDeLaEstructura)
        {
            vidaDeLaEstructura -= daño;
        }

        public bool EstaMuerto()
        {
            return vida <= 0;
        }

    }
}
