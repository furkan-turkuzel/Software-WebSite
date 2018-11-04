using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface ILanguageBLL
    {
        void Add(Language entity);
        void Delete(Language entity);
        void Update(Language entity);
        Language Get(int ID);
        List<Language> GetAll(int ID);
    }
}
