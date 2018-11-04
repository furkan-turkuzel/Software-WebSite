using AnalitikBilisimSite.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalitikBilisimSite.Model.Entities;
using AnalitikBilisimSite.DAL.Abstract;
using AnalitikBilisimSite.DAL.Concrete.Management;

namespace AnalitikBilisimSite.BLL.Concrete
{
    public class LanguageService : ILanguageBLL
    {
        EFLanguageDAL _languageDAL = new EFLanguageDAL();
        public void Add(Language entity)
        {
            _languageDAL.Add(entity);
        }

        public void Delete(Language entity)
        {
            _languageDAL.Delete(entity);
        }

        public Language Get(int ID)
        {
            return _languageDAL.Get(x => x.ID == ID);
        }

        public List<Language> GetAll(int ID)
        {
            return _languageDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Language entity)
        {
            _languageDAL.Update(entity);
        }
    }
}
