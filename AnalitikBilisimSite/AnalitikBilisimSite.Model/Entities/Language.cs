using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class Language : IEntity
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string LanguageName { get; set; }
        public string Logo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
