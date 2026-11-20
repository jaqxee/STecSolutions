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
    /// Lógica de interacción para VentanaEstadoOperativo.xaml
    /// </summary>
    public partial class VentanaEstadoOperativo : Window
    {
        public int Id { get; private set; }
        public VentanaEstadoOperativo()
        {
            InitializeComponent();
        }

        private void btnGuardarNuevoEstadoOperativo_Click(object sender, RoutedEventArgs e)
        {
            EstadoOperativo estadoOperativo = new EstadoOperativo();
            estadoOperativo.Nombre = txtNombre.Text;
            estadoOperativo.Descripcion = txtDescripcion.Text;
            try
            {
                Id = new EstadoOperativoBLL().InsertarDatos(estadoOperativo);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message, "Campo Obligatorio", MessageBoxButton.OK, MessageBoxImage.Warning); }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message,"Error del Sistema",MessageBoxButton.OK,MessageBoxImage.Error); }
        }
    }
}
