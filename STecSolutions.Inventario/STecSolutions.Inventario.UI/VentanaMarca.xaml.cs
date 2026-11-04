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
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaMarca.xaml
    /// </summary>
    public partial class VentanaMarca : Window
    {
        public int IdMarca { get; set; }
        public VentanaMarca()
        {
            InitializeComponent();
        }

        private void btnGuardarMarcaNueva_Click(object sender, RoutedEventArgs e)
        {
            Marca marca = new Marca();
            marca.Nombre = this.txtMarca.Text;
            try
            {
                IdMarca = new MarcaBLL().InsertarDatos(marca);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message,"Campo Obligatorio",MessageBoxButton.OK,MessageBoxImage.Warning); }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos" + ex.Message, "Error del Sistema", MessageBoxButton.OK,MessageBoxImage.Error); }
        }
    }
}
