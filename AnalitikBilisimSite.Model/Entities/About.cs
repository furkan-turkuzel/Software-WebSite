﻿using AnalitikBilisimSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Entities
{
    public class About : IEntity
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string SmallWriting { get; set; }
        public string BigWriting { get; set; }
        public string Image { get; set; }
        public string MissionTitle { get; set; }
        public string MissionWriting { get; set; }
        public string MissionImage { get; set; }
        public string PlanTitle { get; set; }
        public string PlanWriting { get; set; }
        public string PlanImage { get; set; }
        public string VisionTitle { get; set; }
        public string VisionWriting { get; set; }
        public string VisionImage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}