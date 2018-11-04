using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface INewsBLL
    {
        void Add(News entity);
        void Delete(News entity);
        void Update(News entity);
        News Get(int ID);
        List<News> GetAll(int ID);
    }
}
