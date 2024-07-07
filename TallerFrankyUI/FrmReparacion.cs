using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    public partial class FrmReparacion : Form
    {
        private Taller taller;

        /// <summary>
        /// Constructor de la clase FrmReparacion que inicializa el formulario.
        /// </summary>
        /// <param name="taller">Instancia de Taller que contiene la lista de barcos a reparar.</param>
        public FrmReparacion(Taller taller)
        {
            InitializeComponent();
            this.taller = taller;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario, estableciendo la lista de barcos como origen de datos para lstTaller.
        /// </summary>
        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            lstTaller.DataSource = taller.Barcos;
        }

        /// <summary>
        /// Evento que se ejecuta al intentar cerrar el formulario, estableciendo DialogResult.Cancel para cancelar el cierre.
        /// </summary>
        private void FrmReparacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Evento asociado al clic en lblBarcoTipo. No tiene funcionalidad implementada actualmente.
        /// </summary>
        private void lblBarcoTipo_Click(object sender, EventArgs e)
        {

        }
    }

}
