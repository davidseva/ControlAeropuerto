using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAeropuerto
{
    [Serializable]
    class VueloLlegada : Vuelo
    {
        int pistaAsignada;
        int cintEquipAsignada;
        DateTime horaRealLlegada;

        public int PistaAsignada { get => pistaAsignada; set => pistaAsignada = value; }
        public int CintEquipAsignada { get => cintEquipAsignada; set => cintEquipAsignada = value; }
        public DateTime HoraRealLlegada { get => horaRealLlegada; set => horaRealLlegada = value; }

        public VueloLlegada() : base()
        {
            this.pistaAsignada = 0;
            this.cintEquipAsignada = 0;
        }
        public VueloLlegada(int nv) : base(nv)
        {
            this.pistaAsignada = 0;
            this.cintEquipAsignada = 0;
        }
        public VueloLlegada(int nv, string ov):base(nv, ov)
        {
            this.pistaAsignada = 0;
            this.cintEquipAsignada = 0;
        }
        public VueloLlegada(int nv, string ov, string dv)
        {
            this.pistaAsignada = 0;
            this.cintEquipAsignada = 0;
        }

        public VueloLlegada(int nv, string ov, string dv, DateTime fp):base(nv, ov, dv, fp)
        {
            this.horaRealLlegada = fp;
        }

        public override void Mostrar()
        {
            base.Mostrar();            
            string cadena = " " + this.pistaAsignada + " (" + horaRealLlegada.ToString() + ")";
            Console.Write(cadena);
            Console.WriteLine();
        }
    }
}
