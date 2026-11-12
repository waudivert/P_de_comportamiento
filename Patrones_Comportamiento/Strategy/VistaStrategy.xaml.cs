
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

using Patrones_Comportamiento.Strategy.StrategyInterface;
using Patrones_Comportamiento.Strategy.ConcreteStrategies;
using Patrones_Comportamiento.Strategy.Context;

namespace Patrones_Comportamiento.Strategy
{
    public partial class VistaStrategy : UserControl
    {
        private readonly CalculadoraPrecios calculadora;

        public VistaStrategy()
        {
            InitializeComponent();

            // Estrategia inicial
            calculadora = new CalculadoraPrecios(
                new SinDescuento());

            CmbDescuentos.SelectedIndex = 0;
        }

        private void BtnCalcular_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Validar el precio
            bool valido = decimal.TryParse(
                TxtPrecio.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal precio);

            if (!valido || precio < 0)
            {
                MessageBox.Show(
                    "Ingresa un precio válido.",
                    "Strategy");

                return;
            }

            // Seleccionar la estrategia
            IEstrategiaDescuento estrategia;
            string nombreEstrategia;

            switch (CmbDescuentos.SelectedIndex)
            {
                case 0:
                    estrategia = new SinDescuento();
                    nombreEstrategia = "Sin descuento";
                    break;

                case 1:
                    estrategia = new Descuento10();
                    nombreEstrategia = "Descuento del 10%";
                    break;

                case 2:
                    estrategia = new Descuento20();
                    nombreEstrategia = "Descuento del 20%";
                    break;

                default:
                    MessageBox.Show(
                        "Selecciona un descuento.",
                        "Strategy");
                    return;
            }

            // Cambiar la estrategia
            calculadora.CambiarEstrategia(estrategia);

            // Ejecutar el algoritmo seleccionado
            decimal resultado = calculadora.Calcular(precio);

            // Mostrar resultado
            TxtResultado.Text =
                $"Bs {resultado:0.00}";

            TxtMensaje.Text =
                "Estrategia aplicada: " + nombreEstrategia;
        }
    }
}
