using AppExternaDDS.Controllers;
using AppExternaDDS.Helpers;
using AppExternaDDS.Models;
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
    /// Interaction logic for UserShowView.xaml
    /// </summary>
    public partial class UserShowView : UserControl
    {
        UsersController _controller;
        public UserShowView(UsersController controller)
        {
            InitializeComponent();

            _controller = controller;
            this.DataContext = controller;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _controller.EnteringView(ViewId.UserShow);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _controller.LeavingView(ViewId.UserShow);
        }

        private void ShowCandidate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var model = btn.DataContext as CandidateMetadata;
            var parameters = new Dictionary<string, string> { { "id", model.Id.ToString() } };
            Router.Instance.NavigateTo(ViewId.CandidateShow, parameters);
        }
    }
}
