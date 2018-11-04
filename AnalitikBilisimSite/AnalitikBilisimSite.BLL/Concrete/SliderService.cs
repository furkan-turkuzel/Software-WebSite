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
    public class SliderService : ISliderBLL
    {
        EFSliderDAL _sliderDAL = new EFSliderDAL();
        public void Add(Slider entity)
        {
            _sliderDAL.Add(entity);
        }

        public void Delete(Slider entity)
        {
            _sliderDAL.Delete(entity);
        }

        public Slider Get(int ID)
        {
            return _sliderDAL.Get(x => x.ID == ID);
        }

        public List<Slider> GetAll(int ID)
        {
            return _sliderDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Slider entity)
        {
            _sliderDAL.Update(entity);
        }
    }
}
