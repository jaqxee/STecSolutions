using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace STecSolutions.Inventario.UI
{
    public class UtilidadesUI
    {
        private class ItemCombo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public ItemCombo(int id, string nombre)
                {
                    Id = id;
                    Nombre = nombre;
                }
        }
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
                List<ItemCombo> itemVacio = new List<ItemCombo>();
                itemVacio.Add(new ItemCombo(0,"No hay registros")); 
                nombrecmb.DisplayMemberPath = "Nombre";
                nombrecmb.SelectedValuePath = "Id";
                nombrecmb.ItemsSource = itemVacio;
                nombrecmb.SelectedIndex = 0;
                nombrecmb.IsEnabled = false;
            }
        }
    }
}
