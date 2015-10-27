using AppExternaDDS.Controllers;
using AppExternaDDS.Helpers;
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

namespace AppExternaDDS.Views
{
    /// <summary>
    /// Interaction logic for CandidateShowView.xaml
    /// </summary>
    public partial class CandidateShowView : UserControl
    {
        CandidatesController _controller;
        public CandidateShowView(CandidatesController controller)
        {
            InitializeComponent();

            _controller = controller;
            this.DataContext = controller;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.EnteringView(ViewId.CandidateShow);
            _controller.GetOne();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _controller.LeavingView(ViewId.CandidateShow);
        }
    }
}
