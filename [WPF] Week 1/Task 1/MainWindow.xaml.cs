using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int brushCount = typeof(Brushes).GetProperties().Length;
            for (int i = 0; i < brushCount; i++)
            {
                PropertyInfo brush = typeof(Brushes).GetProperties()[i];
                SolidColorBrush col = (SolidColorBrush)brush.GetValue(null, null);

                wrapPanel.Children.Add(new TextBlock()
                {
                    Text = brush.Name,
                    Background = col,
                    Foreground = new SolidColorBrush(new Color
                    {
                        A = Byte.MaxValue,
                        //R = (byte)(255 - col.Color.R),
                        //G = (byte)(255 - col.Color.G),
                        B = (byte)(255 - col.Color.B)
                    }),
                    Margin = new Thickness(2),
                    Padding = new Thickness(2)
                });
            }
        }
    }
}
