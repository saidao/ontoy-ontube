using Plugin.Geolocator;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnToyOnTube.Views
{
    public partial class listaUbicaciones : ContentPage
    {
        public listaUbicaciones()
        {
            InitializeComponent();
            Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),
                new Thickness(10, 10, 10, 10),
                new Thickness(10, 10, 10, 10));
            using (var datos = new Controllers.DataAccess())
            {
                var listitemsSource = datos.GetFirst<Models.Configuracion>();
                if (listitemsSource.CheckInorCheckout== "CheckIn")
                {
                    checkinoutSwitch.IsToggled = true;
                }
            }
            ubicaionesListView.ItemTemplate = new DataTemplate(typeof(UbicacionCell));
            ubicaionesListView.RowHeight = 70;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datos = new Controllers.DataAccess())
            {
                ubicaionesListView.ItemsSource = datos.GetList<Models.Ubicacion>();
            }

        }
        private async void checkinoutSwitch_Clicked(object sender, EventArgs e)
        {
            var swtchChecInoChecOut = "Automatic";
            if (checkinoutSwitch.IsToggled)
                swtchChecInoChecOut = "CheckIn";
            else
                swtchChecInoChecOut = "CheckOut";

            using (var datos = new Controllers.DataAccess())
            {
                var listitemsSource = datos.GetFirst<Models.Configuracion>();
                var Configuracion = new Models.Configuracion();
                Configuracion = new Models.Configuracion
                {
                    IdConfiguracion = listitemsSource.IdConfiguracion,
                    FechaRegistro = listitemsSource.FechaRegistro,
                    FechaModificacion = System.DateTime.Now,
                    CheckInorCheckout = swtchChecInoChecOut
                };
                datos.Update<Models.Configuracion>(Configuracion);
            }

            registraUbicacion(swtchChecInoChecOut);
            return;
        }

        //public async void registraUbicacion(String strTipo)
        private async void registraUbicacion(String strTipo)
        {
            var strUbicacion = "";
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            if (position == null)
            {
                strUbicacion = "Habilite su GPS :(";
            }
            else
            {
                strUbicacion = string.Format("Time: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}",
                                            position.Timestamp,
                                            position.Latitude,
                                            position.Longitude,
                                            position.Altitude,
                                            position.AltitudeAccuracy,
                                            position.Accuracy,
                                            position.Heading,
                                            position.Speed);

                var Ubicacion = new Models.Ubicacion
                {
                    FechaRegistro = System.DateTime.Now,
                    IdPersona = 1,
                    Tipo = strTipo,
                    Dispositivo = "",
                    Latitud = position.Latitude,
                    Longitud = position.Longitude,
                    Altitud = position.Altitude,
                    PrecisionAltitud = position.AltitudeAccuracy,
                    Exactitud = position.Accuracy,
                    Titulo = position.Heading,
                    Velocidad = position.Speed
                };

                using (var datos = new Controllers.DataAccess())
                {
                    datos.Insert<Models.Ubicacion>(Ubicacion);
                    ubicaionesListView.ItemsSource = datos.GetList<Models.Ubicacion>();
                    var listitemsSource = datos.GetFirst<Models.Configuracion>();
                    if (listitemsSource.CheckInorCheckout == "CheckIn")
                    {
                        var segundo = (1000) * 5;
                        var minuto = (segundo * 60) * 0;
                        var hora = (minuto * 60) *0;
                        var dia = (hora * 24) * 0;
                        var tPeriodo = dia + hora + minuto + segundo;
                        await Task.Delay(tPeriodo);
                        registraUbicacion("Automatic");
                    }
                }
            }
        }
    }
}
