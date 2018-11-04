using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class ServicesDetail : IEntity
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int LanguageID { get; set; }
        public string ServiceDetailTitle { get; set; }
        public string ServiceDetailWriting { get; set; }
        public string ServiceDetailImage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Services Service { get; set; }
    }
}
