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
                UtilidadesUI.CargarComboBoxes(cmbUbicacion, new UbicacionBLL().MostrarDatos(), "IdUbicacion", "Sede");
                UtilidadesUI.CargarComboBoxes(cmbEstado, new EstadoOperativoBLL().MostrarDatos(), "IdEstadoOperativo", "Nombre");
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
                cmbTipo.SelectedValue = nuevaVentanaTipo.Id;
            }
            
        }


        private void btnNuevoModelo_Click(object sender, RoutedEventArgs e) 
        {
            VentanaModelo nuevaVentanaModelo = new VentanaModelo();
            if (nuevaVentanaModelo.ShowDialog() == true) 
            {
                UtilidadesUI.CargarComboBoxes(cmbModelo, new ModeloBLL().MostrarDatos(), "IdModelo", "NombreModelo"); 
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

        private void btnNuevaUbicacion_Click(object sender, RoutedEventArgs e) 
        {
            VentanaAgregarUbicacion ventanaUbicacion = new VentanaAgregarUbicacion();
            if (ventanaUbicacion.ShowDialog() == true)
            {
                UtilidadesUI.CargarComboBoxes(cmbUbicacion, new UbicacionBLL().MostrarDatos(), "IdUbicacion", "Sede");
                cmbUbicacion.SelectedValue = ventanaUbicacion.Id;
            }
        } 

        private void btnNuevoEstado_Click(object sender, RoutedEventArgs e) 
        {
            VentanaEstadoOperativo ventanaEstadoOperativo = new VentanaEstadoOperativo();
            if (ventanaEstadoOperativo.ShowDialog() == true) 
            {
                UtilidadesUI.CargarComboBoxes(cmbEstado, new EstadoOperativoBLL().MostrarDatos(), "IdEstadoOperativo", "Nombre");
                cmbEstado.SelectedValue = ventanaEstadoOperativo.Id;
            }
        }

        private int ObtenerIdCombo(ComboBox combo) 
        {
            return combo.SelectedValue is int id ? id: 0;
        }

        private void clickRegistrar(object sender, RoutedEventArgs e)
        {
            InventarioTecnologico inventario = new InventarioTecnologico();
            inventario.CodigoInventario = txtCodInventario.Text.Trim();
            inventario.IdTipoEquipo = ObtenerIdCombo(cmbTipo);
            inventario.IdModelo = ObtenerIdCombo(cmbModelo);
            inventario.IdProcesador = ObtenerIdCombo(cmbProcesador);
            inventario.MemoriaRam = txtMemoriaRam.Text.Trim();
            inventario.CapacidadAlmacenamiento = txtAlmacenamiento.Text.Trim();
            inventario.IdSistemaOperativo = ObtenerIdCombo(cmbSistemaOperativo);
            inventario.IdUsuarioResponsable = ObtenerIdCombo(cmbUsuario);
            inventario.IdUbicacion = ObtenerIdCombo(cmbUbicacion);
            inventario.IdEstadoOperativo = ObtenerIdCombo(cmbEstado);
            try
            {
                new InventarioTecnologicoBLL().InsertarActivoTecnologico(inventario);
                MessageBox.Show("El activo ha sido guardado con éxito","Registrado Exitosamente",MessageBoxButton.OK,MessageBoxImage.Information);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message,"Campo Obligatorio",MessageBoxButton.OK, MessageBoxImage.Warning); }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message,"Error de Sistema",MessageBoxButton.OK,MessageBoxImage.Error); }
        }

    }
}