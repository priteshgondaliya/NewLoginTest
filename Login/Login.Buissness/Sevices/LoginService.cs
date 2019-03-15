using AutoMapper;
using AutoMapper.QueryableExtensions;
using Login.Buissness.Interface;
using Login.Data.DataModel;
using Login.Model.ViewModel;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Login.Buissness.Sevices
{
   public  class LoginService : IloginService
    {

        private readonly DataModel _db = null;

        public LoginService()
        {
            _db = new DataModel();
        }

        public async Task<UserView> FindById(int id) => await _db.Users.Where(x => x.ID == id).ProjectTo<UserView>().FirstOrDefaultAsync();

        public async Task<Status> isValidLoginUser(LoginView user)
        {
            Status s = new Status();
            s.IsValid = false;
            var existinguser = await _db.Users.Where(x => x.UserName.Equals(user.UserName.Trim())).FirstOrDefaultAsync();
            if (existinguser != null)
            {
                if (existinguser.Password.Trim().Equals(user.Password.Trim()))
                {
                    s.UserName = existinguser.UserName.Trim() ;
                    s.Message = "User Found";
                    s.IsValid = true;
                    return s;
                }
            }
            s.Message = "User Not Found";
            s.IsValid = false;
            return s;
        }
    }
}
