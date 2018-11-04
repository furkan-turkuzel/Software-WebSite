using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class NewsDetails : System.Web.UI.Page
    {
        NewsService _newsService = new NewsService();
        LanguageService _languageService = new LanguageService();
        AnalitikDBContext db = new AnalitikDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int newsID = Convert.ToInt32(Session["news"]);
                AnalitikBilisimSite.Model.Entities.News news = _newsService.Get(newsID);

                ImgAbout.ImageUrl = news.Image;
                lblTitle.Text = news.Title;
                lblSmallWriting.Text = news.SmallWriting;
                lblBigWriting.Text = news.BigWriting;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}