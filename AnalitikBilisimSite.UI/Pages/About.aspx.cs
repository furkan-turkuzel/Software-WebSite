using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using AnalitikBilisimSite.Panel.UI.Pages.panel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class About : System.Web.UI.Page
    {
        AboutService _aboutService = new AboutService();
        AnalitikDBContext db = new AnalitikDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AnalitikBilisimSite.Model.Entities.Language language = (Language)Session["dil"];
                if (language != null)
                {
                    int aboutID = (from a in db.About
                                   where a.LanguageID == language.ID
                                   select a.ID).FirstOrDefault();
                    Doldur(aboutID);
                }
                else
                {
                    int aboutID = (from a in db.About
                                   join l in db.Language on a.LanguageID equals l.ID
                                   where l.Code == "tr-TR"
                                   select a.ID).FirstOrDefault();
                    Doldur(aboutID);
                }

            }
            catch (Exception)
            {
                throw;
            }
            ((MasterPage)this.Master).AboutMenu = "menu-active";
        }

        protected void Doldur(int aboutID)
        {

            AnalitikBilisimSite.Model.Entities.About about = _aboutService.Get(aboutID);

            lblAboutTitle.Text = about.Title;
            lblAboutWriting.Text = about.BigWriting;
            lblMissionTitle.Text = about.MissionTitle;
            lblMissionWriting.Text = about.MissionWriting;
            lblPlanTitle.Text = about.PlanTitle;
            lblPlanWriting.Text = about.PlanWriting;
            lblVisionTitle.Text = about.VisionTitle;
            lblVisionWriting.Text = about.VisionWriting;
            ImgMission.ImageUrl = about.MissionImage;
            ImgPlan.ImageUrl = about.PlanImage;
            ImgVision.ImageUrl = about.VisionImage;
        }
    }
}