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
using STecSolutions.Inventario.Entities.Excepciones;
using STecSolutions.Inventario.BLL;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaEliminar.xaml
    /// </summary>
    public partial class VentanaEliminar : Window
    {
        private readonly string _idEliminar;
        public VentanaEliminar(string idEliminar)
        {
            InitializeComponent();
            _idEliminar = idEliminar;
            //ContenidoEtiqueta();
        }

        private void btnConfirmarEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new InventarioTecnologicoBLL().IdAEliminar(_idEliminar);
                MessageBox.Show("El registro ha sido eliminado exitosamente","Registro eliminado",MessageBoxButton.OK,MessageBoxImage.Information);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message,"El registro ya no existe",MessageBoxButton.OK,MessageBoxImage.Warning); this.DialogResult = true; }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message,"Error de Sistema",MessageBoxButton.OK,MessageBoxImage.Error); }
        }

        private void btnCancelarEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ContenidoTextblock()
        {
            this.mensajeEliminar.Text = $"""Está eliminando el equipo con numero de serie: {_idEliminar}""";
        }

        private void CargaContenido(object sender, RoutedEventArgs e) 
        {
            ContenidoTextblock();
        }
    }
}
