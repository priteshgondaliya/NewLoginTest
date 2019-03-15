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
using System;

namespace Login.Buissness.Sevices
{
   public  class UserService : IUserService
    {

        private readonly DataModel _db = null;

        public UserService()
        {
            _db = new DataModel();
        }

        public async Task Add(UserView entity)
        {
            // Use Mapper insted of this
            User u = new User();
            u.FirstName = entity.FirstName;
            u.LastName = entity.LastName;
            u.BirthDate = entity.BirthDate;
            u.UserName = entity.UserName;
            u.CreatedDate = DateTime.Now;
            u.ModifiedDate = DateTime.Now;
            u.EntryBy = 1;
            u.ID = 2;
            _db.Users.Add(u);
            await _db.SaveChangesAsync();
        }

        public async Task<UserView> FindByName(string uname)
        {

            //await _db.Users.Where(x => x.ID == id).ProjectTo<UserView>().FirstOrDefaultAsync();
            var user =  await _db.Users.Where(x => x.UserName.Trim().Equals(uname.Trim())).FirstOrDefaultAsync();
            // Use Mapper insted of this
            UserView u = new UserView();
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.BirthDate = user.BirthDate;
            u.UserName = user.UserName;
            return u;
        }

        public async Task<IEnumerable<UserView>> GetAll()
        {
            // Use Mapper insted of this
            List<UserView> userlist = new List<UserView>();
            var users  = await _db.Users.ToListAsync();
            foreach (var user in users) {
                UserView u = new UserView();
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.BirthDate = user.BirthDate;
                u.UserName = user.UserName;
                userlist.Add(u);
            }
            return userlist;
        }


    }
}
