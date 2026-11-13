using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Patrones_Comportamiento.TemplateMethod.AbstractClass;
using Patrones_Comportamiento.TemplateMethod.ConcreteClasses;

namespace Patrones_Comportamiento.TemplateMethod
{
    public partial class VistaTemplateMethod : UserControl
    {
        public VistaTemplateMethod()
        {
            InitializeComponent();
            EjecutarPreparacion();
        }

        private void BtnPreparar_Click(object sender, RoutedEventArgs e)
        {
            EjecutarPreparacion();
        }

        private void EjecutarPreparacion()
        {
            PreparadorBebida preparador;

            switch (CmbBebidas.SelectedIndex)
            {
                case 0:
                    preparador = new CafeteraExpreso();
                    break;
                case 1:
                    preparador = new TeteraVerde();
                    break;
                case 2:
                    preparador = new PreparadorChocolate();
                    break;
                default:
                    preparador = new CafeteraExpreso();
                    break;
            }

            bool conEndulzante = ChkEndulzante.IsChecked == true;

            // Invocación del Template Method
            List<PasoReceta> pasos = preparador.PrepararReceta(conEndulzante);

            ListaPasos.ItemsSource = pasos;

            TxtResumen.Text = $"Se preparó con éxito '{preparador.NombreBebida}'. Todos los tipos de bebidas comparten el esqueleto del algoritmo (Hervir agua y Servir en taza), pero cada una personalizó su elaboración y acompañamiento.";
        }
    }
}
