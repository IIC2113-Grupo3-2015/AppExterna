using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AppExternaDDS
{
    //Main controller of the application, responsible of handling the switching of views and their specific controllers
    public class MainController : ViewModelBase
    {
        HttpClient client = new HttpClient();

        //constructor of the class
        public MainController()
        {
          
        }

        //this method will set up the http client to enable comunication with the API Web Server
        private void ConfigureHttpClient()
        {

        }
        

    }
}
