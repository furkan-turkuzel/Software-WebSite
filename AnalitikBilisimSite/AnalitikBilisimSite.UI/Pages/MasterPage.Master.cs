using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        ContactService _contactService = new ContactService();
        CommonService _commonService = new CommonService();
        NewsService _newsService = new NewsService();
        LanguageService _languageService = new LanguageService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Google { get; set; }
        public string Instagram { get; set; }
        public string KayanHaber { get; set; }
        public string IndexMenu { get; set; }
        public string AboutMenu { get; set; }
        public string ServicesMenu { get; set; }
        public string SolutionMenu { get; set; }
        public string NewsMenu { get; set; }
        public string ReferanceMenu { get; set; }
        public string ContactMenu { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int contactID = (from con in db.Contact select con.ID).FirstOrDefault();
                    int commonID = (from com in db.Common select com.ID).FirstOrDefault();

                    AnalitikBilisimSite.Model.Entities.Contact contact = _contactService.Get(contactID);
                    AnalitikBilisimSite.Model.Entities.Common common = _commonService.Get(commonID);

                    SosyalMedyaLink(contact, common);

                    ImgLogo.ImageUrl = common.Logo;
                    lblFooterAddress.Text = contact.Address;
                    lblFooterMail.Text = contact.Email;
                    lblFooterPhone.Text = contact.Phone;

                    KayanHaber = KayanYaziHaber();

                    ImgEnglish.ImageUrl = (from l in db.Language
                                           where l.Code == "en-EN" && l.IsActive == true
                                           select l.Logo).FirstOrDefault();
                    ImgTurkish.ImageUrl = (from l in db.Language
                                           where l.Code == "tr-TR" && l.IsActive == true
                                           select l.Logo).FirstOrDefault();
                    DropDownMenu();

                    lblAnasayfa.Text = Localization.Anasayfa;
                    lblHakkimizda.Text = Localization.Hakkımızda;
                    lblHizmetlerimiz.Text = Localization.Hizmetlerimiz;
                    lblCozumlerimiz.Text = Localization.Çözümlerimiz;
                    lblHaberler.Text = Localization.Haberler;
                    lblReferanslar.Text = Localization.Referanslar;
                    lblIletişim.Text = Localization.İletişim;
                    lblFooterWriting.Text = Localization.FooterYazı;
                    lblFooterAnasayfa.Text = Localization.Anasayfa;
                    lblFooterHakkimizda.Text = Localization.Hakkımızda;
                    lblFooterHizmetlerimiz.Text = Localization.Hizmetlerimiz;
                    lblFooterCozumlerimiz.Text = Localization.Çözümlerimiz;
                    lblFooterHaberler.Text = Localization.Haberler;
                    lblIletişim.Text = Localization.İletişim;
                    lblAddress.Text = Localization.Adres;
                    lblPhone.Text = Localization.Telefon;
                    lblMail.Text = Localization.Mail;
                    lblFooterNewsTitle.Text = Localization.FooterHaber;
                    lblContactTitle.Text = Localization.İletişim;

                    if ((Language)Session["dil"] != null)
                    {
                        Language language = (Language)Session["dil"];
                        if (language.Code == "tr-TR")
                        {
                            Localization.Culture = new System.Globalization.CultureInfo("");
                        }
                        else
                        {
                            Localization.Culture = new System.Globalization.CultureInfo("en-US");
                        }
                    }
                    else
                    {
                        Localization.Culture = new System.Globalization.CultureInfo("");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

        }

        protected string KayanYaziHaber()
        {
            Language language = (Language)Session["dil"];
            int newsCount = db.News.Count();
            int firstNews = (from n in db.News select n.ID).FirstOrDefault();
            string newsTitles = "";
            for (int i = 0; i < newsCount; i++)
            {
                AnalitikBilisimSite.Model.Entities.News news = _newsService.Get(firstNews + i);
                if (news != null)
                {
                    if (language != null)
                    {
                        if (news.LanguageID == language.ID)
                        {
                            newsTitles += news.Title;
                            newsTitles += "</br></br></br>";
                        }
                    }
                    else
                    {
                        if (news.LanguageID == 1)
                        {
                            newsTitles += news.Title;
                            newsTitles += "</br></br></br>";
                        }
                    }
                }
            }
            return newsTitles;
        }

        protected void SosyalMedyaLink(AnalitikBilisimSite.Model.Entities.Contact contact,Common common)
        {
            try
            {
                Facebook = contact.Facebook;
            }
            catch (Exception)
            {
                Facebook = "#";
            }
            try
            {
                Twitter = contact.Twitter;
            }
            catch (Exception)
            {
                Twitter = "#";
            }
            try
            {
                Youtube = contact.Youtube;
            }
            catch (Exception)
            {
                Youtube = "#";
            }
            try
            {
                Google = contact.Google;
            }
            catch (Exception)
            {
                Google = "#";
            }
            try
            {
                Linkedin = contact.Linkedin;
            }
            catch (Exception)
            {
                Linkedin = "#";
            }
            try
            {
                Instagram = contact.Instagram;
            }
            catch (Exception)
            {
                Instagram = "#";
            }
        }

        protected void ImgEnglish_Click(object sender, ImageClickEventArgs e)
        {
            Localization.Culture = new System.Globalization.CultureInfo("en-US");

            ImageButton imageButton = (ImageButton)sender;
            Language language = (from l in db.Language
                                 where l.Code == "en-EN" && l.IsActive == true
                                 select l).FirstOrDefault();
            Session["dil"] = language;
            Session.Timeout = 2;
            findPath(imageButton);
        }

        protected void ImgTurkish_Click(object sender, ImageClickEventArgs e)
        {
            Localization.Culture = new System.Globalization.CultureInfo("");

            ImageButton imageButton = (ImageButton)sender;
            Language language = (from l in db.Language
                                 where l.Code == "tr-TR" && l.IsActive == true
                                 select l).FirstOrDefault();
            Session["dil"] = language;
            Session.Timeout = 2;
            findPath(imageButton);
        }

        protected void findPath(ImageButton imageButton)
        {
            string path = imageButton.Page.AppRelativeVirtualPath.Substring(8, imageButton.Page.AppRelativeVirtualPath.Length - 8);
            Response.Redirect(path);
        }

        protected void DropDownMenu()
        {
            Language language = (Language)Session["dil"];

            if (language == null)
            {
                MenuList.DataSource = (from s in db.SolutionCategory
                                       where s.LanguageID == 1
                                       select new
                                       {
                                           ID = s.ID,
                                           CategoryName = s.CategoryName
                                       }).ToList();
            }
            else
            {
                MenuList.DataSource = (from s in db.SolutionCategory
                                       where s.LanguageID == language.ID
                                       select new
                                       {
                                           ID = s.ID,
                                           CategoryName = s.CategoryName
                                       }).ToList();
            }
            
            MenuList.DataBind();
        }

        protected void btnDropMenu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int categoryID = Int32.Parse(btn.CommandArgument);
            Session["category"] = categoryID;
            Response.Redirect("Solution.aspx");
        }
    }
}