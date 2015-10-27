using AppExternaDDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppExternaDDS.Controllers
{
    public class CandidatesController : ControllerBase, IRestful
    {
        public static readonly string candidates_path = "api/candidates";

        private Candidate _candidate;
        private bool _candidateFound;

        public bool CandidateFound
        {
            get { return _candidateFound; }
            set { if (_candidateFound != value) { _candidateFound = value; RaisePropertyChanged("CandidateFound"); } }
        }
        public Candidate Candidate
        {
            get { return _candidate; }
            set { if (_candidate != value) { _candidate = value; RaisePropertyChanged("Candidate"); } }
        }

        public CandidatesController(HttpClient client)
        {
            _client = client;
            _candidate = Candidate.EmptyInstance;
            _candidateFound = false;
        }



        public override void EnteringView(Helpers.ViewId id)
        {
            Feedback = "";
        }

        public override void LeavingView(Helpers.ViewId id)
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
                string url = candidates_path + "/" + id;
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var candidate = await response.Content.ReadAsAsync<Candidate>();
                Candidate = candidate;
                CandidateFound = true;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Feedback += jEx.Message + "\n";
            }
            catch (HttpRequestException ex)
            {
                Feedback += ex.Message + "\n";
            }
            finally
            {
                Feedback += "transaction completed!!";
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
