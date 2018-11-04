using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class News : IEntity
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string SmallWriting { get; set; }
        public string BigWriting { get; set; }
        public int UserID { get; set; }
        public string Image { get; set; }
        public DateTime NewsDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public Users User { get; set; }
    }
}
