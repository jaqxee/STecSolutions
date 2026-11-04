using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace STecSolutions.Inventario.UI
{
    public class UtilidadesUI
    {
        public static void CargarComboBoxes(ComboBox nombrecmb, IList listaentidades, string campoId, string campoNombre)
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
                nombrecmb.ItemsSource = new List<string> { "No hay registros" };
                nombrecmb.SelectedIndex = 0;
                nombrecmb.IsEnabled = false;
            }
        }
    }
}
