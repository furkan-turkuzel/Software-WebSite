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
    public class ServicesDetailService : IServicesDetailBLL
    {
        EFServicesDetailDAL _servicesDetailDAL = new EFServicesDetailDAL();
        public void Add(ServicesDetail entity)
        {
            _servicesDetailDAL.Add(entity);
        }

        public void Delete(ServicesDetail entity)
        {
            _servicesDetailDAL.Delete(entity);
        }

        public ServicesDetail Get(int ID)
        {
            return _servicesDetailDAL.Get(x => x.ID == ID);
        }

        public List<ServicesDetail> GetAll(int ID)
        {
            return _servicesDetailDAL.GetAll(x => x.ID == ID);
        }

        public void Update(ServicesDetail entity)
        {
            _servicesDetailDAL.Update(entity);
        }
    }
}
