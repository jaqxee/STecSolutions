using Npgsql;
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
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;
using STecSolutions.Inventario.BLL;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaAgregarUbicacion.xaml
    /// </summary>
    public partial class VentanaAgregarUbicacion : Window
    {

        public int Id { get; private set; } 
        public VentanaAgregarUbicacion()
        {
            InitializeComponent();
        }

        private void btnGuardarUbicacion_Click(object sender, RoutedEventArgs e)
        {
            Ubicacion ubicacion = new Ubicacion();
            try
            {
                ubicacion.Sede = txtSede.Text;
                ubicacion.Edificio = txtEdificio.Text;
                ubicacion.Piso = txtPiso.Text;
                ubicacion.Oficina = txtOficina.Text;
                Id = new UbicacionBLL().InsertarDatos(ubicacion);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message, "Campo Obligatorio", MessageBoxButton.OK, MessageBoxImage.Warning); }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message,"Error del Sistema",MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
