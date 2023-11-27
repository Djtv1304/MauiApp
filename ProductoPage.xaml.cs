using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using MauiApp1.Models;

namespace MauiApp1;

public partial class ProductoPage : ContentPage
{

    public ProductoPage()
    {
        InitializeComponent();
        //listaProductos.ItemsSource = Utils.Utils.ListaProductos;
        OnAppearing();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        // Llamo a la API cada vez que la Producto Page cargue o se muestre
        List<Producto> ListaProductos = await Utils.Utils._APIService.GetProducto();
        var productos = new ObservableCollection<Producto>(ListaProductos);
        listaProductos.ItemsSource = productos;
    }

    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProducto());
    }

    private async void onClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Producto producto)
        {
            await Navigation.PushAsync(new DetailsProducto(producto));
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        // Sender contiene el objeto que disparó el evento, en este caso un botón
        var button = sender as ImageButton;
        // Se accede al BindingContext que enlaza datos a los controles, en este caso el control es el botón
        var productoParaEliminar = button?.BindingContext as Producto;

        if (productoParaEliminar != null)
        {

            // Confirmar con el usuario si realmente desea eliminar el producto
            var confirm = await this.DisplayAlert("Confirmarción", "¿Estás seguro de que quieres eliminar este producto?", "Sí", "No");

            if (confirm)
            {

                // Eliminar el producto
                await Utils.Utils._APIService.DeleteProducto(productoParaEliminar.IdProducto);
                // Refresco la pantalla
                OnAppearing();

            }

        }
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {

        // Sender contiene el objeto que disparó el evento, en este caso un botón
        var button = sender as ImageButton;
        // Se accede al BindingContext que enlaza datos a los controles, en este caso el control es el botón
        var productoParaEditar = button?.BindingContext as Producto;

        if (productoParaEditar != null)
        {

            await Navigation.PushAsync(new EditProducto(productoParaEditar));

        }

    }
}