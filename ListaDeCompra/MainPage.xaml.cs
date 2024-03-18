using System.Collections.ObjectModel;
using ListaDeCompra.Models;

namespace ListaDeCompra
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();
        private Produto p;

        public MainPage()
        {
            InitializeComponent();
            lst_produtos.ItemsSource = lista_produtos;
        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            double soma = lista_produtos.Sum(i => (i.Preco * i.Quantidade));
            string msg = $"o total é {soma:C}";
            DisplayAlert("Somatoria" ,msg, "Fechar");
        }

        protected override void OnAppearing()
        {
            if (lista_produtos.Count == 0)
            {
                Task.Run(async ()=>
                {
                    List<Produto> tmp = await App.Db.GetAll();
                    foreach (var item in tmp)
                    {
                        lista_produtos.Add(p);
                    }
                });
            }
        }
        
            
        

        private async void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//NovoProduto");
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;
            lista_produtos.Clear();
            Task.Run(async () =>
            {
                List<Produto> tmp = await App.Db.Search(q);
                foreach (Produto p in tmp)
                {
                    lista_produtos.Add(p);
                }
            });
            
        }

        private void ref_carregando_Refreshing(object sender, EventArgs e)
        {
            lista_produtos.Clear();
            Task.Run(async () =>
                        {
               List<Produto> tmp = await App.Db.GetAll();
               foreach (Produto p in tmp)
               {
                 lista_produtos.Add(p);
               }             
            });
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private async void MenuItem_Clicked_Remover(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("tem certeza?", "Remover", "Sim", "Cancelar");

                if (confirm)
                {
                    await App.Db.Delete(1);
                    await DisplayAlert("Sucesso!", "Produto Removido", "OK");
                }
            }catch (Exception ex)
            {
                await DisplayAlert("ops", ex.Message, "OK");
            }
        }
    }
}
