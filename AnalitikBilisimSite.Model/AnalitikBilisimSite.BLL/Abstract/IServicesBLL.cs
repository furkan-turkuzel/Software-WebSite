using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IServicesBLL
    {
        void Add(Services entity);
        void Delete(Services entity);
        void Update(Services entity);
        Services Get(int ID);
        List<Services> GetAll(int ID);
    }
}
