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
    public class ReferanceService : IReferanceBLL
    {
        EFReferanceDAL _ReferanceDAL = new EFReferanceDAL();
        public void Add(Referance entity)
        {
            _ReferanceDAL.Add(entity);
        }

        public void Delete(Referance entity)
        {
            _ReferanceDAL.Delete(entity);
        }

        public Referance Get(int ID)
        {
            return _ReferanceDAL.Get(x => x.ID ==ID);
        }

        public List<Referance> GetAll(int ID)
        {
            return _ReferanceDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Referance entity)
        {
            _ReferanceDAL.Update(entity);
        }
    }
}
