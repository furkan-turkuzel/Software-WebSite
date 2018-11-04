using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface ISolutionBLL 
    {
        void Add(Solution entity);
        void Delete(Solution entity);
        void Update(Solution entity);
        Solution Get(int ID);
        List<Solution> GetAll(int ID);
    }
}
