using SignalsFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace SignalsFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void SetImage(String Image)
        {
            MessageBox.Show("s");
            Signal.Source = new BitmapImage(new Uri(@"/Images/Image1.jpg", UriKind.Relative));
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button1_Click(object sender, RoutedEventArgs e)
        {

            if (Button1.Content.ToString() == "Empezar")
            {
                Button1.Content = "Detener";
                Button1.Background = Brushes.DarkRed;
                Application.Current.MainWindow.Height = 800;
                STT stt = new STT();
                await stt.Main();
                //aqui si sirve
                SetImage("");
            }
            else
            {
                Button1.Content = "Empezar";
                Button1.Background = Brushes.DarkGreen;
                Application.Current.MainWindow.Height = 300;
                Signal.Source = new BitmapImage(new Uri(@"", UriKind.Relative));

            }
        }

    }
}