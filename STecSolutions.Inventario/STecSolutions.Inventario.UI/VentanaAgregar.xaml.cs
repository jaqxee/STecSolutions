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
using STecSolutions.Inventario.BLL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;
using System.Collections;

namespace STecSolutions.Inventario.UI
{
    public partial class VentanaAgregar : Window
    {
        private int _modoAActualizar;
        public VentanaAgregar()
        {
            InitializeComponent();
        }


        private void LimpiarFormulario()
        {
 
            cmbTipo.SelectedIndex = -1;
            cmbUsuario.SelectedIndex = -1;
            cmbUbicacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbTipo.Focus();
        }

        private void CargaSegura(object sender, RoutedEventArgs e)
        {
            try
            {
                UtilidadesUI.CargarComboBoxes(cmbTipo, new TipoEquipoBLL().MostrarDatos(), "IdTipoEquipo", "Nombre");
                UtilidadesUI.CargarComboBoxes(cmbModelo, new ModeloBLL().MostrarDatos(), "IdModelo", "NombreModelo");
                UtilidadesUI.CargarComboBoxes(cmbProcesador, new ProcesadorBLL().MostrarDatos(), "IdProcesador", "Marca");
                UtilidadesUI.CargarComboBoxes(cmbSistemaOperativo, new SistemaOperativoBLL().MostrarDatos(),"IdSistemaOperativo", "Nombre");
                UtilidadesUI.CargarComboBoxes(cmbUsuario, new UsuarioBLL().MostrarDatos(), "IdUsuario", "NombreCompleto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message, "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNuevoTipo_Click(object sender, RoutedEventArgs e)
        {
            VentanaTipoEquipo nuevaVentanaTipo = new VentanaTipoEquipo();
            if (nuevaVentanaTipo.ShowDialog() == true) 
            {
                UtilidadesUI.CargarComboBoxes(cmbTipo, new TipoEquipoBLL().MostrarDatos(), "IdTipoEquipo", "Nombre");
                cmbTipo.SelectedValue = nuevaVentanaTipo.IdTipoEquipo;
            }
            
        }


        private void btnNuevoModelo_Click(object sender, RoutedEventArgs e) 
        {
            VentanaModelo nuevaVentanaModelo = new VentanaModelo();
            if (nuevaVentanaModelo.ShowDialog() == true) 
            {
                UtilidadesUI.CargarComboBoxes(cmbModelo, new ModeloBLL().MostrarDatos(), "IdModelo", "NombreModelo"); /// QUEDE AQUIIIII PORQUE HAY QUE HACER EL METODO DE CARGAR LISTAS DE MODELO!!!!!!!!!!!
                cmbModelo.SelectedValue = nuevaVentanaModelo.Id;
            }
        }

        private void btnNuevoProcesador_Click(object sender, RoutedEventArgs e)
        {
            VentanaProcesador ventanaProcesador = new VentanaProcesador();
            if (ventanaProcesador.ShowDialog() == true) 
            {
                UtilidadesUI.CargarComboBoxes(cmbProcesador, new ProcesadorBLL().MostrarDatos(), "IdProcesador", "Marca");
                cmbProcesador.SelectedValue = ventanaProcesador.Id;
            }
        }

        private void btnNuevoSistemaOperativo_Click(object sender, RoutedEventArgs e) 
        {
            VentanaSistemaOperativo ventanaSistemaOperativo = new VentanaSistemaOperativo();
            if(ventanaSistemaOperativo.ShowDialog() == true)
            {
                UtilidadesUI.CargarComboBoxes(cmbSistemaOperativo, new SistemaOperativoBLL().MostrarDatos(), "IdSistemaOperativo", "Nombre");
                cmbSistemaOperativo.SelectedValue = ventanaSistemaOperativo.Id;
            }
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e) 
        {
            VentanaAgregarUsuario ventanaUsuario = new VentanaAgregarUsuario();
            if (ventanaUsuario.ShowDialog() == true)
            {
                UtilidadesUI.CargarComboBoxes(cmbUsuario, new UsuarioBLL().MostrarDatos(), "IdUsuario", "NombreCompleto");
                cmbUsuario.SelectedValue = ventanaUsuario.Id;
            }
        }

        private void btnNuevaUbicacion_Click(object sender, RoutedEventArgs e) { }

        private void btnNuevoEstado_Click(object sender, RoutedEventArgs e) { }


    }
}