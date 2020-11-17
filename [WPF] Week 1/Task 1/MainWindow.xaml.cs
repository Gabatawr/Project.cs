using System;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < r.Next(255); i++)
            {
                Color col = new Color()
                {
                    A = 255, 
                    R = (byte)r.Next(255), 
                    B = (byte)r.Next(255),
                    G = (byte)r.Next(255)
                };
                wrapPanel.Children.Add(new TextBlock()
                {
                    Text = col.ToString(),
                    Background = new SolidColorBrush(col),
                    Margin = new Thickness(2)
                });
            }
            
        }
    }
}
