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

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaEliminar.xaml
    /// </summary>
    public partial class VentanaEliminar : Window
    {
        public VentanaEliminar()
        {
            InitializeComponent();
            //ContenidoEtiqueta();
        }

        private void btnConfirmarEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelarEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        ///private void ContenidoEtiqueta() 
        ///{
        ///    VentanaInicio ventanaPrincipal = (VentanaInicio)Application.Current.MainWindow;
        //   string serieRecibida = ventanaPrincipal.nroSerieEliminar;
        //   mensajeEliminar.Text = $"""Está eliminando el equipo con numero de serie: {serieRecibida}""";
        //}


    }
}
