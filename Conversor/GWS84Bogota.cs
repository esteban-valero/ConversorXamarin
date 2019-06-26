using System;

using Xamarin.Forms;

namespace Conversor
{
    public class MyPage2 : ContentPage
    {
        Label resultado = new Label();
        Entry entryLongitudGrados = new Entry();
        Entry entryLongitudMinutos = new Entry();
        Entry entryLongitudSegundos = new Entry();
        Entry entryLatitudGrados = new Entry();
        Entry entryLatitudMinutos = new Entry();
        Entry entryLatitudSegundos = new Entry();
        Entry entryAltura = new Entry();
        public MyPage2()
        {
            Title = Title = "Convertir de GWS84 a  Bogota";
            ScrollView scroll = new ScrollView();

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
                    new Label {Text = "Ingrese la latitud", TextColor = Color.FromHex("#0000ff"), FontSize = 20},
                    new Label { Text = "Grados "},
                    entryLatitudGrados,
                    new Label { Text = "Minutos "},
                    entryLatitudMinutos,
                    new Label { Text = "Segundos "},
                    entryLatitudSegundos,
                    new Label { Text = "Ingrese el la longitud ", TextColor = Color.FromHex("#0000ff"), FontSize = 20 },
                    new Label { Text = "Grados "},
                    entryLongitudGrados,
                    new Label { Text = "Minutos "},
                    entryLongitudMinutos,
                    new Label { Text = "Segundos "},
                    entryLongitudSegundos,
                    new Label {Text = "Ingrese la altura", TextColor = Color.FromHex("#0000ff"), FontSize = 20},
                    entryAltura,
                    new Label {Text = "Resultado", TextColor = Color.FromHex("#0000ff"), FontSize = 20},
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


        private String Calcular(double la1, double la2, double la3, double lo1, double lo2, double lo3, double h)
        {
            double a, b, f, e2, e22, l1, l2, l1r, l2r, cl1, sl1, cl2, sl2, rn, rnh, x, y, z, Dx, Dy, Dz, xB, yB, zB, p, v, sv, cv, laB, laB1, loB, loB1, hB, lag, lam, lam2, las, log, lom, lom2, los;
            a = 6378137;
            b = 6356752.298;
            f = 0.003352813;
            e2 = 0.006694385;
            e22 = 0.006739502;
            l1 = la1 + (la2 / 60 + (la3 / 3600));
            l2 = lo1 + (lo2 / 60 + (lo3 / 3600));
            l1r = l1 * Math.PI / 180.0;
            l2r = l2 * Math.PI / 180.0;
            cl1 = Math.Cos(l1r);
            sl1 = Math.Sin(l1r);
            cl2 = Math.Cos(l2r);
            sl2 = Math.Sin(l2r);
            rn = a / Math.Sqrt(1 - e2 * sl1 * sl1);
            rnh = rn + h;
            x = rnh * (cl1 * cl2);
            y = rnh * (cl1 * sl2);
            z = ((1 - e2) * rnh) * sl1;
            Dx = -307;
            Dy = -304;
            Dz = 318;
            xB = x + Dx;
            yB = y - Dy;
            zB = z + Dz;
            p = Math.Sqrt((xB * xB) + (yB * yB));
            v = (Math.Atan((zB * a) / (b * p)));
            sv = (Math.Sin(v));
            cv = (Math.Cos(v));
            laB = Math.Atan((zB + e22 * b * (sv * sv * sv)) / (p - e2 * a * (cv * cv * cv)));
            laB1 = laB * 180.0 / Math.PI;
            loB = Math.Atan(yB / xB);
            loB1 = loB * 180.0 / Math.PI;
            hB = ((p / cl1) - rn);
            lag = (int)laB1;
            lam = (laB1 - lag) * 60;
            lam2 = (int)lam;
            las = (lam - lam2) * 60;
            log = (int)loB1;
            lom = (loB1 - log) * 60;
            lom2 = (int)lom;
            los = (lom - lom2) * 60;
            return "\n\t\t\t\tLos grados de la Latitud son: " + lag + "\n\t\t\t\tLos minutos de la Latitud son: " + lam2 +
               "\n\t\t\t\tLos segundos de la Latitud son: " + las + "\n\t\t\t\tLos grados de la Longitud son: " + log +
               "\n\t\t\t\tLos minutos de la Longitud son: " + lom2 + "\n\t\t\t\tLos segundos de la Longitud son: " + los +
               "\n\t\t\t\tLa altura es: " + hB;

        }
    }
}

