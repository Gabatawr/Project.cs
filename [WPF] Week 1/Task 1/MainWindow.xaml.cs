using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random r = new Random();

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
