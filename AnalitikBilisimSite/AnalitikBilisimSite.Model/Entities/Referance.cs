using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class Referance : IEntity
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string ReferanceType { get; set; }
        public string ReferanceName { get; set; }
        public string ReferancePhone { get; set; }
        public string ReferanceAddress { get; set; }
        public string ReferanceLogo { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
