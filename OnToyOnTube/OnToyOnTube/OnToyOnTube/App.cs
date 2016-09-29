using Xamarin.Forms;

namespace OnToyOnTube
{
    public class App : Application
    {
        public App()
        {
            /**Inicialización de variables*/
            using (var datos = new Controllers.DataAccess())
            {
                var listitemsSource = datos.GetFirst<Models.Configuracion>();
                //if (string.IsNullOrEmpty(listitemsSource.IdConfiguracion.ToString()))
                if (listitemsSource == null)
                {
                    var Configuracion = new Models.Configuracion();
                    Configuracion = new Models.Configuracion
                    {
                        IdConfiguracion = 1,
                        FechaRegistro = System.DateTime.Now,
                        FechaModificacion = System.DateTime.Now,
                        CheckInorCheckout = "CheckOut"
                    };
                    datos.Insert<Models.Configuracion>(Configuracion);
                }
            }

            //Direccion
            MainPage = new Views.listaUbicaciones();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
