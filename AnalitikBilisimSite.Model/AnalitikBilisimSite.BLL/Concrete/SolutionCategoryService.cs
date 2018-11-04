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
    public class SolutionCategoryService : ISolutionCategoryBLL
    {
        EFSolutionCategoryDAL _solutionCategoryDAL = new EFSolutionCategoryDAL();
        public void Add(SolutionCategory entity)
        {
            _solutionCategoryDAL.Add(entity);
        }

        public void Delete(SolutionCategory entity)
        {
            _solutionCategoryDAL.Delete(entity);
        }

        public SolutionCategory Get(int ID)
        {
            return _solutionCategoryDAL.Get(x => x.ID == ID);
        }

        public List<SolutionCategory> GetAll(int ID)
        {
            return _solutionCategoryDAL.GetAll(x => x.ID == ID);
        }

        public void Update(SolutionCategory entity)
        {
            _solutionCategoryDAL.Update(entity);
        }
    }
}
