using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Controls;
using AppExternaDDS.Helpers;
using AppExternaDDS.Views;

namespace AppExternaDDS.Controllers
{
    //Main controller of the application, responsible of handling the switching of views and their specific controllers
    public class MainController : ControllerBase
    {
        public static readonly string BaseAddress = "http://private-93c37-externalappddsapi.apiary-mock.com";

        private static MainController _instance = null;

        public Dictionary<string, string> global_parameters = new Dictionary<string, string>();
        //controllers
        private UsersController _usersController;
        private CandidatesController _candidatesController;
        private CandidatePostsController _candidatesPostsController;
        //views
        private UserShowView _userShowView;
        private CandidateShowView _candidateShowView;
        private CandidatePostsIndexView _candidatePostsIndexView;
        //current view
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get { return _currentView; }
            set { if (_currentView != value) { _currentView = value; RaisePropertyChanged("CurrentView"); } }
        }

        public static MainController Instance
        {
            get { if (_instance == null) _instance = new MainController(); return _instance; }
        }
        
        private MainController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BaseAddress);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             
            //###############################
            //init user controller and views
            //##############################

            //users
            _usersController = new UsersController(_client);
            _userShowView = new UserShowView(_usersController);
            Router.Instance.AddView(ViewId.UserShow, _userShowView);

            //candidates
            _candidatesController = new CandidatesController(_client);
            _candidateShowView = new CandidateShowView(_candidatesController);
            Router.Instance.AddView(ViewId.CandidateShow, _candidateShowView);

            //candidate posts
            _candidatesPostsController = new CandidatePostsController(_client);
            _candidatePostsIndexView = new CandidatePostsIndexView(_candidatesPostsController);
            Router.Instance.AddView(ViewId.CandidatePostsIndex, _candidatePostsIndexView);

            //set default view
            _currentView = _userShowView;
            global_parameters.Add("id", "1");
        }


        public override void EnteringView(ViewId id)
        {
            throw new NotImplementedException();
        }

        public override void LeavingView(ViewId id)
        {
            throw new NotImplementedException();
        }
    }
}
