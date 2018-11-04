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
    public partial class SolutionPage : System.Web.UI.Page
    {
        SolutionService _solutionService = new SolutionService();
        AnalitikDBContext db = new AnalitikDBContext();
        List<string> categoryList = new List<string>();
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
                    languageList.Insert(0, "Dil Seçiniz..");
                    ddlLanguage.DataSource = languageList;
                    ddlLanguage.DataBind();

                    ddlFilterLanguage.DataSource = languageList;
                    ddlFilterLanguage.DataBind();

                    if (ddlFilterLanguage.SelectedValue != "Dil Seçiniz..")
                    {
                        Language currentLanguage = (from l in db.Language
                                                    where l.LanguageName == ddlFilterLanguage.SelectedValue
                                                    select l).FirstOrDefault();

                        categoryList = (from sc in db.SolutionCategory
                                        where sc.LanguageID == currentLanguage.ID
                                        group sc.CategoryName by sc.CategoryName into g
                                        select g.Key).ToList();
                    }
                    else
                    {
                        categoryList = (from sc in db.SolutionCategory
                                        group sc.CategoryName by sc.CategoryName into g
                                        select g.Key).ToList();
                    }
                    categoryList.Insert(0, "Kategori Seçiniz..");

                    ddlFilterCategory.DataSource = categoryList;
                    ddlFilterCategory.DataBind();

                    ddlSolution.DataSource = categoryList;
                    ddlSolution.DataBind();

                    solutionList.DataSource = (from s in db.Solution select s).ToList();
                    solutionList.DataBind();
                }

                ((Master)this.Master).Path = "Çözümler";
                ((Master)this.Master).PathLink = "SolutionPage.aspx";
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
                Solution solution = new Solution();
                Users user = (Users)Session["user"];
                int categoryID = (from sc in db.SolutionCategory where sc.CategoryName == ddlSolution.SelectedItem.Text select sc.ID).FirstOrDefault();
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                solution.Title = txtBaslik.Text;
                solution.SmallWriting = txtKucukYazi.Text;
                solution.BigWriting = txtBuyukYazi.Text;
                solution.Image = lblInfo.Text;
                solution.CategoryID = categoryID;
                solution.LanguageID = language.ID;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    solution.IsActive = true;
                }
                else
                {
                    solution.IsActive = false;
                }
                solution.CreatedBy = user.ID;
                solution.CreatedDate = DateTime.Now;

                _solutionService.Add(solution);

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
                Solution oldSolution = _solutionService.Get(ID);
                Users user = (Users)Session["user"];
                int categoryID = (from sc in db.SolutionCategory where sc.CategoryName == ddlSolution.SelectedItem.Text select sc.ID).FirstOrDefault();
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                oldSolution.Title = txtBaslik.Text;
                oldSolution.SmallWriting = txtKucukYazi.Text;
                oldSolution.BigWriting = txtBuyukYazi.Text;
                oldSolution.Image = lblInfo.Text;
                oldSolution.CategoryID = categoryID;
                oldSolution.LanguageID = language.ID;
                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldSolution.IsActive = true;
                }
                else
                {
                    oldSolution.IsActive = false;
                }
                oldSolution.ModifiedBy = user.ID;
                oldSolution.ModifiedDate = DateTime.Now;

                _solutionService.Update(oldSolution);

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
            ImgSolution.ImageUrl = "";
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

                    ImgSolution.ImageUrl = "img/" + file.Name;
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
                Solution solution = _solutionService.Get(ID);
                int selectLanguage = solution.LanguageID;
                Language language = (from l in db.Language
                                     where l.ID == selectLanguage && l.IsActive == true
                                     select l).FirstOrDefault();

                txtBaslik.Text = solution.Title;
                txtKucukYazi.Text = solution.SmallWriting;
                txtBuyukYazi.Text = solution.BigWriting;
                ddlSolution.SelectedValue = (from sc in db.SolutionCategory where sc.ID == solution.CategoryID select sc.CategoryName).FirstOrDefault();

                if (language.Code == "tr-TR")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                if (solution.Image != "")
                {
                    string Image = solution.Image;
                    string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                    lblInfo.Text = Image;
                    ImgSolution.ImageUrl = subImage;
                }
                if (solution.IsActive)
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

                Solution oldSolution = _solutionService.Get(ID);
                _solutionService.Delete(oldSolution);

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

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectLanguage = ddlLanguage.SelectedItem.Text;
            Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

            List<string> categoryList = (from sc in db.SolutionCategory
                                         where sc.LanguageID == language.ID
                                         && sc.IsActive == true
                                         select sc.CategoryName).ToList();
            categoryList.Insert(0, "Kategori Seçiniz..");

            ddlSolution.DataSource = categoryList;
            ddlSolution.DataBind();
        }

        protected void ddlFilterLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                filter();
            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
            }
        }

        protected void ddlFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                filter();
            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
            }
        }

        protected void filter()
        {
            string languageValue = ddlFilterLanguage.SelectedValue;
            string solutionValue = ddlFilterCategory.SelectedValue;

            Language language = (from l in db.Language
                                 where l.LanguageName == languageValue
                                 select l).FirstOrDefault();

            SolutionCategory category = (from sc in db.SolutionCategory
                                         where sc.CategoryName == solutionValue
                                         select sc).FirstOrDefault();
            if (languageValue != "Dil Seçiniz.." && solutionValue != "Kategori Seçiniz..")
            {
                solutionList.DataSource = (from s in db.Solution
                                           where s.LanguageID == language.ID
                                           && s.CategoryID == category.ID
                                           select s).ToList();
                solutionList.DataBind();
            }
            else if (languageValue != "Dil Seçiniz.." && solutionValue == "Kategori Seçiniz..")
            {
                solutionList.DataSource = (from s in db.Solution
                                           where s.LanguageID == language.ID
                                           select s).ToList();
                solutionList.DataBind();

                List<string> categoryList = (from sc in db.SolutionCategory
                                             where sc.LanguageID == language.ID
                                             select sc.CategoryName).ToList();
                categoryList.Insert(0, "Kategori Seçiniz..");

                ddlFilterCategory.DataSource = categoryList; 
                ddlFilterCategory.DataBind();
            }
            else if (languageValue == "Dil Seçiniz.." && solutionValue != "Kategori Seçiniz..")
            {
                solutionList.DataSource = (from s in db.Solution
                                           where s.CategoryID == category.ID
                                           select s).ToList();
                solutionList.DataBind();

                List<string> categoryList = (from sc in db.SolutionCategory
                                             select sc.CategoryName).ToList();
                categoryList.Insert(0, "Kategori Seçiniz..");

                ddlFilterCategory.DataSource = categoryList;
                ddlFilterCategory.DataBind();
            }
            else
            {
                solutionList.DataSource = (from s in db.Solution
                                           select s).ToList();
                solutionList.DataBind();
            }
        }
    }
}