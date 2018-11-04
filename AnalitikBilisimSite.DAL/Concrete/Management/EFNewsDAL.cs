using AnalitikBilisimSite.Core.DataAccess.EntityFramework;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.DAL.Concrete.Management
{
    public class EFNewsDAL : EFEntityRepositoryBase<AnalitikDBContext, News>
    {
    }
}
