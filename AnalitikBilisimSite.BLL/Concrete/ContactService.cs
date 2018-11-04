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
    public class ContactService : IContactBLL
    {
        EFContactDAL _ContactDAL = new EFContactDAL();
        public void Add(Contact entity)
        {
            _ContactDAL.Add(entity);
        }

        public void Delete(Contact entity)
        {
            _ContactDAL.Delete(entity);
        }

        public Contact Get(int ID)
        {
            return _ContactDAL.Get(x => x.ID == ID);
        }

        public List<Contact> GetAll(int ID)
        {
            return _ContactDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Contact entity)
        {
            _ContactDAL.Update(entity);
        }
    }
}
