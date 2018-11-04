using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface ICommonBLL
    {
        void Add(Common entity);
        void Delete(Common entity);
        void Update(Common entity);
        Common Get(int ID);
        List<Common> GetAll(int ID);
    }
}
