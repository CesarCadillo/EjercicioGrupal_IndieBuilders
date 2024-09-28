
namespace EjercicioGrupal
{
    internal class EstructuraRecolectora : EstructuraBase
    {
        private int dineroQueRecolecta;
        
        public EstructuraRecolectora(string nombre, int precio, int vida, int dineroQueRecolecta) : base(nombre, precio, vida)
        {
            this.dineroQueRecolecta = dineroQueRecolecta;
        }

        public override void HabilidadDeLaEstructura(int valor)
        {
            valor += dineroQueRecolecta;
        }
    }
}
