using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IServicesDetailBLL 
    {
        void Add(ServicesDetail entity);
        void Delete(ServicesDetail entity);
        void Update(ServicesDetail entity);
        ServicesDetail Get(int ID);
        List<ServicesDetail> GetAll(int ID);
    }
}
