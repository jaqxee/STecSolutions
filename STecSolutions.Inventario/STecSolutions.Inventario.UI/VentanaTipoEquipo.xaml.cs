using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using STecSolutions.Inventario.BLL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.DTO;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaTipoEquipo.xaml
    /// </summary>
    public partial class VentanaTipoEquipo : Window
    {

        public int IdTipoEquipo { get; set; }
        public VentanaTipoEquipo()
        {
            InitializeComponent();
        }

        private void btnGuardarTipoEquipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TipoEquipo nuevoTipo = new TipoEquipo();
                nuevoTipo.Nombre = txtNombre.Text;
                nuevoTipo.Descripcion = txtDescripcion.Text;
                TipoEquipoBLL tipoEquipoBLL = new TipoEquipoBLL();
                IdTipoEquipo = tipoEquipoBLL.InsertarDatos(nuevoTipo);
                this.DialogResult = true;
            }
            catch (NegocioException ex)
            {
                MessageBox.Show(ex.Message, "Datos obligatorios", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la Base de Datos" + ex.Message, "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
