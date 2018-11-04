using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        AnalitikDBContext db = new AnalitikDBContext();
        CommonService _common = new CommonService();
        AboutService _aboutService = new AboutService();
        ServicesService _services = new ServicesService();
        ServicesDetailService _servicesDetail = new ServicesDetailService();
        ReferanceService _referanceService = new ReferanceService();
        NewsService _newsService = new NewsService();

        public string More { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //AnalitikDBContext db = new AnalitikDBContext();
            //ICollection<Users> users = db.Users.ToList();
            try
            {
                AnalitikBilisimSite.Model.Entities.Language language = (Language)Session["dil"];
                string languageCode;
                if (language != null)
                {
                    int aboutID = (from a in db.About
                                   where a.LanguageID == language.ID
                                   select a.ID).FirstOrDefault();
                    DoldurAbout(aboutID);

                    languageCode = language.Code;
                    Doldur(languageCode, language.ID);
                }
                else
                {
                    int aboutID = (from a in db.About
                                   join l in db.Language on a.LanguageID equals l.ID
                                   where l.Code == "tr-TR"
                                   select a.ID).FirstOrDefault();
                    DoldurAbout(aboutID);

                    languageCode = "tr-TR";
                    int languageID = (from l in db.Language where l.Code == "tr-TR" select l.ID).FirstOrDefault();
                    Doldur(languageCode, languageID);
                }
                lblMore1.Text = Localization.DahaFazla;
                lblMore2.Text = Localization.DahaFazla;
                lblMore3.Text = Localization.DahaFazla;
                lblServiceTitle.Text = Localization.HizmetBaşlık;
                lblServiceWriting.Text = Localization.HizmetYazı;
                lblSolutionTitle.Text = Localization.ÇözümBaşlık;
                lblSolutionWriting.Text = Localization.ÇözümYazı;
                lblNewsTitle.Text = Localization.HaberBaşlık;
                lblReferenceTitle.Text = Localization.ReferansBaşlık;
                btnService.Text = Localization.DahaFazla;
                btnSolution.Text = Localization.DahaFazla;
                btnNewsDetails.Text = Localization.DahaFazla;
                More = Localization.DahaFazla;

            }
            catch (Exception)
            {

                throw;
            }
            ((MasterPage)this.Master).IndexMenu = "menu-active";
        }

        protected void DoldurAbout(int ID)
        {

            AnalitikBilisimSite.Model.Entities.About about = _aboutService.Get(ID);

            lblAboutTitle.Text = about.Title;
            lblAboutWriting.Text = about.BigWriting;
            lblMissionTitle.Text = about.MissionTitle;
            lblMissionWriting.Text = about.MissionWriting.Length> 200? about.MissionWriting.Substring(0,200): about.MissionWriting;
            lblPlanTitle.Text = about.PlanTitle;
            lblPlanWriting.Text = about.PlanWriting.Length > 200? about.PlanWriting.Substring(0, 200): about.PlanWriting;
            lblVisionTitle.Text = about.VisionTitle;
            lblVisionWriting.Text = about.VisionWriting.Length > 200? about.VisionWriting.Substring(0, 200): about.VisionWriting;
            ImgMission.ImageUrl = about.MissionImage;
            ImgPlan.ImageUrl = about.PlanImage;
            ImgVision.ImageUrl = about.VisionImage;
        }

        protected void Doldur(string code,int ID)
        {
            ListService.DataSource = (from s in db.Services
                                      where s.IsActive == true
                                      join l in db.Language on s.LanguageID equals l.ID
                                      where l.Code == code
                                      orderby s.ID ascending
                                      select new
                                      {
                                          BigWriting = (s.BigWriting.Length > 150) ? s.BigWriting.Substring(0, 149) : s.BigWriting,
                                          Title = s.Title,
                                          Img = s.Image
                                      }).Take(4).ToList();
            ListService.DataBind();

            listReferance.DataSource = (from r in db.Referance
                                        where r.IsActive == true
                                        join l in db.Language on r.LanguageID equals l.ID
                                        where l.Code == code
                                        select r).ToList();
            listReferance.DataBind();

            ListNews.DataSource = (from n in db.News
                                   where n.IsActive == true
                                   join l in db.Language on n.LanguageID equals l.ID
                                   where l.Code == code
                                   orderby n.ID descending
                                   select new
                                   {
                                       SmallWriting = (n.SmallWriting.Length > 150) ? n.SmallWriting.Substring(0, 149) : n.SmallWriting,
                                       Title = n.Title,
                                       Image = n.Image,
                                       ID = n.ID
                                   }).Take(3).ToList();
            ListNews.DataBind();

            ListSolution.DataSource = (from s in db.Solution
                                       where s.IsActive == true
                                       join l in db.Language on s.LanguageID equals l.ID
                                       where l.Code == code
                                       orderby s.ID ascending
                                       select new
                                       {
                                           Title = s.Title,
                                           SmallWriting = (s.SmallWriting.Length > 150) ? s.SmallWriting.Substring(0, 149) : s.SmallWriting
                                       }).Take(4).ToList();
            ListSolution.DataBind();

            int firstSliderID = (from s in db.Slider
                                 where s.IsActive == true
                                 join l in db.Language on s.LanguageID equals l.ID
                                 where l.Code == code
                                 select s.ID).FirstOrDefault();

            AnalitikBilisimSite.Model.Entities.Slider slider1 = (from s in db.Slider where s.ID == (firstSliderID) && s.IsActive == true && s.LanguageID == ID select s).FirstOrDefault();
            AnalitikBilisimSite.Model.Entities.Slider slider2 = (from s in db.Slider where s.ID == (firstSliderID + 1) && s.IsActive == true && s.LanguageID == ID select s).FirstOrDefault();
            AnalitikBilisimSite.Model.Entities.Slider slider3 = (from s in db.Slider where s.ID == (firstSliderID + 2) && s.IsActive == true && s.LanguageID == ID select s).FirstOrDefault();

            ImageSlider1.ImageUrl = slider1.SliderURL;
            lblSliderTitle1.Text = slider1.sliderTitle;
            lblSliderWriting1.Text = slider1.SliderWriting;

            ImageSlider2.ImageUrl = slider2.SliderURL;
            lblSliderTitle2.Text = slider2.sliderTitle;
            lblSliderWriting2.Text = slider2.SliderWriting;

            ImageSlider3.ImageUrl = slider3.SliderURL;
            lblSliderTitle3.Text = slider3.sliderTitle;
            lblSliderWriting3.Text = slider3.SliderWriting;
        }

        protected void btnMission_Click(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx");
        }

        protected void btnService_Click(object sender, EventArgs e)
        {
            Response.Redirect("Services.aspx");
        }

        protected void btnNewsDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("News.aspx");
        }

        protected void btnSolution_Click(object sender, EventArgs e)
        {
            Response.Redirect("Solution.aspx");
        }

        protected void btnNews_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int NewsID = Int32.Parse(btn.CommandArgument);

            Session["news"] = NewsID;
            Response.Redirect("NewsDetails.aspx");
        }

    }
}