using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAeropuerto
{
    [Serializable]
    class VueloSalida : Vuelo
    {
        int PtaEmbarque;
        DateTime horaLimiteEmbarque;

        public int PtaEmbarque1 { get => PtaEmbarque; set => PtaEmbarque = value; }
        public DateTime HoraLimiteEmbarque { get => horaLimiteEmbarque; set => horaLimiteEmbarque = value; }

        public VueloSalida() : base()
        {

        }
        public VueloSalida(int nv) : base(nv)
        {
            this.PtaEmbarque = 0;
           //this.horaLimiteEmbarque
        }
        public VueloSalida(int nv, string ov) :base(nv, ov)
        {
            this.PtaEmbarque = 0;
        }
        public VueloSalida(int nv, string ov, string dv) : base(nv, ov, dv)
        {
            this.PtaEmbarque = 0;
        }
        public VueloSalida(int nv, string ov, string dv, DateTime fp) : base(nv, ov, dv, fp)
        {
            this.PtaEmbarque = 0;
        }
        public override void Mostrar()
        {
            base.Mostrar();            
            string cadena = " " + this.PtaEmbarque + " (" + HoraLimiteEmbarque.Hour + ":" + HoraLimiteEmbarque.Minute + ")";
            Console.Write(cadena);
            Console.WriteLine();

        }
    }
}
