
namespace EjercicioGrupal
{
    public abstract class EstructuraBase
    {
        public string nombre;
        public int precio;
        public int vida;

        protected EstructuraBase(string nombre, int precio, int vida)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.vida = vida;
        }

        public abstract void HabilidadDeLaEstructura(int valor);

        public bool EstaViva()
        {
            return vida > 0;
        }

    }
}
