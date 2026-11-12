using System.Windows;
using System.Windows.Controls;

namespace Patrones_Comportamiento
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContenedorContenido.Content = new TextBlock
            {
                Text = "Selecciona uno de los nueve patrones del menú para comenzar.",
                FontSize = 18,
                Margin = new Thickness(15),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
        }

        private void BtnChainOfResponsibility_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new ChainOfResponsibility.VistaChainOfResponsibility();
        }

        private void BtnCommand_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Command.VistaCommand();
        }

        private void BtnIterator_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Iterator.VistaIterator();
        }

        private void BtnMediator_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Mediator.VistaMediator();
        }

        private void BtnMemento_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Memento.VistaMemento();
        }

        private void BtnObserver_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Observer.VistaObserver();
        }

        private void BtnState_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new State.VistaState();
        }

        private void BtnStrategy_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new Strategy.VistaStrategy();
        }

        private void BtnTemplateMethod_Click(object sender, RoutedEventArgs e)
        {
            ContenedorContenido.Content = new TemplateMethod.VistaTemplateMethod();
        }
    }
}
