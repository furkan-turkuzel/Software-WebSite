using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IUsersBLL
    {
        void Add(Users entity);
        void Delete(Users entity);
        void Update(Users entity);
        Users Get(int ID);
        List<Users> GetAll(int ID);
    }
}
