using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ControlAeropuerto
{
    class Serializador
    {
        string nombre;

        public Serializador(string nombreFich)
        {
            nombre = nombreFich;
        }

        public void Guardar(List<Vuelo> objeto)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }

        public List<Vuelo> Cargar()
        {
            List<Vuelo> objeto;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            objeto = (List<Vuelo>)formatter.Deserialize(stream);
            stream.Close();
            return objeto;
        }

    }
}
