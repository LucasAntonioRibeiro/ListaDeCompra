using ListaDeCompra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ListaDeCompra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoProduto : ContentPage
    {
        private object txt_descricao;
        private object txt_preco;

        public NovoProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToString(txt_preco.Text),
                };

            } catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

       
    }
}