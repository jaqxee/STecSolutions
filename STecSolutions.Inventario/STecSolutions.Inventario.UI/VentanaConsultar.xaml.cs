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
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.BLL;
using STecSolutions.Inventario.Entities.DTO;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.UI
{
    /// <summary>
    /// Lógica de interacción para VentanaConsultar.xaml
    /// </summary>
    public partial class VentanaConsultar : Window
    {
        private readonly string _idConsultado;
        public VentanaConsultar(string idConsultado)
        {
            InitializeComponent();
            _idConsultado = idConsultado;
        }

        private void CargaSegura(object sender, RoutedEventArgs e) 
        {
                CargarVentana(); 
        }

        public void CargarVentana()
        {
            try
            {
                InventarioConsultaDTO inventario = new InventarioTecnologicoBLL().MostrarDatos(_idConsultado);
                txbCodigo.Text = inventario.CodigoInventario;
                txbTipo.Text = inventario.TipoEquipo;
                txbMarca.Text = inventario.Marca;
                txbModelo.Text = inventario.Modelo;
                txbProcesador.Text = inventario.Procesador;
                txbMemoriaRam.Text = inventario.MemoriaRam;
                txbAlmacenamiento.Text = inventario.CapacidadAlmacenamiento;
                txbSistemaOperativo.Text = inventario.SistemaOperativo;
                txbUsuario.Text = inventario.UsuarioResponsable;
                txbUbicacion.Text = inventario.Ubicacion;
                txbEstado.Text = inventario.EstadoOperativo;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message, "Registro expirado", MessageBoxButton.OK, MessageBoxImage.Warning); this.Close(); }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de Datos: " + ex.Message,"Error de Sistema",MessageBoxButton.OK,MessageBoxImage.Error); this.Close(); }
        }

        private void btnCerrarConsultar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
