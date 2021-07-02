using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesModeloSegundoParcial;

namespace FormularioChiquito
{
    public partial class FrmPrincipal : Form
    {
        private LosHilos hilos;


        public FrmPrincipal()
        {
            InitializeComponent();
            this.hilos = new LosHilos();
            this.hilos.AvisoFin += MostrarMensajeFin;
        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            //Al presionar el botón Lanzar se deberá, mediante la sobrecarga del +,
            //agregar un nuevo hilo al atributo hilos. En caso de error, se mostrará mediante un MessageBox

            try
            {
                hilos += 1;

            }
            catch(CantidadInvalidaException ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hilos.Bitacora);
        }


        public void MostrarMensajeFin(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
