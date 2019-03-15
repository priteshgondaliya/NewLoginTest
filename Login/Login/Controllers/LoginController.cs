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
    public class LoginController : Controller
    {
        private readonly IloginService _loginService = null;
        private readonly IUserService _userService = null;
        public LoginController() {
            _loginService = new LoginService();
            _userService = new UserService();
        }
        //public LoginController(IloginService loginService) => _loginService = loginService;


        [AllowAnonymous]
        public async Task<ActionResult> Login()
        {
            bool isloggedin = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            string name = System.Web.HttpContext.Current.User.Identity.Name.Trim();
            if (isloggedin)
            {
                var u = await _userService.GetAll();
                UserList list = new UserList();
                list.users = u.ToList();
                return View("Userhome", u.ToList());
            }
            return View("Index", "_Loginpage");
        }



        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            
            return View("Index", "_Loginpage");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginPost(LoginView login)
        {
            var status = await _loginService.isValidLoginUser(login);
            if (status.IsValid)
            {
                FormsAuthentication.SetAuthCookie(status.UserName, false);
                var u = await _userService.GetAll();
                UserList list = new UserList();
                list.users = u.ToList();
                return View("Userhome", u.ToList());

            }
            return View();
        }
    }
}