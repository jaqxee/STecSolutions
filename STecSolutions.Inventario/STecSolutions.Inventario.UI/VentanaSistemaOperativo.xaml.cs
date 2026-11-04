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
using STecSolutions.Inventario.BLL;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaSistemaOperativo.xaml
    /// </summary>
    public partial class VentanaSistemaOperativo : Window
    {
        public int Id { get; set; }
        public VentanaSistemaOperativo()
        {
            InitializeComponent();
        }

        private void btnNuevoSistemaOperativo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SistemaOperativo sistemaOperativo = new SistemaOperativo();
                sistemaOperativo.Nombre = txtNombre.Text;
                sistemaOperativo.Version = txtVersion.Text;
                Id = new SistemaOperativoBLL().InsertarDatos(sistemaOperativo);
                DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message, "Campo Obligatorio", MessageBoxButton.OK, MessageBoxImage.Warning); }

            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos" + ex.Message, "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
