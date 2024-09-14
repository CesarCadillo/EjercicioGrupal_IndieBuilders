using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioGrupal
{
    internal class EstructuraMantenimiento : EstructuraBase
    {
        private int aumentoDeCapacidad;
        
        public EstructuraMantenimiento(string nombre, int precio, int vida, int aumentoDeCapacidad) : base(nombre, precio, vida)
        {
            this.aumentoDeCapacidad = aumentoDeCapacidad;
        }

        public override void HabilidadDeLaEstructura(int valor)
        {
            valor += aumentoDeCapacidad;
        }
    }
}
