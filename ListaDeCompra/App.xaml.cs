using ListaDeCompra.Helpers;

namespace ListaDeCompra
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                           ), "banco_sqlite_compras.db3"
                          );

                    _db = new SQLiteDatabaseHelper( path );


                }// Fecha if verificando se _db é null
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
