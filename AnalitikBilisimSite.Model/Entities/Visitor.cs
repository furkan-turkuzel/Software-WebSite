using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class Visitor : IEntity
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string  Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
        public bool Readed { get; set; }

    }
}
