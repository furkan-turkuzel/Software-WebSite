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
    public class VisitorService : IVisitorBLL
    {
        EFVisitorDAL _visitorDAL = new EFVisitorDAL();
        public void Add(Visitor entity)
        {
            _visitorDAL.Add(entity);
        }

        public void Delete(Visitor entity)
        {
            _visitorDAL.Delete(entity);
        }

        public Visitor Get(int ID)
        {
            return _visitorDAL.Get(x => x.ID == ID);
        }

        public List<Visitor> GetAll(int ID)
        {
            return _visitorDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Visitor entity)
        {
            _visitorDAL.Update(entity);
        }
    }
}
