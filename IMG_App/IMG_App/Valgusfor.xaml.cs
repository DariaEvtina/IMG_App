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
    public partial class Valgusfor : ContentPage
    {
        Switch sw;
        Frame fm;
        Grid gr;
        BoxView bv1;
        BoxView bv2;
        Label lbl1;
        BoxView bv3;
        public Valgusfor()
        {
            lbl1 = new Label
            {
                Text="...",
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            bv1 = new BoxView { Color = Color.Gray, CornerRadius = 100 };
            bv2 = new BoxView { Color = Color.Gray, CornerRadius = 100 };
            bv3 = new BoxView { Color = Color.Gray, CornerRadius = 100 };
            Button sisse = new Button
            {
                Text = "sisse",
                BackgroundColor = Color.Firebrick,
                HorizontalOptions =LayoutOptions.EndAndExpand
            };
            sisse.Clicked += Sisse_Clicked;
            Button valja = new Button
            {
                Text = "valja",
                BackgroundColor = Color.Firebrick,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            valja.Clicked += Valja_Clicked;
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            sw.Toggled += Sw_Toggled;
            gr = new Grid
            {
                RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    },
            };
            gr.Children.Add(bv1, 0, 0);
            gr.Children.Add(bv2, 0, 1);
            gr.Children.Add(bv3, 0, 2);
            fm = new Frame
            {
                Content = gr,
                BorderColor = Color.Azure,
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            bv1.GestureRecognizers.Add(tap);
            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            tap2.Tapped += Tap2_Tapped;
            bv2.GestureRecognizers.Add(tap2);
            TapGestureRecognizer tap3 = new TapGestureRecognizer();
            tap3.Tapped += Tap3_Tapped;
            bv3.GestureRecognizers.Add(tap3);
            StackLayout st1 = new StackLayout
            {
                Children = { lbl1, sisse, valja, sw }
            };
            StackLayout st = new StackLayout
            {
                Children = { fm,st1 }
            };
            Content = st;
        }

        private void Valja_Clicked(object sender, EventArgs e)
        {
            sw.IsToggled = false;
            tsykl = 0;
            bv1.Color = Color.Gray;
            bv2.Color = Color.Gray;
            bv3.Color = Color.Gray;
        }

        private void Sisse_Clicked(object sender, EventArgs e)
        {
            sw.IsToggled = true;
            ShowTime();
        }

        private void Tap3_Tapped(object sender, EventArgs e)
        {
            lbl1.Text = "GREEN";
        }

        private void Tap2_Tapped(object sender, EventArgs e)
        {
            lbl1.Text = "YELLOW";
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            lbl1.Text = "RED";
        }

        int tsykl=0;
        private async void ShowTime()
        {
            do
            {
                if (sw.IsToggled == false)
                {
                    break;
                }
                else
                {
                    bv1.Color = Color.Red;
                    await Task.Delay(1000);
                    bv1.Color = Color.Gray;
                    await Task.Delay(500);
                    bv2.Color = Color.Yellow;
                    await Task.Delay(1000);
                    bv2.Color = Color.Gray;
                    await Task.Delay(500);
                    bv3.Color = Color.Green;
                    await Task.Delay(1000);
                    bv3.Color = Color.Gray;
                    await Task.Delay(500);
                    tsykl++;
                    if (tsykl == 3)
                    {
                        await Task.Delay(1000);
                        bv1.Color = Color.Red;
                        bv2.Color = Color.Red;
                        bv3.Color = Color.Red;
                        await Task.Delay(1000);
                        bv1.Color = Color.Yellow;
                        bv2.Color = Color.Yellow;
                        bv3.Color = Color.Yellow;
                        await Task.Delay(1000);
                        bv1.Color = Color.Green;
                        bv2.Color = Color.Green;
                        bv3.Color = Color.Green;
                        await Task.Delay(1000);
                        bv1.Color = Color.Gray;
                        bv2.Color = Color.Gray;
                        bv3.Color = Color.Gray;
                    }
                
                }
            } while (sw.IsToggled == true);

        }
        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                ShowTime();
            }
            else
            {
                tsykl = 0;
                bv1.Color = Color.Gray;
                bv2.Color = Color.Gray;
                bv3.Color = Color.Gray;
            }
        }
    }
}