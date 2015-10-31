using AppExternaDDS.Controllers;
using AppExternaDDS.Helpers;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CandidatePostsIndexView.xaml
    /// </summary>
    public partial class CandidatePostsIndexView : UserControl
    {
        CandidatePostsController _controller;
        ViewId _viewId;
        public CandidatePostsIndexView(CandidatePostsController controller)
        {
            InitializeComponent();

            _viewId = ViewId.CandidatePostsIndex;
            _controller = controller;
            this.DataContext = controller;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.EnteringView(_viewId);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _controller.LeavingView(_viewId);
        }
    }
}
