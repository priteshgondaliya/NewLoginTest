using Login.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Buissness.Interface
{
    public interface IUserService
    {
        Task<UserView> FindByName(string uname);

        Task<IEnumerable<UserView>> GetAll();

        Task Add(UserView entity);

    }
}
