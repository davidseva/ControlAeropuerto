using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAeropuerto
{
    [Serializable]
    class Vuelo
    {
        int numVuelo;
        string origenVuelo;
        string destinoVuelo;
        DateTime fechaPrevista;

        public int NumVuelo { get => numVuelo; set => numVuelo = value; }
        public string OrigenVuelo { get => origenVuelo; set => origenVuelo = value; }
        public string DestinoVuelo { get => destinoVuelo; set => destinoVuelo = value; }
        public DateTime FechaPrevista { get => fechaPrevista; set => fechaPrevista = value; }
        public estado Estado { get; set; }
        public enum estado
        {
            enVuelo,
            aterrizando,
            desembarcando,
            cancelado,
            embarcando,
            enHora,
            retrasado
        }

        public Vuelo()
        {
                        
        }
        public Vuelo(int nv)
        {
            this.numVuelo = nv;
        }
        public Vuelo(int nv, string ov)
        {
            this.numVuelo = nv;
            this.origenVuelo = ov;
        }
        public Vuelo(int nv, string ov, string dv)
        {
            this.numVuelo = nv;
            this.origenVuelo = ov;
            this.destinoVuelo = dv;
        }
        public Vuelo(int nv, string ov, string dv, DateTime fp)
        {
            this.numVuelo = nv;
            this.origenVuelo = ov;
            this.destinoVuelo = dv;
            this.fechaPrevista = fp;
        }

        public virtual void Mostrar()
        {
            string cadena = "[" + this.FechaPrevista.ToString() + "] [" + this.NumVuelo + "] " + this.OrigenVuelo + " - " + this.DestinoVuelo + "(" + this.Estado +")";
            Console.Write(cadena);
        }
    }
}
