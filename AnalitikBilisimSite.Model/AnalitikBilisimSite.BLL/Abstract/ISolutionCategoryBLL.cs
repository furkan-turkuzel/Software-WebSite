using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    interface ISolutionCategoryBLL
    {
        void Add(SolutionCategory entity);
        void Delete(SolutionCategory entity);
        void Update(SolutionCategory entity);
        SolutionCategory Get(int ID);
        List<SolutionCategory> GetAll(int ID);
    }
}
