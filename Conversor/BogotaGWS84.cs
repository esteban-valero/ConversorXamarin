using System;

using Xamarin.Forms;

namespace Conversor
{
    public class MyPage : ContentPage
    {
        Label resultado = new Label();
        Entry entryLongitudGrados = new Entry();
        Entry entryLongitudMinutos = new Entry();
        Entry entryLongitudSegundos = new Entry();
        Entry entryLatitudGrados = new Entry();
        Entry entryLatitudMinutos = new Entry();
        Entry entryLatitudSegundos = new Entry();
        Entry entryAltura = new Entry();
        public MyPage()
        {
            Title = "Convertir de Bogota a GWS84";
            var scroll = new ScrollView();

            Button button = new Button
            {
                Text = "Convertir ",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += Button_Clicked;

            var stack = new StackLayout
            {
                Children = {
                    new Label {Text = "Ingrese la latitud", TextColor = Color.FromHex("#094293"), FontSize = 20},
                    new Label { Text = "Grados "},
                    entryLatitudGrados,
                    new Label { Text = "Minutos "},
                    entryLatitudMinutos,
                    new Label { Text = "Segundos "},
                    entryLatitudSegundos,
                    new Label { Text = "Ingrese el la longitud ", TextColor = Color.FromHex("#094293"), FontSize = 20 },
                    new Label { Text = "Grados "},
                    entryLongitudGrados,
                    new Label { Text = "Minutos "},
                    entryLongitudMinutos,
                    new Label { Text = "Segundos "},
                    entryLongitudSegundos,
                    new Label {Text = "Ingrese la altura", TextColor = Color.FromHex("#094293"), FontSize = 20},
                    entryAltura,
                    new Label {Text = "Resultado", TextColor = Color.FromHex("#094293"), FontSize = 20},
                    resultado,
                    button


                }
            };

            scroll.Content = stack;
            Content = scroll;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            resultado.Text = Calcular(Double.Parse(entryLatitudGrados.Text), Double.Parse(entryLatitudMinutos.Text),
                                      Double.Parse(entryLatitudSegundos.Text), Double.Parse(entryLongitudGrados.Text),
                                      Double.Parse(entryLongitudMinutos.Text), Double.Parse(entryLongitudSegundos.Text), 
                                      Double.Parse(entryAltura.Text)
                                     );
        }

        private String Calcular(double la1, double la2, double la3, double lo1, double lo2, double lo3, double h){
            double a = 6378388;
            double b = 6356911.946;
            double f = 0.003367003;
            double e2 = 0.00672267;
            double e22 = 0.00676817;
            double l1 = la1 + (la2 / 60 + (la3 / 3600));
            double l2 = lo1 + (lo2 / 60 + (lo3 / 3600));
            double l1r = l1 * Math.PI / 180.0;
            double  l2r = l2 * Math.PI / 180.0;
            double cl1 = Math.Cos(l1r);
            double sl1 = Math.Sin(l1r);
            double cl2 = Math.Cos(l2r);
            double sl2 = Math.Sin(l2r);
            double rn = a / Math.Sqrt(1 - e2 * sl1 * sl1);
            double rnh = rn + h;
            double x = rnh * (cl1 * cl2);
            double y = rnh * (cl1 * sl2);
            double z = ((1 - e2) * rnh) * sl1;
            double Dx = 307;
            double Dy = 304;
            double Dz = -318;
            double xB = x + Dx;
            double yB = y - Dy;
            double zB = z + Dz;
            double p = Math.Sqrt((xB * xB) + (yB * yB));
            double v = (Math.Atan((zB * a) / (b * p)));
            double sv = (Math.Sin(v));
            double cv = (Math.Cos(v));
            double laB = Math.Atan((zB + e22 * b * (sv * sv * sv)) / (p - e2 * a * (cv * cv * cv)));
            double laB1 = laB * 180.0 / Math.PI;
            double loB = Math.Atan(yB / xB);
            double loB1 = loB * 180.0 / Math.PI;
            double hB = ((p / Math.Cos(l1r)) - rn);
            int lag = (int)laB1;
            double lam = (laB1 - lag) * 60;
            int lam2 = (int)lam;
            double las = (lam - lam2) * 60;
            int log = (int)loB1;
            double lom = (loB1 - log) * 60;
            int lom2 = (int)lom;
            double los = (lom - lom2) * 60;
            return "\n\t\t\t\tLos grados de la Latitud son: " + lag + "\n\t\t\t\tLos minutos de la Latitud son: " + lam2 +
                "\n\t\t\t\tLos segundos de la Latitud son: " + las + "\n\t\t\t\tLos grados de la Longitud son: " + log +
                "\n\t\t\t\tLos minutos de la Longitud son: " + lom2 + "\n\t\t\t\tLos segundos de la Longitud son: " + los +
                "\n\t\t\t\tLa altura es: " + hB;
        }


    }
}

