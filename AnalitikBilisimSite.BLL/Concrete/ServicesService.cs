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
    public class ServicesService : IServicesBLL
    {
        EFServicesDAL _ServicesDAL = new EFServicesDAL();
        public void Add(Services entity)
        {
            _ServicesDAL.Add(entity);
        }

        public void Delete(Services entity)
        {
            _ServicesDAL.Delete(entity);
        }

        public Services Get(int ID)
        {
            return _ServicesDAL.Get(x => x.ID == ID);
        }

        public List<Services> GetAll(int ID)
        {
            return _ServicesDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Services entity)
        {
            _ServicesDAL.Update(entity);
        }
    }
}
