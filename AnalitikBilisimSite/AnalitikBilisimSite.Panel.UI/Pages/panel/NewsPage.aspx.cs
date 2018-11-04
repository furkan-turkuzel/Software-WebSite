using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.Panel.UI.Pages.panel
{
    public partial class NewsPage : System.Web.UI.Page
    {
        NewsService _news = new NewsService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string alert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Butonvisible(true);
                    panelVisible(false, true, false, false);
                    List<string> languageList = (from l in db.Language
                                              where l.IsActive == true
                                              select l.LanguageName).ToList();
                    ddlLanguage.DataSource = languageList;
                    ddlLanguage.DataBind();
                    ddlFilterLanguage.DataSource = languageList;
                    ddlFilterLanguage.DataBind();
                    ddlFilterLanguage.Items.Insert(0, new ListItem("Dil Seçiniz..", "0"));
                    ddlFilterLanguage.SelectedIndex = 0;
                }
                NewsList.DataSource = (from n in db.News select n).ToList();
                NewsList.DataBind();
                ((Master)this.Master).Path = "Haberler";
                ((Master)this.Master).PathLink = "NewsPage.aspx";
            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
            }
            
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                News news = new News();
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();
                Users newsUser = (Users)Session["user"];

                news.Title = txtBaslik.Text;
                news.SmallWriting = txtKucukYazi.Text;
                news.BigWriting = txtBuyukYazi.Text;
                news.Image = lblInfo.Text;
                news.NewsDate = DateTime.Now;
                news.UserID = newsUser.ID;
                news.LanguageID = language.ID;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    news.IsActive = true;
                }
                else
                {
                    news.IsActive = false;
                }
                news.CreatedBy = newsUser.ID;
                news.CreatedDate = DateTime.Now;

                _news.Add(news);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Kayıt işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtBaslik.Text.Length > 100)
                {
                    Uyari("Başlık 100 karakterden daha uzun girilemez!", false);
                }
                else if (txtKucukYazi.Text.Length > 500)
                {
                    Uyari("Küçük yazı 500 karakterden daha uzun girilemez!", false);
                }
                else
                {
                    Uyari("Kayıt işlemi sırasında bir hata oluştu", false);
                }
            }

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(lblInfo2.Text);
                News oldNews = _news.Get(ID);
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language
                                     where l.LanguageName == selectLanguage && l.IsActive == true
                                     select l).FirstOrDefault();

                oldNews.Title = txtBaslik.Text;
                oldNews.SmallWriting = txtKucukYazi.Text;
                oldNews.BigWriting = txtBuyukYazi.Text;
                oldNews.Image = lblInfo.Text;
                oldNews.NewsDate = DateTime.Now;
                oldNews.UserID = user.ID;
                oldNews.LanguageID = language.ID;
                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldNews.IsActive = true;
                }
                else
                {
                    oldNews.IsActive = false;
                }
                oldNews.ModifiedBy = user.ID;
                oldNews.ModifiedDate = DateTime.Now;

                _news.Update(oldNews);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Güncelleme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtBaslik.Text.Length > 100)
                {
                    Uyari("Başlık 100 karakterden daha uzun girilemez!", false);
                }
                else if (txtKucukYazi.Text.Length > 500)
                {
                    Uyari("Küçük yazı 500 karakterden daha uzun girilemez!", false);
                }
                else
                {
                    Uyari("Güncelleme işlemi sırasında bir hata oluştu", false);
                }
            }

        }
        public void clear()
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            if (contentPlaceHolder != null)
            {
                TextBox t;
                foreach (Control c in contentPlaceHolder.Controls)
                {
                    if (c.GetType() == typeof(System.Web.UI.WebControls.Panel))
                        foreach (Control item in c.Controls)
                        {
                            if (item.GetType() == typeof(System.Web.UI.WebControls.TextBox))
                            {
                                t = (TextBox)item;
                                t.Text = string.Empty;
                            }

                        }
                }
            }
            ImgNews.ImageUrl = "";
        }

        public void Butonvisible(bool visibleChoose)
        {
            btnKaydet.Visible = visibleChoose;
            btnGuncelle.Visible = !visibleChoose;
        }

        public void panelVisible(bool alert, bool sec, bool islem, bool Guncelle)
        {
            pnlAlert.Visible = alert;
            pnlSec.Visible = sec;
            pnlIslem.Visible = islem;
            pnlGuncelle.Visible = Guncelle;
        }

        public void Uyari(string Warning, Boolean Color)
        {
            lblUyari.Text = Warning;
            if (Color == true)
            {
                alert = "success";
            }
            else
            {
                alert = "danger";
            }
            pnlAlert.Visible = true;
        }

        protected void btnResim_Click(object sender, EventArgs e)
        {
            try
            {
                if (flResim.HasFile)
                {
                    FileInfo file = new FileInfo(flResim.FileName);
                    string phisicalPath = HttpContext.Current.Request.PhysicalApplicationPath;
                    string correctPhisicalPath = phisicalPath.Substring(0, phisicalPath.Length - 29) + @"AnalitikBilisimSite.UI\Assets\img\";
                    flResim.SaveAs(correctPhisicalPath + file.Name);
                    flResim.SaveAs(Server.MapPath("img/") + file.Name);

                    ImgNews.ImageUrl = "img/" + file.Name;
                    lblInfo.Text = "~/Assets/img/" + file.Name;
                    panelVisible(false, false, true, false);
                }
                else
                {
                    Uyari("Lütfen bir resim seçiniz", false);
                }
            }
            catch (Exception)
            {
                Uyari("Resim seçme işleminde bir hatayla karşılaşıldı", false);
            }

        }

        protected void btnGuncelleTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = int.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                PageLoad(ID);

                panelVisible(false, false, true, false);
                Butonvisible(false);
            }
            catch (Exception)
            {
                Uyari("Aradığınız veriye ulaşılamadı", false);
            }
        }

        protected void btnSilTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = Int32.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                News oldNews = _news.Get(ID);
                _news.Delete(oldNews);

                clear();
                panelVisible(true, true, false, false);
                Uyari("Silme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                Uyari("Silme işlemi sırasında bir hata oluştu", false);
            }
        }

        protected void btnSecKaydet_Click(object sender, EventArgs e)
        {
            panelVisible(false, false, true, false);
        }

        protected void btnSecGuncelle_Click(object sender, EventArgs e)
        {
            panelVisible(false, false, false, true);
        }

        protected void PageLoad(int ID)
        {
            try
            {
                News news = _news.Get(ID);
                int selectLanguage = news.LanguageID;
                Language language = (from l in db.Language where l.ID == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                txtBaslik.Text = news.Title;
                txtKucukYazi.Text = news.SmallWriting;
                txtBuyukYazi.Text = news.BigWriting;

                if (language.Code == "tr-TR")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                if (news.Image != "")
                {
                    string Image = news.Image;
                    string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                    lblInfo.Text = Image;
                    ImgNews.ImageUrl = subImage;
                }
                if (news.IsActive)
                {
                    RadioButtonList1.SelectedIndex = 0;
                }
                else
                {
                    RadioButtonList1.SelectedIndex = 1;
                }

            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
            }
        }

        protected void ddlFilterLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string languageValue = ddlFilterLanguage.SelectedValue;
                if (languageValue != "0")
                {
                    Language language = (from l in db.Language where l.LanguageName == languageValue select l).FirstOrDefault();

                    NewsList.DataSource = (from n in db.News where n.LanguageID == language.ID select n).ToList();
                    NewsList.DataBind();
                }
                else
                {
                    NewsList.DataSource = (from n in db.News select n).ToList();
                    NewsList.DataBind();
                }
            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
            }
        }

        //protected void btnSil_Click(object sender, EventArgs e)
        //{
        //    int a = Int32.Parse(HiddenField1.Value);
        //    try
        //    {
        //        Button btn = (Button)sender;
        //        int ID = Int32.Parse(btn.CommandArgument);
        //        lblInfo2.Text = ID.ToString();

        //        News oldNews = _news.Get(ID);
        //        _news.Delete(oldNews);

        //        clear();
        //        panelVisible(true, false, false, true);
        //        Uyari("Silme işlemi başarıyla gerçekleşti", true);
        //    }
        //    catch (Exception)
        //    {
        //        Uyari("Silme işlemi sırasında bir hata oluştu", false);
        //    }
        //}
    }
}