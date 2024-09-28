
namespace EjercicioGrupal
{
    public class EstructuraRecolectora : EstructuraBase
    {
        public int dineroQueRecolecta;
        
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
