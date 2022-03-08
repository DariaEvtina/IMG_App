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
    public partial class TTTpage : ContentPage
    {
        //public bool bot;
        int theme = 1;
        int clicks=0;
        Grid grid2X1, grid3X3;
        BoxView b;
        Button uus_mang;
        Button teema;
        public bool esimene;
        int tulemus = 0;
        //Random rnd;
        int[,] Tulemused = new int[3, 3];
        public TTTpage()
        {
            
            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.DarkGray,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };

            //Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            teema = new Button()
            {
                Text = "liidse teema"
            };
            grid2X1.Children.Add(uus_mang, 0, 1);
            grid2X1.Children.Add(teema, 0, 2);
            uus_mang.Clicked += Uus_mang_Clicked;
            teema.Clicked += Teema_Clicked;
            Content = grid2X1;
        }

        private void Teema_Clicked(object sender, EventArgs e)
        {
            teema_v();
        }
        public async void teema_v()
        {
            string valik = await DisplayPromptAsync("Millisse teema?", "Teemas: default-1 või purple-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (valik == "1")
            {
                theme = 1;
            }
            else
            {
                theme= 2;
            }
        }

        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Kollane-1 või Punane-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (esimene_valik == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        /*public async void botbob()
        {
            string bot_valik = await DisplayPromptAsync("Kas sa soovin mangi bottiga?", "jah-1 või ei-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (bot_valik == "1")
            {
                bot = true;
            }
            else
            {
                bot = false;
            }
        }*/
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();
        }

        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                Kes_on_esimene();
                Tulemused = new int[3, 3];
                tulemus = 0;
                grid3X3 = new Grid
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
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
                };
                if (theme==1)
                {
                    grid3X3.BackgroundColor = Color.Black;
                }
                else if (theme == 2)
                {
                    grid3X3.BackgroundColor = Color.Purple;
                }
                  for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (theme == 1)
                            {
                                b = new BoxView { BackgroundColor = Color.White };
                            }
                            else if (theme == 2)
                            {
                                b = new BoxView { BackgroundColor = Color.LightPink };
                            }
                            grid3X3.Children.Add(b, j, i);
                            TapGestureRecognizer tap = new TapGestureRecognizer();
                            tap.Tapped += Tap_Tapped;
                            b.GestureRecognizers.Add(tap);
                        }
                    }
                grid2X1.Children.Add(grid3X3, 0, 0);
            }

        }
        // "00""10""20", 
        // "01""11""21", 
        // "02""12""22",
        // "00""01""02",
        // "10""11""12",
        // "20""21""22", "001122", "021120" };

        public int Kontroll()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            else if(Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[1, 2] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 0] == 2)
            {
                tulemus = 2;
            }
            else
            {
                tulemus = 0;
            }
            return tulemus;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Esimine on võitja!", "Ok");
                clicks = 0;
            }
            else if (tulemus == 2)
            {
                DisplayAlert("Võit", "Teine on võitja!", "Ok");
                clicks = 0;
            }
            else if (tulemus == 0 && clicks==9)
            {
                DisplayAlert("Võit", "viik", "Ok");
                clicks = 0;
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {

           var b = (BoxView)sender;
           var r = Grid.GetRow(b);
           var c = Grid.GetColumn(b);
           if (esimene == true)
           {
                if (b.BackgroundColor != Color.Yellow || b.BackgroundColor != Color.Gold)
                {
                    clicks++;
                }
                if (theme==1)
                {
                    b = new BoxView { BackgroundColor = Color.Yellow };
                }
                else
                {
                    b = new BoxView { BackgroundColor = Color.Gold };
                }
                esimene = false;
                Tulemused[r, c] = 1;
                
           }
           else if (esimene == false)
           {
                if (b.BackgroundColor != Color.Red || b.BackgroundColor != Color.Magenta)
                {
                    clicks++;
                }
                if (theme == 1)
                {
                    b = new BoxView { BackgroundColor = Color.Red };
                }
                else
                {
                    b = new BoxView { BackgroundColor = Color.Magenta };
                }
                esimene = true;
               Tulemused[r, c] = 2;
                
            }
           grid3X3.Children.Add(b, c, r);
           Lopp();
            /*}
            else if (bot==true)
            {
                if (esimene == true)
                {
                    b = new BoxView { BackgroundColor = Color.Yellow };
                    esimene = false;
                    Tulemused[r, c] = 1;
                    rnd = new Random();
                }
                else if (esimene == false)
                {
                    b = new BoxView { BackgroundColor = Color.Red };
                    esimene = true;
                    Tulemused[r, c] = 2;
                    rnd = new Random();
                    
                }
                grid3X3.Children.Add(b, c, r);
                Lopp();
            }*/
        }

    }
}