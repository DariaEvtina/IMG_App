using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IMG_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            StackLayout st = new StackLayout();
            Button img_btn = new Button
            {
                Text = "Image Page",
                BackgroundColor = Color.Firebrick
            };
            st.Children.Add(img_btn);
            img_btn.Clicked += Img_btn_Clicked;
            Button frame_btn = new Button
            {
                Text = "Frame Page",
                BackgroundColor = Color.Firebrick
            };
            Button valgusfor_btn = new Button
            {
                Text = "Valgusfoor Page",
                BackgroundColor = Color.Firebrick
            };
            Button RGB_btn = new Button
            {
                Text = "RGB Page",
                BackgroundColor = Color.Firebrick
            };
            st.Children.Add(frame_btn);
            st.Children.Add(RGB_btn);
            st.Children.Add(valgusfor_btn);
            valgusfor_btn.Clicked += Valgusfor_btn_Clicked;
            frame_btn.Clicked += Frame_btn_Clicked;
            RGB_btn.Clicked += RGB_btn_Clicked;
            Content = st;
        }

        private async void RGB_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new rgbPAGE());
        }

        private async void Valgusfor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfor());
        }

        private async void Frame_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FramePage());
        }

        private async void Img_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage());
        }
    }
}
