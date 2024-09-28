using System;

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


        public void AtacarEstructura(EstructuraBase estructura)
        {
            estructura.vida -= daño;  
            Console.WriteLine(nombre + " ataca a " + estructura.nombre);

            if (estructura.vida <= 0)
            {
                Console.WriteLine("La estructura " + estructura.nombre + " ha sido destruida.");
            }
        }


    }
}
