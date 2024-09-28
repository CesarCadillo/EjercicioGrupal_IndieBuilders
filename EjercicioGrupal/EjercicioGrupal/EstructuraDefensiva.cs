
namespace EjercicioGrupal
{
    internal class EstructuraDefensiva : EstructuraBase
    {
        private int daño;
        public EstructuraDefensiva(string nombre, int precio, int vida, int daño) : base(nombre, precio, vida)
        {
            this.daño = daño;
        }
        
        public override void HabilidadDeLaEstructura(int valor)
        {
            valor -= daño;
        }
    }
}
