using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IVisitorBLL
    {
        void Add(Visitor entity);
        void Delete(Visitor entity);
        void Update(Visitor entity);
        Visitor Get(int ID);
        List<Visitor> GetAll(int ID);
    }
}
