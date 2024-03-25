using ListaDeCompra.Models;

namespace ListaDeCompra.Views;

public partial class NovoProduto2 : ContentPage
{
	public NovoProduto2()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_Descricao.Text,
                Quantidade = Convert.ToDouble(txt_Quantidade.Text),
                Preco = Convert.ToDouble(txt_Preco.Text),
            };

            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!", "Produto inserido", "OK");
            await Navigation.PushAsync(new MainPage());

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}