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
    public partial class SliderPage : System.Web.UI.Page
    {
        SliderService _sliderService = new SliderService();
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
                SliderList.DataSource = (from s in db.Slider select s).ToList();
                SliderList.DataBind();
                ((Master)this.Master).Path = "Slider";
                ((Master)this.Master).PathLink = "SliderPage.aspx";
            }
            catch (Exception)
            {
                Uyari("Bir Hata Oluştu!", false);
                pnlAlert.Visible = true;
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

        protected void btnGuncelleTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = int.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                Slider slider = _sliderService.Get(ID);
                int selectLanguage = slider.LanguageID;
                Language language = (from l in db.Language where l.ID == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                txtBaslik.Text = slider.sliderTitle;
                txtYazi.Text = slider.SliderWriting;

                if (language.Code == "tr-TR")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }

                if (slider.SliderURL != "")
                {
                    string Image = slider.SliderURL;
                    string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                    lblInfo.Text = Image;
                    ImgSlider.ImageUrl = subImage;
                }
                if (slider.IsActive)
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

                Slider oldSlider = _sliderService.Get(ID);
                _sliderService.Delete(oldSlider);

                clear();
                panelVisible(true, true, false, false);
                Uyari("Silme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                Uyari("Silme işlemi sırasında bir hata oluştu", false);
            }
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

                    ImgSlider.ImageUrl = "img/" + file.Name;
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

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Slider slider = new Slider();
                Users newsUser = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                slider.sliderTitle = txtBaslik.Text;
                slider.SliderWriting = txtYazi.Text;
                slider.SliderURL = lblInfo.Text;
                slider.LanguageID = language.ID;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    slider.IsActive = true;
                }
                else
                {
                    slider.IsActive = false;
                }
                slider.CreatedBy = newsUser.ID;
                slider.CreatedDate = DateTime.Now;

                _sliderService.Add(slider);

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
                Slider oldSlider = _sliderService.Get(ID);
                Users user = (Users)Session["user"];
                string selectLanguage = ddlLanguage.SelectedItem.Text;
                Language language = (from l in db.Language where l.LanguageName == selectLanguage && l.IsActive == true select l).FirstOrDefault();

                oldSlider.sliderTitle = txtBaslik.Text;
                oldSlider.SliderWriting = txtYazi.Text;
                oldSlider.SliderURL = lblInfo.Text;
                oldSlider.LanguageID = language.ID;
                if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldSlider.IsActive = true;
                }
                else
                {
                    oldSlider.IsActive = false;
                }
                oldSlider.ModifiedBy = user.ID;
                oldSlider.ModifiedDate = DateTime.Now;

                _sliderService.Update(oldSlider);

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
            ImgSlider.ImageUrl = "";
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

                    SliderList.DataSource = (from s in db.Slider where s.LanguageID == language.ID select s).ToList();
                    SliderList.DataBind();
                }
                else
                {
                    SliderList.DataSource = (from s in db.Slider select s).ToList();
                    SliderList.DataBind();
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