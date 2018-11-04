using AnalitikBilisimSite.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalitikBilisimSite.Model.Entities;
using System.Linq.Expressions;
using AnalitikBilisimSite.BLL.Abstract;
using AnalitikBilisimSite.DAL.Concrete.Management;

namespace AnalitikBilisimSite.BLL.Concrete
{
    public class NewsService : INewsBLL
    {
        EFNewsDAL _NewsDAL = new EFNewsDAL();
        public void Add(News entity)
        {
            _NewsDAL.Add(entity);
        }

        public void Delete(News entity)
        {
            _NewsDAL.Delete(entity);
        }

        public News Get(int ID)
        {
            return _NewsDAL.Get(x => x.ID == ID);
        }

        public List<News> GetAll(int ID)
        {
            return ID == 0
                ? _NewsDAL.GetAll(null)
                : _NewsDAL.GetAll(x => x.ID == ID);
        }

        public void Update(News entity)
        {
            _NewsDAL.Update(entity);
        }
    }
}
