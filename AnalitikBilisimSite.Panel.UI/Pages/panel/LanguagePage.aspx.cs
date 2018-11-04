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
    public partial class LanguagePage : System.Web.UI.Page
    {
        LanguageService _languageService = new LanguageService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string alert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Butonvisible(true);
                panelVisible(false, true, false, false);
                RefList.DataSource = (from l in db.Language select l).ToList();
                RefList.DataBind();
            }
            ((Master)this.Master).Path = "Diller";
            ((Master)this.Master).PathLink = "LanguagePage.aspx";
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Language language = new Language();
                Users user = (Users)Session["user"];

                language.Code = txtCode.Text;
                language.LanguageName = txtLanguage.Text;
                language.Logo = lblInfo.Text;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    language.IsActive = true;
                }
                else
                {
                    language.IsActive = false;
                }
                language.CreatedBy = user.ID;
                language.CreatedDate = DateTime.Now;

                _languageService.Add(language);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Kayıt işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                Uyari("Kayıt işlemi sırasında bir hata oluştu", false);
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(lblInfo2.Text);
                Language oldLanguage = _languageService.Get(ID);
                Users user = (Users)Session["user"];

                oldLanguage.Code = txtCode.Text;
                oldLanguage.LanguageName = txtLanguage.Text;
                oldLanguage.Logo = lblInfo.Text;
                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldLanguage.IsActive = true;
                }
                else
                {
                    oldLanguage.IsActive = false;
                }
                oldLanguage.ModifiedBy = user.ID;
                oldLanguage.ModifiedDate = DateTime.Now;

                _languageService.Update(oldLanguage);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Güncelleme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                Uyari("Güncelleme işlemi sırasında bir hata oluştu", false);
            }
        }

        protected void btnGuncelleTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = int.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();
                Language language = _languageService.Get(ID);

                txtLanguage.Text = language.LanguageName;
                txtCode.Text = language.Code;
                txtCode.Enabled = false;
                if (language.Logo != null)
                {
                    string Image = language.Logo;
                    string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                    lblInfo.Text = Image;
                    ImgLanguage.ImageUrl = subImage;
                }
                if (language.IsActive)
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
                int ID = int.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                Language oldLanguage = _languageService.Get(ID);
                _languageService.Delete(oldLanguage);

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

        public void clear()
        {
            txtCode.Text = "";
            txtLanguage.Text = "";
            ImgLanguage.ImageUrl = "";
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

                    ImgLanguage.ImageUrl = "img/" + file.Name;
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
    }
}