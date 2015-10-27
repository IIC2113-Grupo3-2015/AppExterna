using AppExternaDDS.Controllers;
using AppExternaDDS.Views;
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

namespace AppExternaDDS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController _controller;

        public MainWindow()
        {
            InitializeComponent();

            //initialize MainController
            _controller = MainController.Instance;
            this.DataContext = _controller;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
