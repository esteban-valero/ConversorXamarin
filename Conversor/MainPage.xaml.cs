using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Conversor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "Bienvenido al Conversor";
            Label label = new Label
            {
                Text = "Seleccione el tipo de conversion que desea ",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            Button button = new Button
            {
                Text = " BOGOTA a GWS84 ",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += Button_Clicked;

            Button button2 = new Button
            {
                Text = " GWS84 a BOGOTA ",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button2.Clicked += Button2_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    label,
                    button,
                    button2
                }
            };

        }

        async void Button2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new MyPage2()));
        }


        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new MyPage()));
        }

    }
}
