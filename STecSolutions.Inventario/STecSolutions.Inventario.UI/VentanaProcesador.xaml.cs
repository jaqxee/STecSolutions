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
    /// Lógica de interacción para VentanaProcesador.xaml
    /// </summary>
    public partial class VentanaProcesador : Window
    {
        public int Id { get; set; }
        public VentanaProcesador()
        {
            InitializeComponent();
        }

        private void btnGuardarProcesadorNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Procesador procesador = new Procesador();
                procesador.Marca = txtMarca.Text;
                procesador.ModeloCpu = txtModeloCpu.Text;
                Id = new ProcesadorBLL().InsertarDatos(procesador);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message,"Campo Obligatorio",MessageBoxButton.OK,MessageBoxImage.Warning); }

            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message, "Error del Sitema", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
