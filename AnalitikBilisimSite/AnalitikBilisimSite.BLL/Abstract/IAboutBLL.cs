using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IAboutBLL
    {
        void Add(About entity);
        void Delete(About entity);
        void Update(About entity);
        About Get(int ID);
        List<About> GetAll(int ID);
    }
}
