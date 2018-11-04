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
    public partial class SolutionCategoryPage : System.Web.UI.Page
    {
        SolutionCategoryService _categoryService = new SolutionCategoryService();
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
                CategoryList.DataSource = (from sc in db.SolutionCategory select sc).ToList();
                CategoryList.DataBind();
                ((Master)this.Master).Path = "Çözüm Kategori";
                ((Master)this.Master).PathLink = "SolutionCategoryPage.aspx";
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
                SolutionCategory category = new SolutionCategory();
                Users newsUser = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                category.CategoryName = txtCategoryName.Text;
                category.LanguageID = language.ID;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    category.IsActive = true;
                }
                else
                {
                    category.IsActive = false;
                }
                category.CreatedBy = newsUser.ID;
                category.CreatedDate = DateTime.Now;

                _categoryService.Add(category);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Kayıt işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtCategoryName.Text.Length > 50)
                {
                    Uyari("Kategori adı 50 karakterden daha uzun girilemez!", false);
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
                SolutionCategory oldCategory = _categoryService.Get(ID);
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                oldCategory.CategoryName = txtCategoryName.Text;
                oldCategory.LanguageID = language.ID;

                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldCategory.IsActive = true;
                }
                else
                {
                    oldCategory.IsActive = false;
                }
                oldCategory.ModifiedBy = user.ID;
                oldCategory.ModifiedDate = DateTime.Now;

                _categoryService.Update(oldCategory);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Güncelleme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtCategoryName.Text.Length > 50)
                {
                    Uyari("Kategori adı 50 karakterden daha uzun girilemez!", false);
                }
                else
                {
                    Uyari("Güncelleme işlemi sırasında bir hata oluştu", false);
                }
            }
        }


        protected void btnGuncelleTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = int.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                SolutionCategory category = _categoryService.Get(ID);
                int selectLanguage = category.LanguageID;
                Language language = (from l in db.Language where l.ID == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                txtCategoryName.Text = category.CategoryName;

                if (language.Code == "tr-TR")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                if (category.IsActive)
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
                lblInfo2.Text = ID.ToString();

                SolutionCategory oldCategory = _categoryService.Get(ID);
                _categoryService.Delete(oldCategory);

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

        protected void ddlFilterLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string languageValue = ddlFilterLanguage.SelectedValue;
                if (languageValue != "0")
                {
                    Language language = (from l in db.Language where l.LanguageName == languageValue select l).FirstOrDefault();

                    CategoryList.DataSource = (from c in db.SolutionCategory where c.LanguageID == language.ID select c).ToList();
                    CategoryList.DataBind();
                }
                else
                {
                    CategoryList.DataSource = (from c in db.SolutionCategory select c).ToList();
                    CategoryList.DataBind();
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