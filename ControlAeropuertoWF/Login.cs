using ControlAeropuerto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ControlAeropuertoWF
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        List<Vuelo> Vuelos = new List<Vuelo>();
        List<VueloSalida> VuelosSalida = new List<VueloSalida>();
        List<VueloLlegada> Vuelosllegada = new List<VueloLlegada>();
        //implementar login
        string[] usuarios = new string[3];
        string[] password = new string[3];
        bool esAdmin = false;
        bool esMonitor1 = false;
        bool esMonitor2 = false;
        
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            usuarios[0] = "admin";
            usuarios[1] = "monitor1";
            usuarios[2] = "monitor2";
            password[0] = "admin";
            password[1] = "uno";
            password[2] = "dos";

            esAdmin = txtUsuario.Text.Trim().Equals(usuarios[0]) && txtConstrasenya.Text.Equals(password[0]);
            esMonitor1 = txtUsuario.Text.Trim().Equals(usuarios[1]) && txtConstrasenya.Text.Equals(password[1]);
            esMonitor2 = txtUsuario.Text.Trim().Equals(usuarios[2]) && txtConstrasenya.Text.Equals(password[2]);

            if (esAdmin)
            {
                labelError.Text = "Logueado como usuario admin";
            }
            else if (esMonitor1)
            {
                labelError.Text = "Logueado como usuario monitor1";
            }
            else if (esMonitor2)
            {
                labelError.Text = "Logueado como usuario monitor2";
            }
            else
            {
                labelError.Text = "El usuario y/o contraseña no es correcto";
            }

        }

        // esAdmin = txtUsuario.Text.Equals("") && pass.Equals(password[0]);
        //esMonitor1 = user.Equals(usuarios[1]) && pass.Equals(password[1]);
        //esMonitor2 = user.Equals(usuarios[2]) && pass.Equals(password[2]);

        //usuarios[0] = "admin";
        //    usuarios[1] = "monitor1";
        //    usuarios[2] = "monitor2";
        //    password[0] = "admin";
        //    password[1] = "uno";
        //    password[2] = "dos";
    }
}
