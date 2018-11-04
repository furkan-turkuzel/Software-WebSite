using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface IReferanceBLL
    {
        void Add(Referance entity);
        void Delete(Referance entity);
        void Update(Referance entity);
        Referance Get(int ID);
        List<Referance> GetAll(int ID);
    }
}
