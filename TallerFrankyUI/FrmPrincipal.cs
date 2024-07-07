using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    /// <summary>
    /// Clase parcial que representa el formulario principal de la aplicación.
    /// Maneja la interfaz y la lógica relacionada con la gestión de barcos y reparaciones.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        private string pathDirectorio;  // Ruta del directorio y archivo XML de almacenamiento de datos.
        private Taller taller;          // Instancia de la clase Taller para gestionar los barcos.
        private XmlManager xmlManager;  // Instancia de la clase XmlManager para manejar la lectura y escritura de XML.

        /// <summary>
        /// Constructor de la clase FrmPrincipal.
        /// Inicializa componentes, instancia el objeto Taller y XmlManager, y define la ruta del archivo XML.
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            this.taller = new Taller();
            this.xmlManager = new XmlManager();

            // Definición de la ruta del archivo XML
            this.pathDirectorio = "C:\\Users\\Verónica\\Desktop\\Examen LABO\\SPL2_1C2024-main\\barcos.xml";
        }

        /// <summary>
        /// Evento click del botón 'Cargar Barco'.
        /// Abre el formulario FrmBarco para agregar un nuevo barco al taller.
        /// </summary>
        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
            FrmBarco frmAgregarBarco = new FrmBarco();

            if (frmAgregarBarco.ShowDialog() == DialogResult.OK)
            {
                // Agrega el barco al taller y muestra un mensaje de éxito.
                taller.IngresarBarco(frmAgregarBarco.Barcos);
                MessageBox.Show("Barco agregado al taller exitosamente.");
            }
        }

        /// <summary>
        /// Evento click del botón 'Reparar'.
        /// Abre el formulario FrmReparacion para manejar las reparaciones de los barcos en el taller.
        /// </summary>
        private void btnReparar_Click(object sender, EventArgs e)
        {
            FrmReparacion frmReparacion = new FrmReparacion(taller);
            frmReparacion.ShowDialog();
        }

        /// <summary>
        /// Evento de cierre del formulario FrmPrincipal.
        /// Pregunta al usuario si está seguro de salir y cancela el cierre si elige 'No'.
        /// </summary>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Evento click del botón 'Guardar'.
        /// Guarda los datos del taller en un archivo XML en la ruta especificada.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool guardadoExitoso = xmlManager.Guardar(pathDirectorio, this.taller);

            if (guardadoExitoso)
            {
                MessageBox.Show("Taller guardado exitosamente en el archivo XML.");
            }
            else
            {
                MessageBox.Show("Error al guardar el taller en el archivo XML.");
            }
        }

        /// <summary>
        /// Evento Load del formulario FrmPrincipal.
        /// Carga los datos del archivo XML si existe, o muestra un mensaje si no hay datos o el archivo no existe.
        /// </summary>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (File.Exists(pathDirectorio))
            {
                this.taller.Barcos = xmlManager.Leer(pathDirectorio);
            }
            else
            {
                MessageBox.Show("No se encontraron barcos en el archivo XML o el archivo no existe.");
            }
        }
    }

}
