using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IContactBLL
    {
        void Add(Contact entity);
        void Delete(Contact entity);
        void Update(Contact entity);
        Contact Get(int ID);
        List<Contact> GetAll(int ID);
    }
}
