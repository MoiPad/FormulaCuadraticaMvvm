
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FormulaCuadraticaMvvm.Models;
using FormulaCuadraticaMvvm.Views;
namespace FormulaCuadraticaMvvm.ViewModels
{
    public partial class MainPageViewModels : ObservableObject
    {
        [ObservableProperty]
        private double a;

        [ObservableProperty]
        private double b;

        [ObservableProperty]
        private double c;

        [ObservableProperty]
        private double x1;

        [ObservableProperty]
        private double x2;



        [RelayCommand]
        private void CalcularFC()
        {
            try
            {
                if (Validar())
                {
                
                FormulaCuadratica FC = new FormulaCuadratica();

                FC.A = a;
                FC.B = b;
                FC.C = c;
                FC.X1 = x1;
                FC.X2 = x2;

                double CalculoRaiz = (Math.Sqrt((Math.Pow(B, 2))) - (4 * A * C));
                if (CalculoRaiz < 0)
                {
                    Alerta("Atención", "Se obtuvo una respuesta negativa, no hay soluciones reales para la ecuación cuadrática.");
                    Limpiar();

                }
                    double Division = (2 * A);
                X1 = (-B + CalculoRaiz) / Division;
                X2 = (-B - CalculoRaiz) / Division;

                }
            }
            catch (Exception ex)
            {
                Alerta("Advertencia!", $"Se obtuvo el error: {ex.Message}");
        }
    }
      
        /// <summary>
        ///  Metodo booleano para calcular formula cuadratica
        /// </summary>
        /// <returns>
        /// Si A es igual a 0 devuelve la advertencia y se retorna falso, porque no se puede dividir entre 0
        /// En caso de pasar las primeras dos validaciones, realiza la operación y retornara verdadero.
        /// </returns>
        private bool Validar()
        {
            if (A == 0)
            {
                Alerta("Advertencia!", "La ecuación no es cuadratica dado que es igual que cero");
                return false;
            }
       
            else
            {
                return true;
            }
        }
    

        [RelayCommand]
        private async void MostrarAlerta()
        {
            try
            {
                if (A == 0 && B == 0 || C == 0)
                {
                    Alerta("Atención", "las casillas estan vacias");
                    return;
                }
                else
                {
                    string res = await App.Current!.MainPage!.DisplayActionSheet("Atención!", "Cancelar", null, "SI", "NO");

                    if (res == "SI")
                    {
                        if (Validar())
                        {
                            Limpiar();
                            Alerta("Listo", "Casillas en blanco");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta("Atención", $"Se obtuvo una excepción, Error:{ex.Message}");
            }
        }

        private void Limpiar()
        {
            A = 0;
            B = 0;
            C = 0;
            X1 = 0;
            X2 = 0;
        }

        /// <summary>
        /// Metodo alerta
        /// </summary>
        /// <param name="Mensaje">Descripción del error</param>
        /// <param name="Tipo">Titulo del mensaje</param>
        public void Alerta(String Tipo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }

    }
}
