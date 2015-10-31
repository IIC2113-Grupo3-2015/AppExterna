using AppExternaDDS.Helpers;
using AppExternaDDS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppExternaDDS.Controllers
{
    public class CandidatePostsController :  ControllerBase, IRestful
    {
        public static readonly string candidate_posts_path = "api/candidates/{candidate_id}/posts";

        private PostsCollection _posts;        
        private bool _postsFound;

        public PostsCollection Posts
        {
            get { return _posts; }
        }

        public bool PostsFound
        {
            get { return _postsFound; }
            set { if (_postsFound != value) { _postsFound = value; RaisePropertyChanged("PostsFound"); } }
        }

        public CandidatePostsController(HttpClient client)
        {
            _client = client;
            _postsFound = false;
            _posts = new PostsCollection();
        }

        public override void EnteringView(ViewId viewId)
        {
            Feedback = "";
            switch (viewId)
            {
                case ViewId.CandidateShow:
                    GetOne(); break;
                case ViewId.CandidatePostsIndex:
                    GetAll(); break;
            }
        }

        public override void LeavingView(ViewId id)
        {
        }

        public async Task GetOne()
        {
            throw new NotImplementedException();
        }

        public async Task GetAll()
        {
            if (!MainController.Instance.global_parameters.ContainsKey("candidate_id"))
            {
                Feedback += "Parameter 'candidate_id' not found\n";
                return;
            }
            try
            {
                string candidate_id = MainController.Instance.global_parameters["candidate_id"];
                string url = candidate_posts_path.Replace("{candidate_id}", candidate_id);
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var posts = await response.Content.ReadAsAsync<List<Post>>();
                _posts.CopyFrom(posts);
                PostsFound = true;
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
