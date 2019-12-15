using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAeropuerto
{
    [Serializable]
    class ClaseAGuardar
    {
        Vuelo  v;

        public void SetDatos(Vuelo v1)
        {
            v = v1;
        }
        public Vuelo GetDatos()
        {
            return v;
        }
    }
}
