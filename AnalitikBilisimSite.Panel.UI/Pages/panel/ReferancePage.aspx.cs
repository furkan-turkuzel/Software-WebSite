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
    public partial class ReferancePage : System.Web.UI.Page
    {
        ReferanceService _refService = new ReferanceService();
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

                    ddlFilterReferanceType.DataSource = (from r in db.Referance
                                                         group r.ReferanceType by r.ReferanceType into g
                                                         select g.Key).ToList(); ;
                    ddlFilterReferanceType.DataBind();
                    ddlFilterReferanceType.Items.Insert(0, new ListItem("Referans tipi Seçiniz..", "0"));
                    ddlFilterReferanceType.SelectedIndex = 0;
                }
                RefList.DataSource = (from r in db.Referance select r).ToList();
                RefList.DataBind();
                ((Master)this.Master).Path = "Referanslar";
                ((Master)this.Master).PathLink = "ReferancePage.aspx";
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
                Referance referance = new Referance();
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                referance.ReferanceType = txtRefType.Text;
                referance.ReferanceName = txtRefName.Text;
                referance.ReferancePhone = txtRefPhone.Text;
                referance.ReferanceAddress = txtRefAddress.Text;
                referance.Description = txtDescription.Text;
                referance.ReferanceLogo = lblInfo.Text;
                referance.LanguageID = language.ID;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    referance.IsActive = true;
                }
                else
                {
                    referance.IsActive = false;
                }
                referance.CreatedBy = user.ID;
                referance.CreatedDate = DateTime.Now;

                _refService.Add(referance);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Kayıt işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtRefPhone.Text.Length != 11)
                {
                    Uyari("Telefon 11 haneli olmaz zorundadır!", false);
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
                Referance oldRef = _refService.Get(ID);
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                oldRef.ReferanceType = txtRefType.Text;
                oldRef.ReferanceName = txtRefName.Text;
                oldRef.ReferancePhone = txtRefPhone.Text;
                oldRef.ReferanceAddress = txtRefAddress.Text;
                oldRef.Description = txtDescription.Text;
                oldRef.ReferanceLogo = lblInfo.Text;
                oldRef.LanguageID = language.ID;
                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldRef.IsActive = true;
                }
                else
                {
                    oldRef.IsActive = false;
                }
                oldRef.ModifiedBy = user.ID;
                oldRef.ModifiedDate = DateTime.Now;

                _refService.Update(oldRef);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Güncelleme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtRefPhone.Text.Length != 11)
                {
                    Uyari("Telefon 11 haneli olmaz zorundadır!", false);
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
            ImgRef.ImageUrl = "";
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

                    ImgRef.ImageUrl = "img/" + file.Name;
                    lblInfo.Text = "~/Assets/img/" + file;
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

                AnalitikBilisimSite.Model.Entities.Referance referance = _refService.Get(ID);
                int selectLanguage = referance.LanguageID;
                Language language = (from l in db.Language
                                     where l.ID == selectLanguage && l.IsActive == true
                                     select l).FirstOrDefault();

                txtRefType.Text = referance.ReferanceType;
                txtRefName.Text = referance.ReferanceName;
                txtRefPhone.Text = referance.ReferancePhone;
                txtRefAddress.Text = referance.ReferanceAddress;
                txtDescription.Text = referance.Description;

                if (language.Code == "tr-TR")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                if (referance.ReferanceLogo != "")
                {
                    string Image = referance.ReferanceLogo;
                    string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                    lblInfo.Text = Image;
                    ImgRef.ImageUrl = subImage;
                }
                if (referance.IsActive)
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

                Referance oldRef = _refService.Get(ID);
                _refService.Delete(oldRef);

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

        protected void ddlFilterReferanceType_SelectedIndexChanged(object sender, EventArgs e)
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
            string refValue = ddlFilterReferanceType.SelectedValue;
            if (languageValue != "0" && refValue != "0")
            {
                Language language = (from l in db.Language
                                     where l.LanguageName == languageValue
                                     select l).FirstOrDefault();

                RefList.DataSource = (from r in db.Referance
                                      where r.LanguageID == language.ID
                                      && r.ReferanceType == refValue
                                      select r).ToList();
                RefList.DataBind();
            }
            else if (languageValue != "0" && refValue == "0")
            {
                Language language = (from l in db.Language
                                     where l.LanguageName == languageValue
                                     select l).FirstOrDefault();

                RefList.DataSource = (from r in db.Referance
                                      where r.LanguageID == language.ID
                                      select r).ToList();
                RefList.DataBind();
            }
            else if (languageValue == "0" && refValue != "0")
            {
                RefList.DataSource = (from r in db.Referance
                                      where r.ReferanceType == refValue
                                      select r).ToList();
                RefList.DataBind();
            }
            else
            {
                RefList.DataSource = (from r in db.Referance
                                      select r).ToList();
                RefList.DataBind();
            }
        }
    }
}