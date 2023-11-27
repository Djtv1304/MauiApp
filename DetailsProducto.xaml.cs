using MauiApp1.Models;

namespace MauiApp1;

public partial class DetailsProducto : ContentPage
{
	public DetailsProducto(Producto producto)
	{
		InitializeComponent();
        BindingContext = producto;
    }
}