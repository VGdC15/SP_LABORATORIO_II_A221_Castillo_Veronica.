using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    /// <summary>
    /// Clase parcial que representa el formulario FrmBarco para la creación y carga de barcos.
    /// Permite seleccionar el tipo de barco, la operación a realizar y validar la información ingresada.
    /// </summary>
    public partial class FrmBarco : Form
    {
        private Taller tallerNuevo;  // Instancia de la clase Taller para gestionar los barcos.
        public Barco barcos;         // Instancia de la clase Barco para almacenar el barco creado.
        public Barco Barcos          // Propiedad para acceder y modificar el barco creado.
        {
            get => this.barcos;
            set => this.barcos = value;
        }

        /// <summary>
        /// Constructor de la clase FrmBarco.
        /// Inicializa componentes del formulario y carga las opciones de tipo de barco y operación disponibles.
        /// </summary>
        public FrmBarco()
        {
            InitializeComponent();
            this.tallerNuevo = new Taller();

            // Agrega opciones de ETipoBarco al ComboBox
            foreach (ETipoBarco tipo in Enum.GetValues(typeof(ETipoBarco)))
            {
                cmbTipo.Items.Add(tipo);
            }

            // Agrega opciones de EOperacion al ComboBox
            foreach (EOperacion operacion in Enum.GetValues(typeof(EOperacion)))
            {
                cmbOperacion.Items.Add(operacion);
            }
        }

        /// <summary>
        /// Evento click del botón 'Cargar'.
        /// Valida los datos ingresados (nombre, tipo de barco y operación), instancia el barco correspondiente
        /// y cierra el formulario si la validación es exitosa.
        /// </summary>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida el nombre del barco
                string nombre = txtNombre.Text;
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre no puede estar vacío. Intente nuevamente.");
                    return;
                }

                // Valida la selección del tipo y operación del barco
                if (cmbTipo.SelectedItem == null || cmbOperacion.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione el tipo y la operación del barco.");
                    return;
                }

                // Obtiene las selecciones del ComboBox
                ETipoBarco tipoBarco = (ETipoBarco)cmbTipo.SelectedItem;
                EOperacion operacion = (EOperacion)cmbOperacion.SelectedItem;

                // Instancia el objeto Barco según el tipo seleccionado
                if (tipoBarco == ETipoBarco.Pirata)
                {
                    Barcos = new Pirata(0, false, nombre, operacion, 20);
                }
                else if (tipoBarco == ETipoBarco.Marina)
                {
                    Barcos = new Marina(0, false, nombre, operacion, 54);
                }

                // Si la validación y la instancia del barco fueron exitosas, cierra el formulario y retorna OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al instanciar el barco: {ex.Message}");
            }
        }
    }

}
