using AnalitikBilisimSite.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalitikBilisimSite.Model.Entities;
using AnalitikBilisimSite.DAL.Concrete.Management;

namespace AnalitikBilisimSite.BLL.Concrete
{
    public class UsersService : IUsersBLL
    {
        EFUsersDAL _UsersDAL = new EFUsersDAL();
        public void Add(Users entity)
        {
            _UsersDAL.Add(entity);
        }

        public void Delete(Users entity)
        {
            _UsersDAL.Delete(entity);
        }

        public Users Get(int ID)
        {
            return _UsersDAL.Get(x => x.ID == ID);
        }

        public List<Users> GetAll(int ID)
        {
            return _UsersDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Users entity)
        {
            _UsersDAL.Update(entity);
        }
    }
}
