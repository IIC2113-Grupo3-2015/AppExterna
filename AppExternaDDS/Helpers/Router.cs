using AppExternaDDS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppExternaDDS.Helpers
{
    public enum ViewId
    {
        UserShow, CandidateShow
    }

    public class Router
    {
        private Dictionary<ViewId, UserControl> _viewsMap = new Dictionary<ViewId, UserControl>();
        private static Router _instance = null;
        private Router(){}

        public static Router Instance
        {
            get { if (_instance == null) _instance = new Router(); return _instance; }
        }

        public void AddView(ViewId id, UserControl view)
        {
            _viewsMap.Add(id, view);
        }

        public void NavigateTo(ViewId id, Dictionary<string, string> parameters)
        {
            if (_viewsMap.ContainsKey(id))
            {
                if (parameters != null)
                {
                    MainController.Instance.global_parameters.Clear();
                    foreach (var p in parameters)
                        MainController.Instance.global_parameters.Add(p.Key, p.Value);
                }

                var view = _viewsMap[id];
                MainController.Instance.CurrentView = view;
            }
            else throw new Exception("View " + id.ToString() + " was not found in the dictionary");
        }

    }
}
