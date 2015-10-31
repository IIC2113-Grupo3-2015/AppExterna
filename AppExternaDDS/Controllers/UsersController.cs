using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppExternaDDS.Models;
using AppExternaDDS.Helpers;

namespace AppExternaDDS.Controllers
{
    //Controller responsible of managing all the logic about users
    public class UsersController : ControllerBase, IRestful
    {
        public static readonly string users_path = "api/users";
        
        private User _user;
        private bool _userFound;

        public bool UserFound
        {
            get { return _userFound; }
            set { if (_userFound != value) { _userFound = value; RaisePropertyChanged("UserFound"); } }
        }
        public User User
        {
            get { return _user; }
            set { if (_user != value) { _user = value; RaisePropertyChanged("User"); } }
        }

        public UsersController(HttpClient client) {
            _client = client;
            _user = User.EmptyInstance;
            _userFound = false;
        }

        public override void EnteringView(ViewId viewId)
        {
            Feedback = "";
            switch (viewId)
            {
                case ViewId.UserShow:
                    GetOne(); break;
                default:
                    Feedback += "ViewId = " + viewId.ToString() + " not implemented yet!!\n"; break;
            }
        }

        public override void LeavingView(ViewId viewId)
        {
        }

        public async Task GetOne()
        {
            if (!MainController.Instance.global_parameters.ContainsKey("id"))
            {
                Feedback += "Parameter 'id' not found\n";
                return;
            }
            try
            {
                string id = MainController.Instance.global_parameters["id"];
                string url = users_path + "/" + id;
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var user = await response.Content.ReadAsAsync<User>();
                User = user;
                UserFound = true;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Feedback += jEx.Message + "\n";
            }
            catch (HttpRequestException ex)
            {
                Feedback += ex.Message + "\n";
            }  
        }

        public async Task GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task GetPage()
        {
            throw new NotImplementedException();
        }

        public async Task Create()
        {
            throw new NotImplementedException();
        }

        public async Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
