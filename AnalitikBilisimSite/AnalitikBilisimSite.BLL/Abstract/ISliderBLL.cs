using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.BLL.Abstract
{
    public interface ISliderBLL
    {
        void Add(Slider entity);
        void Delete(Slider entity);
        void Update(Slider entity);
        Slider Get(int ID);
        List<Slider> GetAll(int ID);
    }
}
