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
    public class AboutService : IAboutBLL
    {
        EFAboutDAL _AboutDAL = new EFAboutDAL();
        public void Add(About entity)
        {
            _AboutDAL.Add(entity);
        }

        public void Delete(About entity)
        {
            _AboutDAL.Delete(entity);
        }

        public About Get(int ID)
        {
            return _AboutDAL.Get(x=> x.ID == ID);
        }

        public List<About> GetAll(int ID)
        {
            return _AboutDAL.GetAll(x => x.ID == ID);
        }

        public void Update(About entity)
        {
            _AboutDAL.Update(entity);
        }
    }
}
