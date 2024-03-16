using FormulaCuadraticaMvvm.ViewModels;
using System.Windows.Input;
namespace FormulaCuadraticaMvvm.Views;


public partial class FormulaCuadraticaMainPage : ContentPage
{
    private MainPageViewModels _viewModel;
    public ICommand ToolbarItem_Clicked { get; }

    public FormulaCuadraticaMainPage()
    {
        InitializeComponent();
        _viewModel = new MainPageViewModels();
        BindingContext = _viewModel;


        ToolbarItem_Clicked = new Command(async () => await ToolbarItemClicked(null, EventArgs.Empty));
        ToolbarItems.Add(new ToolbarItem
        {
            IconImageSource = new FontImageSource
            {
                FontFamily = "FaRegular",
                Glyph = Models.FaRegularIcons.CircleLeft,
                Size = 30
            },
            Command = ToolbarItem_Clicked
        });
    }
    /// <summary>
    /// Tarea asincrona para validar la salida del program
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <returns>Retorna un mensaje en pantalla</returns>
    private async Task ToolbarItemClicked(object sender, EventArgs e)
    {
       string salir = await App.Current!.MainPage!.DisplayActionSheet("Esta seguro de salir de la app?", "Cancelar", null, "SI");
        if (salir == "SI") 
        {
            Environment.Exit(0);
        }
    }
}


