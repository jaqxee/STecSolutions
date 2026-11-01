using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using STecSolutions.Inventario.BLL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.DTO;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VentanaInicio : Window
    {
        public VentanaInicio()
        {

            InitializeComponent();
            CargarDatosInventario();
        }

        private void CargarDatosInventario()
        {
            try
            {  
                InventarioBLL inventario = new InventarioBLL();
                dgInventario.ItemsSource = inventario.ObtenerResumenInicial();
            }

            catch (Exception ex) 
            {
                MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message,"Error de Sistema",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregar ventanaRegistro = new VentanaAgregar();
            ventanaRegistro.ShowDialog();
            CargarDatosInventario();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e) 
        {
            
            if (dgInventario.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dgInventario.SelectedItem;
                
                VentanaEliminar ventanaEliminar = new VentanaEliminar();
                ventanaEliminar.ShowDialog();
                CargarDatosInventario();
            }
            else 
            {
                MessageBox.Show("Para eliminar, debe seleccionar una fila.", "No hay elementos seleccionados.", MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }

        }

    
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            
        }



    }
}