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
    public class CommonService : ICommonBLL
    {
        EFCommonDAL _CommonDAL = new EFCommonDAL();
        public void Add(Common entity)
        {
            _CommonDAL.Add(entity);
        }

        public void Delete(Common entity)
        {
            _CommonDAL.Delete(entity);
        }

        public Common Get(int ID)
        {
            return _CommonDAL.Get(x => x.ID == ID);
        }

        public List<Common> GetAll(int ID)
        {
            return _CommonDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Common entity)
        {
            _CommonDAL.Update(entity);
        }
    }
}
