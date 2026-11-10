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
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario
{
    /// <summary>
    /// Lógica de interacción para VentanaAgregarUsuario.xaml
    /// </summary>
    public partial class VentanaAgregarUsuario : Window
    {
        public int Id { get; private set; }

        public VentanaAgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario responsable = new Usuario();
            responsable.NombreCompleto = txtNombre.Text;
            responsable.Email = txtEmail.Text;
            responsable.Departamento = txtDepartamento.Text;
            try
            {
                Id = new UsuarioBLL().InsertarDatos(responsable);
                this.DialogResult = true;
            }
            catch (NegocioException ex) { MessageBox.Show(ex.Message,"Campo Obligaorio",MessageBoxButton.OK,MessageBoxImage.Warning); }
            catch (Exception ex) { MessageBox.Show("Error al conectar con la Base de datos: " + ex.Message,"Error del Sistema",MessageBoxButton.OK,MessageBoxImage.Error); }
        }
    }
}
