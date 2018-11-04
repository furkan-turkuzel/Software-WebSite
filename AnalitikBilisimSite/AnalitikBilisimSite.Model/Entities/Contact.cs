using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class Contact : IEntity
    {
        public int ID { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string GoogleMap { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Google { get; set; }
        public string Linkedin { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }


    }
}
