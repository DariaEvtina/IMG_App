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
    public partial class FramePage : ContentPage
    {
        Grid gr;
        Frame fm;
        Label lbl;
        public FramePage()
        {
            lbl = new Label { Text = "Raami kujundus", FontSize = Device.GetNamedSize(NamedSize.Header, typeof(Label)) };
            gr = new Grid
            {
                RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    },
            };
            gr.Children.Add(new BoxView { Color = Color.Red }, 0, 0);
            gr.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            gr.Children.Add(new BoxView { Color = Color.Yellow }, 0, 1);
            gr.Children.Add(new BoxView { Color = Color.Orange }, 1, 1);
            gr.Children.Add(new BoxView { Color = Color.Pink }, 0, 2);
            gr.Children.Add(new BoxView { Color = Color.Purple }, 1, 2);
            fm = new Frame
            {
                Content = gr,
                BorderColor = Color.Azure,
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { fm }
            };
            Content = st;
        }
    }
}