using AppExternaDDS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppExternaDDS.Controllers
{
    public abstract class ControllerBase : ViewModelBase
    {
        protected HttpClient _client;
        protected string _feedback = "";

        public string Feedback
        {
            get { return _feedback; }
            protected set
            {
                _feedback = value;
                RaisePropertyChanged("Feedback");
            }
        }

        public abstract void EnteringView(ViewId id);
        public abstract void LeavingView(ViewId id);

    }
}
