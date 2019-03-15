using Login.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Buissness.Interface
{
    public interface IloginService
    {

        Task<UserView> FindById(int id);

        Task<Status> isValidLoginUser(LoginView user);

    }
}
