

namespace FormulaCuadraticaMvvm.Models
{
    public class FormulaCuadratica
    {
        public double A { get; set; }
        public double B { get; set; }

        public double C { get; set; }

        public double X1 { get; set; }
        public double X2 { get; set; }



       /// <summary>
       ///  Metodo booleano para calcular formula cuadratica
       /// </summary>
       /// <returns>
       /// Si A es igual a 0 devuelve la advertencia y se retorna falso, porque no se puede dividir entre 0
       /// Si CalculoRaiz es menor que 0(Negativo) no se encuentra solución a los reales por tanto retornara falso
       /// En caso de pasar las primeras dos validaciones, realiza la operación y retornara verdadero.
       /// </returns>
       
        public bool CalcularFC() 
        {
            if (A == 0)
            {
                Alerta("Advertencia!", "La ecuación no es cuadratica dado que es igual que cero");
                return false;
            }

            double CalculoRaiz =  (Math.Sqrt((Math.Pow(B, 2))) - (4 * A * C));

            if(CalculoRaiz < 0)
            {
                Alerta("Advertencia!","Al realizar el calculo en la raíz el resultado fue negativo por tanto no hay solución en los reales");
                return false;
            }

            double Division = (2 * A);
            X1 = (-B + CalculoRaiz) / Division;
            X2 = (-B - CalculoRaiz) / Division; 

            return true;
        }


        /// <summary>
        /// Metodo alerta
        /// </summary>
        /// <param name="Mensaje">Descripción del error</param>
        /// <param name="Tipo">Titulo del mensaje</param>
        public void Alerta(String Mensaje, String Tipo)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }
}
