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
    public partial class rgbPAGE : ContentPage
    {

        Frame frm;
        Label r;
        Label b;
        Label g;
        Button randomRGB;
        Slider sldRed;
        Slider sldBlue;
        Slider sldGreen;
        Label tittle1;
        public rgbPAGE()
        {
            this.Title = "RGB page Daria Evtina";
            tittle1 = new Label
            {
                Text = "RGB",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            r = new Label
            {
                Text = "Red:0",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            b = new Label
            {
                Text = "Blue:0",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            g = new Label
            {
                Text = "Green:0",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            frm = new Frame
            {
                BackgroundColor = Color.FromRgb(0, 0, 0),
                BorderColor = Color.FromRgb(0,0,0),
                CornerRadius = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //InitializeComponent();
            sldRed = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Firebrick,
                MaximumTrackColor = Color.AliceBlue,
                ThumbColor = Color.White
            };
            sldRed.ValueChanged += Sld_ValueChanged;
            sldBlue = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Firebrick,
                MaximumTrackColor = Color.AliceBlue,
                ThumbColor = Color.White
            };
            sldBlue.ValueChanged += SldBlue_ValueChanged;
            sldGreen = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Firebrick,
                MaximumTrackColor = Color.AliceBlue,
                ThumbColor = Color.White
            };
            sldGreen.ValueChanged += SldGreen_ValueChanged;
            randomRGB = new Button
            {
                Text = "random color",
                BackgroundColor = Color.Firebrick
            };
            randomRGB.Clicked += RandomRGB_Clicked;
            StackLayout strgb = new StackLayout
            {
                Children = { r, sldRed, b, sldBlue, g, sldGreen, randomRGB }
            };
            StackLayout st = new StackLayout
            {
                Children = {tittle1, frm, strgb }
            };
            Content = st;

        }

        private void RandomRGB_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int red = (rnd.Next(0, 255));
            int green = (rnd.Next(0, 255));
            int blue = (rnd.Next(0, 255));
            frm.BackgroundColor = Color.FromRgb(red,green,blue);
            sldGreen.Value = green;
            sldRed.Value = red;
            sldBlue.Value = blue;
        }
        public void testColor()
        {
           /* if (sldRed.Value >= 200 && sldRed.Value > sldGreen.Value && sldBlue.Value > sldGreen.Value && Convert.ToInt32(sldBlue.Value) <= 230)
            {
                tittle1.Text = "Pink";
            }
            else if (sldRed.Value > sldBlue.Value && sldRed.Value > sldGreen.Value && sldBlue.Value > sldGreen.Value && Convert.ToInt32(sldBlue.Value) >= 230)
            {
                tittle1.Text = "Purple";
            }
            else if (sldRed.Value > sldBlue.Value && sldRed.Value > sldGreen.Value && sldBlue.Value < sldGreen.Value && Convert.ToInt32(sldGreen.Value) < 100 || sldRed.Value <= 255 && sldRed.Value > 200)
            {
                tittle1.Text = "Red";
            }
            else if (sldBlue.Value <= 255 && sldBlue.Value > sldGreen.Value && sldBlue.Value > sldRed.Value)
            {
                tittle1.Text = "Blue";
            }
            else if (sldGreen.Value <= 255 && sldBlue.Value < sldGreen.Value && sldBlue.Value < sldRed.Value)
            {
                tittle1.Text = "Green";
            }*/
        }
        private void SldGreen_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            g.Text = String.Format("Green: {0:F1}",Math.Round(e.NewValue,0));
            frm.BackgroundColor = Color.FromRgb(Convert.ToInt32(sldRed.Value), Convert.ToInt32(e.NewValue), Convert.ToInt32(sldBlue.Value));
            testColor();
        }

        private void SldBlue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            b.Text = String.Format("Blue: {0:F1}", Math.Round(e.NewValue,0));
            frm.BackgroundColor = Color.FromRgb(Convert.ToInt32(sldRed.Value), Convert.ToInt32(sldGreen.Value), Convert.ToInt32(e.NewValue));
            testColor();
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            r.Text = String.Format("Red: {0:F1}", Math.Round(e.NewValue,0));
            frm.BackgroundColor = Color.FromRgb(Convert.ToInt32(e.NewValue), Convert.ToInt32(sldGreen.Value), Convert.ToInt32(sldBlue.Value));
            testColor();
        }
    }
}