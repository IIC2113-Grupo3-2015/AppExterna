using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExternaDDS.Controllers
{
    public interface IRestful
    {
        Task GetOne();
        Task GetAll();
        Task GetPage();
        Task Create();
        Task Delete();
        Task Update();
    }
}
