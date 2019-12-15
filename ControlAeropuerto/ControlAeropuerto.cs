using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAeropuerto
{
    class ControlAeropuerto
    {
        static void Main(string[] args)
        {
            List <Vuelo> Vuelos = new List<Vuelo>();
            List <VueloSalida> VuelosSalida = new List<VueloSalida>();
            List <VueloLlegada> Vuelosllegada = new List<VueloLlegada>();
            //ArrayList VuelosSalida = new System.Collections.ArrayList();
            //ArrayList VuelosLlegada = new System.Collections.ArrayList();
            //implementar login
            string [] usuarios = new string [3];
            string[] password = new string[3];
            bool esAdmin = false;
            bool esMonitor1 = false;
            bool esMonitor2 = false;
            usuarios[0] = "admin";
            usuarios[1] = "monitor1";
            usuarios[2] = "monitor2";
            password[0] = "admin";
            password[1] = "uno";
            password[2] = "dos";

            do
            {
                Console.WriteLine("Usuario:");
                string user = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Password:");
                string pass = Console.ReadLine();
                esAdmin = user.Equals(usuarios[0]) && pass.Equals(password[0]);
                esMonitor1 = user.Equals(usuarios[1]) && pass.Equals(password[1]);
                esMonitor2 = user.Equals(usuarios[2]) && pass.Equals(password[2]);
            }
            while (!(esAdmin || esMonitor1 || esMonitor2));

            if (esAdmin)
            {
                
                Serializador s = new Serializador("vuelos.dat");

                // Leemos los datos del archivo o los creamos si no existe
                if (File.Exists("vuelos.dat"))
                    Vuelos = s.Cargar();
                else
                    Vuelos.Clear();

                

                string opcion = "";
                do
                {
                    Console.WriteLine("Indique una opción:");
                    MostrarMenuAdm();
                    Console.WriteLine("");
                    opcion = Console.ReadLine();

                    switch (Convert.ToInt32(opcion))
                    {
                        case 1:
                            CrearNuevoVuelo();
                            break;
                        case 2:
                            Eliminarvuelo();
                            break;
                        case 3:
                            CambiarEstadoVuelo();
                            break;
                        case 4:
                            AnyadirRetrasoVuelo();
                            break;
                        default:
                            return;
                            break;

                    }
                }
                while (!(opcion.Equals("5")));

                
            }

            if (esMonitor1) 
            {
                //Muestra vuelos de salida cuyas horas estén entre hace una hora desde la hora actual hasta 2 horas después de la hora actual
                // Mostrar  listado de vuelos de llegada ordenados por número de vuelo

                // Leemos los datos del archivo o los creamos si no existe
                Serializador s = new Serializador("vuelos.dat");
                if (File.Exists("vuelos.dat"))
                    Vuelos = s.Cargar();
                else
                    Vuelos.Clear();

                Vuelos.OrderBy(p => p.NumVuelo).ToList();

                foreach (Vuelo vue in Vuelos)
                {
                    
                    if (vue.GetType().Equals(typeof(VueloSalida)))
                    {
                        DateTime dt1HMenos = DateTime.Now.AddHours(-1);
                        DateTime dt2HMas = DateTime.Now.AddHours(2);
                        if(vue.FechaPrevista > dt1HMenos && vue.FechaPrevista < dt2HMas)
                        {
                            if (vue.Estado == Vuelo.estado.enHora)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else if (vue.Estado == Vuelo.estado.retrasado)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (vue.Estado == Vuelo.estado.cancelado)
                                Console.ForegroundColor = ConsoleColor.Red;

                            vue.Mostrar();
                        }

                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (esMonitor2)
            {
                //Muestra vuelos de llegada cuya hora estimada estén entre hace una hora desde la hora actual hasta 2 horas después de la hora actual
                // Mostrar  listado de vuelos de llegada ordenados por número de vuelo

                // Leemos los datos del archivo o los creamos si no existe
                Serializador s = new Serializador("vuelos.dat");
                if (File.Exists("vuelos.dat"))
                    Vuelos = s.Cargar();
                else
                    Vuelos.Clear();

                Vuelos.OrderBy(p => p.NumVuelo).ToList();                               
                foreach (Vuelo vue in Vuelos)
                {
                    if (vue.GetType().Equals(typeof(VueloLlegada)))
                    {
                        DateTime dt1HMenos = DateTime.Now.AddHours(-1);
                        DateTime dt2HMas = DateTime.Now.AddHours(2);
                        if (vue.FechaPrevista > dt1HMenos && vue.FechaPrevista < dt2HMas)
                        {

                            if (vue.Estado == Vuelo.estado.enHora)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else if (vue.Estado == Vuelo.estado.retrasado)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (vue.Estado == Vuelo.estado.cancelado)
                                Console.ForegroundColor = ConsoleColor.Red;
                            
                            vue.Mostrar();
                        }
                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            void MostrarMenuAdm()
            {
                Console.WriteLine("1. Nuevo vuelo");
                Console.WriteLine("2. Eliminar vuelo");
                Console.WriteLine("3. Cambiar estado vuelo");
                Console.WriteLine("4. Añadir retraso a vuelo");                
                Console.WriteLine("5. Salir");                
            }
            //usuario administrador
            void CrearNuevoVuelo()
            {
                string opcion = "";
                do
                {
                    Console.WriteLine("Indique una opción:");
                    MostrarTipoVueloNuevo();
                    Console.WriteLine("");
                    opcion = Console.ReadLine();
                }
                while (!(opcion.Equals("1") || opcion.Equals("2")));

                switch (Convert.ToInt32(opcion))
                {
                    case 1:
                        CrearNuevoVueloLlegada();
                        break;
                    case 2:
                        CrearNuevoVueloSalida();
                        break;                   
                    default:
                        return;

                }
            }

            void MostrarTipoVueloNuevo()
            {
                Console.WriteLine("1. Vuelo de Llegada");
                Console.WriteLine("2. Vuelo de Salida");
            }
            void CrearNuevoVueloLlegada()
            {
                
                //NumVuelo
                
                int nv = 0;
                do
                {
                    Console.WriteLine("Indique el número de vuelo");
                    Console.WriteLine("");
                    nv = Convert.ToInt32(Console.ReadLine());
                }
                while (nv.GetType().ToString().Equals("int"));



                //OrigenVuelo
                string ov = "";
                Console.WriteLine("Indique el origen del vuelo");
                
                ov = Console.ReadLine();
                //DestinoVuelo
                string dv = "";
                Console.WriteLine("Indique el destino del vuelo");
                dv = Console.ReadLine();
                //FechaPrevista
                string strFp = "";
                DateTime fp = DateTime.Now;
                Console.WriteLine("Indique la fecha prevista de llegada del vuelo");
                strFp = Console.ReadLine();
                fp = Convert.ToDateTime(strFp);
                VueloLlegada vueloLleg = new VueloLlegada(nv, ov, dv, fp);
                Vuelos.Add(vueloLleg);
                Vuelosllegada.Add(vueloLleg);

                Serializador s = new Serializador("vuelos.dat");
                s.Guardar(Vuelos);
            }
            void CrearNuevoVueloSalida()
            {
                //NumVuelo
                int nv = 0;
                do
                {
                    Console.WriteLine("Indique el número de vuelo");
                    Console.WriteLine("");
                    nv = Convert.ToInt32(Console.ReadLine());
                }
                while (nv.GetType().ToString().Equals("int"));



                //OrigenVuelo
                string ov = "";
                Console.WriteLine("Indique el origen del vuelo");
                ov = Console.ReadLine();
                //DestinoVuelo
                string dv = "";
                Console.WriteLine("Indique el destino del vuelo");
                dv = Console.ReadLine();
                //FechaPrevista
                string strFp = "";
                DateTime fp = DateTime.Now;
                Console.WriteLine("Indique la fecha prevista de salida del vuelo");
                strFp = Console.ReadLine();
                fp = Convert.ToDateTime(strFp);

                VueloSalida vueloSal = new VueloSalida(nv, ov, dv, fp);
                //HoraLimiteEmbarque
                string horas = "";
                string minutos = "";
                Console.WriteLine("Indique la hora límite de embarque del vuelo");
                Console.WriteLine("Horas (0-23)");
                horas = Console.ReadLine();
                Console.WriteLine("Minutos (0-59)");
                minutos = Console.ReadLine();               
                
                
                DateTime hleu = new DateTime(fp.Year, fp.Month, fp.Day, Convert.ToInt32(horas), Convert.ToInt32(minutos), 0);
                vueloSal.HoraLimiteEmbarque = hleu;
                Vuelos.Add(vueloSal);
                VuelosSalida.Add(vueloSal);

                Serializador s = new Serializador("vuelos.dat");
                s.Guardar(Vuelos);
            }

            void Eliminarvuelo()
            {
                // Mostrar  listado de vuelos ordenados por número de vuelo
                Vuelos.OrderBy(p => p.NumVuelo).ToList();
                foreach (Vuelo vue in Vuelos)
                {
                    vue.Mostrar();
                }

                //foreach (Vuelo vue in Vuelos)
                //{
                //    if(vue.GetType().Equals(typeof(VueloLlegada)))
                //    {
                //        VueloLlegada vueLl = (VueloLlegada) vue;
                //        vueLl.Mostrar();
                //    }

                //    if (vue.GetType().Equals(typeof(VueloSalida)))
                //    {
                //        VueloSalida vueSal = (VueloSalida)vue;
                //        vueSal.Mostrar();
                //    }

                //}

                //foreach (VueloLlegada vueLl in Vuelosllegada)
                //{
                //    vueLl.Mostrar();
                //}

                //foreach(VueloSalida vuelSal in VuelosSalida)
                //{
                //    vuelSal.Mostrar();
                //}

                int nv = 0;
                do
                {
                    Console.WriteLine("Indique el número de vuelo a borrar:");
                    Console.WriteLine("");
                    nv = Convert.ToInt32(Console.ReadLine());
                }
                while (nv.GetType().ToString().Equals("int"));

                bool encontrado = false;
                Vuelo vueloAEliminar = new Vuelo();
                foreach(Vuelo vs in Vuelos)
                {
                    if(vs.NumVuelo == nv)
                    {
                        vueloAEliminar = vs;
                        encontrado = true;
                    }

                }

                if (!encontrado)
                {
                    Console.WriteLine("Número de vuelo erróneo:");
                }
                else
                {
                    Console.WriteLine("¿Seguro que quiere eliminar el vuelo con número {0}? (s/n)", nv);
                    string resp = Console.ReadLine();
                    if(resp.ToLower() == "s" || resp.ToLower() == "si" || resp.ToLower() == "sí")
                    {
                        Vuelos.Remove(vueloAEliminar);
                        Console.WriteLine("Vuelo eliminado.");

                        Serializador s = new Serializador("vuelos.dat");
                        s.Guardar(Vuelos);
                    }
                    else
                    {
                        return;
                    }
                }

            }
            void CambiarEstadoVuelo()
            {
                // Mostrar  listado de vuelos ordenados por número de vuelo
                Vuelos.OrderBy(p => p.NumVuelo).ToList();
                foreach (Vuelo vue in Vuelos)
                {
                    vue.Mostrar();
                }

                int nv = 0;
                do
                {
                    Console.WriteLine("Indique el número de vuelo a editar:");
                    Console.WriteLine("");
                    nv = Convert.ToInt32(Console.ReadLine());
                }
                while (nv.GetType().ToString().Equals("int"));

                int est = 0;
                do
                {
                    MostrarEstadosVuelo();
                    est = Convert.ToInt32(Console.ReadLine());
                }
                while (est < 1 || est > 6 );


                foreach (Vuelo vl in Vuelos)
                {
                    if(vl.NumVuelo == nv)
                    {
                        switch (est)
                        {
                            case 1:
                                vl.Estado = Vuelo.estado.enVuelo;
                                break;

                            case 2:
                                vl.Estado = Vuelo.estado.desembarcando;
                                break;

                            case 3:
                                vl.Estado = Vuelo.estado.cancelado;
                                break;

                            case 4:
                                vl.Estado = Vuelo.estado.embarcando;
                                break;

                            case 5:
                                vl.Estado = Vuelo.estado.enHora;
                                break;

                            case 6:
                                vl.Estado = Vuelo.estado.retrasado;
                                break;

                            default:
                                break;

                        }
                            
                    }
                }

                Serializador s = new Serializador("vuelos.dat");
                s.Guardar(Vuelos);

            }
            void AnyadirRetrasoVuelo()
            {
                // Mostrar  listado de vuelos de llegada ordenados por número de vuelo
                Vuelos.OrderBy(p => p.NumVuelo).ToList();
                
                foreach (Vuelo vue in Vuelos)
                {
                    if (vue.GetType().Equals(typeof(VueloLlegada)))
                    {
                        vue.Mostrar();
                    }
                    
                }

                int nv = 0;
                do
                {
                    Console.WriteLine("Indique el número de vuelo a editar:");
                    Console.WriteLine("");
                    nv = Convert.ToInt32(Console.ReadLine());
                }
                while (nv.GetType().ToString().Equals("int"));

                //
                string horas = "";
                string minutos = "";
                Console.WriteLine("Indique el retraso del vuelo");
                Console.WriteLine("Horas (0-23)");
                horas = Console.ReadLine();
                Console.WriteLine("Minutos (0-59)");
                minutos = Console.ReadLine();


                foreach (Vuelo vl in Vuelos)
                {
                    if (vl.NumVuelo == nv)
                    {
                        //DateTime hrll = new DateTime(vl.FechaPrevista.Year, vl.FechaPrevista.Month, vl.FechaPrevista.Day, Convert.ToInt32(horas), Convert.ToInt32(minutos), 0);
                        
                        if (vl.GetType().Equals(typeof(VueloLlegada)))
                        {
                           VueloLlegada vueLl = (VueloLlegada) vl;                            
                            vueLl.HoraRealLlegada = vueLl.HoraRealLlegada.AddHours(Convert.ToDouble(horas));
                            vueLl.HoraRealLlegada =  vueLl.HoraRealLlegada.AddMinutes(Convert.ToDouble(minutos));
                        }
                    }
                }
                Serializador s = new Serializador("vuelos.dat");
                s.Guardar(Vuelos);

            }
            void MostrarEstadosVuelo()
            {
                Console.WriteLine("Elija uno de los siguientes estados:");
                Console.WriteLine();
                Console.WriteLine("1. En Vuelo");
                Console.WriteLine("2. Desembarcando");
                Console.WriteLine("3. Cancelado");
                Console.WriteLine("4. Embarcando");
                Console.WriteLine("5. En hora");
                Console.WriteLine("6. Retrasado");
                Console.WriteLine();
            }
        }
    }
}
