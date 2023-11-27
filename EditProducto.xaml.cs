using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiApp1.Models;
using System;

namespace MauiApp1;

public partial class EditProducto : ContentPage
{
	public EditProducto(Producto productoParaEditar)
	{
		InitializeComponent();
		BindingContext = productoParaEditar;
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        Producto productoParaReemplazar = BindingContext as Producto;

        Producto productoNuevo = new Producto
        {

            IdProducto = productoParaReemplazar.IdProducto,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            Cantidad = Int32.Parse(Cantidad.Text)

        };

        if (productoParaReemplazar != null)
        {

            var toastError = Toast.Make("Hubo un error al editar el producto!", ToastDuration.Short, 14);

            await toastError.Show();

        }

        // Invoco a la API para reemplazar el producto
        await Utils.Utils._APIService.UpdateProducto(productoNuevo, productoParaReemplazar.IdProducto);

        /* 
            Se remueve el producto antiguo de la lista
            Utils.Utils.ListaProductos.RemoveAt(indexParaReemplazar);

            // Agrego el nuevo producto en la posicion en la que eliminé el anterior
            Utils.Utils.ListaProductos.Insert(indexParaReemplazar, productoNuevo);
        */

        var toastConfirmacion = Toast.Make("El producto se editó correctamente!", ToastDuration.Short, 14);

        await toastConfirmacion.Show();

        await Navigation.PopAsync();

    }
}