using FormulaCuadraticaMvvm.Views;

namespace FormulaCuadraticaMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new FormulaCuadraticaMainPage());
        }
    }
}
