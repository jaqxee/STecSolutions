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
        private int _idEquipoAActualizar;
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
                CargarComboBoxes(cmbTipo, new TipoEquipoBLL().MostrarDatos(), "IdTipoEquipo", "Nombre");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message, "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarComboBoxes(ComboBox nombrecmb, IList listaentidades, string campoId, string campoNombre)
        {
            if (listaentidades != null && listaentidades.Count > 0)
            {
                nombrecmb.DisplayMemberPath = campoNombre;
                nombrecmb.SelectedValuePath = campoId;
                nombrecmb.ItemsSource = listaentidades;
                nombrecmb.IsEnabled = true;
                nombrecmb.SelectedIndex = -1;
            }
            else
            {
                nombrecmb.DisplayMemberPath = null;
                nombrecmb.SelectedValuePath = null;
                nombrecmb.ItemsSource = new List<string> {"No hay registros"};
                nombrecmb.SelectedIndex = 0;
                nombrecmb.IsEnabled = false;
            }
        }

        private void btnNuevoTipo_Click(object sender, RoutedEventArgs e)
        {
            VentanaTipoEquipo nuevaVentanaTipo = new VentanaTipoEquipo();
            if (nuevaVentanaTipo.ShowDialog() == true) 
            {
                CargarComboBoxes(cmbTipo, new TipoEquipoBLL().MostrarDatos(), "IdTipoEquipo", "Nombre");
                cmbTipo.SelectedValue = nuevaVentanaTipo.IdTipoEquipo;
            }
            
        }


        private void btnNuevoModelo_Click(object sender, RoutedEventArgs e) 
        {
            VentanaModelo nuevaVentanaModelo = new VentanaModelo();
            if (nuevaVentanaModelo.ShowDialog() == true) 
            {
                CargarComboBoxes(cmbModelo, new ModeloBLL().MostrarDatos(), "IdModelo", "NombreModelo"); /// QUEDE AQUIIIII PORQUE HAY QUE HACER EL METODO DE CARGAR LISTAS DE MODELO!!!!!!!!!!!
                cmbModelo.SelectedValue = nuevaVentanaModelo.Id;
            }
        }

        private void btnNuevoProcesador_Click(object sender, RoutedEventArgs e) { }

        private void btnNuevoSistemaOperativo_Click(object sender, RoutedEventArgs e) { }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e) { }

        private void btnNuevaUbicacion_Click(object sender, RoutedEventArgs e) { }

        private void btnNuevoEstado_Click(object sender, RoutedEventArgs e) { }


    }
}