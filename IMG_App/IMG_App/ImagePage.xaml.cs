using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMG_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Switch sw;
        Image img;
        public ImagePage()
        {
            img = new Image { Source = @"Cat.png" };
            sw = new Switch
            {
                IsToggled=true,
                VerticalOptions=LayoutOptions.EndAndExpand,
                HorizontalOptions=LayoutOptions.Center
            };
            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = { img, sw } };
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}