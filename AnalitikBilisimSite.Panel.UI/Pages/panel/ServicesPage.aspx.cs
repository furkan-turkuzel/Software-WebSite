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
    public partial class ServicesPage : System.Web.UI.Page
    {
        ServicesService _services = new ServicesService();
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
                ServiceList.DataSource = (from s in db.Services select s).ToList();
                ServiceList.DataBind();
                ((Master)this.Master).Path = "Hizmetler";
                ((Master)this.Master).PathLink = "ServicesPage.aspx";
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
                Services service = new Services();
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                service.Title = txtBaslik.Text;
                service.SmallWriting = txtKucukYazi.Text;
                service.BigWriting = txtBuyukYazi.Text;
                service.Image = lblInfo.Text;
                service.LanguageID = language.ID;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    service.IsActive = true;
                }
                else
                {
                    service.IsActive = false;
                }
                service.CreatedBy = user.ID;
                service.CreatedDate = DateTime.Now;

                _services.Add(service);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Kayıt işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception ex)
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
                Services oldService = _services.Get(ID);
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language
                                     where l.LanguageName == selectLanguage && l.IsActive == true
                                     select l).FirstOrDefault();

                oldService.Title = txtBaslik.Text;
                oldService.SmallWriting = txtKucukYazi.Text;
                oldService.BigWriting = txtBuyukYazi.Text;
                oldService.Image = lblInfo.Text;
                oldService.LanguageID = language.ID;
                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldService.IsActive = true;
                }
                else
                {
                    oldService.IsActive = false;
                }
                oldService.ModifiedBy = user.ID;
                oldService.ModifiedDate = DateTime.Now;

                _services.Update(oldService);

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
            ImgService.ImageUrl = "";
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

                    ImgService.ImageUrl = "img/" + file.Name;
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
                Services service = _services.Get(ID);
                int selectLanguage = service.LanguageID;
                Language language = (from l in db.Language where l.ID == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                txtBaslik.Text = service.Title;
                txtKucukYazi.Text = service.SmallWriting;
                txtBuyukYazi.Text = service.BigWriting;

                if (language.Code == "tr-TR")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                if (service.Image != "")
                {
                    string Image = service.Image;
                    string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                    lblInfo.Text = Image;
                    ImgService.ImageUrl = subImage;
                }
                if (service.IsActive)
                {
                    RadioButtonList1.SelectedIndex = 0;
                }
                else
                {
                    RadioButtonList1.SelectedIndex = 1;
                }
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

                Services oldService = _services.Get(ID);
                _services.Delete(oldService);

                clear();
                panelVisible(true, true, false, false);
                Uyari("Silme işlemi başarıyla gerçekleşti", true);
                Response.Redirect(Request.Url.ToString(), false);
            }
            catch (Exception)
            {
                Uyari("Silme işlemi sırasında bir hata oluştu", false);
            }
        }

        protected void btnSecGuncelle_Click(object sender, EventArgs e)
        {
            panelVisible(false, false, false, true);
        }

        protected void btnSecKaydet_Click(object sender, EventArgs e)
        {
            panelVisible(false, false, true, false);
        }

        protected void ddlFilterLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string languageValue = ddlFilterLanguage.SelectedValue;
                if (languageValue != "0")
                {
                    Language language = (from l in db.Language where l.LanguageName == languageValue select l).FirstOrDefault();

                    ServiceList.DataSource = (from s in db.Services where s.LanguageID == language.ID select s).ToList();
                    ServiceList.DataBind();
                }
                else
                {
                    ServiceList.DataSource = (from s in db.Services select s).ToList();
                    ServiceList.DataBind();
                }
            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
            }
        }
    }
}