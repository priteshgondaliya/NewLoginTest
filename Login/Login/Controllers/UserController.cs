using Login.Buissness.Interface;
using Login.Buissness.Sevices;
using Login.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService = null;
        public UserController() {
            _userService = new UserService();
        }
        //public LoginController(IloginService loginService) => _loginService = loginService;

        [HttpGet]
        [Authorize]
        public ActionResult All()
        {   

          
            return View("All");
        }


        [HttpPost]
        [Authorize]
        public ActionResult Add(UserView user)
        {
            return View("Add");
        }

    }
}