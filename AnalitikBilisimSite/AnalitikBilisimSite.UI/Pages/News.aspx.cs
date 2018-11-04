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
    public partial class News : System.Web.UI.Page
    {
        NewsService _NewsService = new NewsService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string More { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AnalitikBilisimSite.Model.Entities.Language language = (Language)Session["dil"];
                string languageCode;
                if (language != null)
                {
                    languageCode = language.Code;
                    Doldur(languageCode);
                }
                else
                {
                    languageCode = "tr-TR";
                    Doldur(languageCode);
                }
                More = Localization.DahaFazla;
                lblNewsTitle.Text = Localization.Haberler;
            }
            catch (Exception)
            {

                throw;
            }
            ((MasterPage)this.Master).NewsMenu = "menu-active";
        }

        protected void Doldur(string Code)
        {
            int newsID = (from n in db.News
                          where n.IsActive == true
                          join l in db.Language on n.LanguageID equals l.ID
                          where l.Code == Code
                          select n.ID).FirstOrDefault();

            if (newsID == 0)
            {
                Code = "tr-TR";
            }
            ListNews.DataSource = (from n in db.News
                                   where n.IsActive == true
                                   join l in db.Language on n.LanguageID equals l.ID
                                   where l.Code == Code
                                   orderby n.ID descending
                                   select new
                                   {
                                       BigWriting = (n.BigWriting.Length > 180) ? n.SmallWriting.Substring(0, 179) : n.SmallWriting,
                                       Title = n.Title,
                                       Image = n.Image,
                                       ID = n.ID
                                   }).ToList();

            ListNews.DataBind();
        }
        protected void btnNews_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int newsID = Int32.Parse(btn.CommandArgument);

            Session["news"] = newsID;
            Response.Redirect("NewsDetails.aspx");
        }
    }
}