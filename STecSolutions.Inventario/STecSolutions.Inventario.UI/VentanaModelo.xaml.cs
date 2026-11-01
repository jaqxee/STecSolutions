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
    /// Lógica de interacción para VentanaModelo.xaml
    /// </summary>
    public partial class VentanaModelo : Window
    {
        public int Id { get; private set; }
        public VentanaModelo()
        {
            InitializeComponent();
        }

        private void CargaSeguraCmbMarca(object sender, RoutedEventArgs e) 
        {
            CargarComboMarca(); ///////////////////// Te falta hacer metodo dal de cargar datos
        }
        private void CargarComboMarca(int IdMarca)
        {
            if (IdMarca == null || IdMarca == 0)
            {
                this.cmbIdMarca.I = new List<string> { "No hay registro" };
                this.cmbIdMarca.SelectedIndex = 0;
            }
            else 
            {
                this.cmbIdMarca.DisplayMemberPath = "Nombre";
                this.cmbIdMarca.SelectedValuePath = "IdMarca";   
            }
        }

        private void btnNuevaMarca_Click(object sender, RoutedEventArgs e)
        {
            VentanaMarca ventanaMarca = new VentanaMarca();
            if (ventanaMarca.ShowDialog() == true) 
            {
                CargarComboMarca(ventanaMarca.IdMarca);
            }
        }

        private void btnGuardarModeloNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Modelo modelo = new Modelo();
                modelo.NombreModelo = txtNombre.Text;
                modelo.IdMarca = (cmbIdMarca.SelectedValue == null) ? 0 : (int)cmbIdMarca.SelectedValue;            
                if (ventanaMarca.ShowDialog() = true) 
                {
                
                }
            }
            catch (NegocioException ex)
            {
                MessageBox.Show(ex.Message, "Campo Obligatorio", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al conectar con la Base de Datos: "+ ex.Message, "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
