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
    public class SolutionService : ISolutionBLL
    {
        EFSolutionDAL _solutionDAL = new EFSolutionDAL();
        public void Add(Solution entity)
        {
            _solutionDAL.Add(entity);
        }

        public void Delete(Solution entity)
        {
            _solutionDAL.Delete(entity);
        }

        public Solution Get(int ID)
        {
            return _solutionDAL.Get(x => x.ID == ID);
        }

        public List<Solution> GetAll(int ID)
        {
           return _solutionDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Solution entity)
        {
            _solutionDAL.Update(entity);
        }
    }
}
