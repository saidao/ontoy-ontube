using System;
using Xamarin.Forms;

namespace OnToyOnTube.Views
{
    public class UbicacionCell : ViewCell
    {
        public UbicacionCell()
        {
            // IdUbicacion, FechaRegistro, IdPersona, Tipo, Dispositivo, Latitud, Longitud, Altitud); }

            var IdUbicacionLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };

            IdUbicacionLabel.SetBinding(Label.TextProperty, new Binding("IdUbicacion"));

            var TipoLabel = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            TipoLabel.SetBinding(Label.TextProperty, new Binding("Tipo"));

            var FechaRegistroLabel = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            //FechaRegistroLabel.SetBinding(Label.TextProperty, new Binding(path: "FechaRegistro", stringFormat: "{0:dd/MM/yyyy}"));
            FechaRegistroLabel.SetBinding(Label.TextProperty, new Binding(path: "FechaRegistro", stringFormat: "{0:HH:mm:ss}"));

            var LatitudLabel = new Label
            {
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            LatitudLabel.SetBinding(Label.TextProperty, new Binding(path: "Latitud", stringFormat: "{0:0.0000}"));

            var LongitudLabel = new Label
            {
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            LongitudLabel.SetBinding(Label.TextProperty, new Binding(path: "Longitud", stringFormat: "{0:0.0000}"));

            var AltitudLabel = new Label
            {
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            AltitudLabel.SetBinding(Label.TextProperty, new Binding(path: "Altitud", stringFormat: "{0:0.0000}"));


            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { IdUbicacionLabel, FechaRegistroLabel, TipoLabel },
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { LatitudLabel, LongitudLabel, AltitudLabel },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { line1, line2, },
            };
        }
    }
}
