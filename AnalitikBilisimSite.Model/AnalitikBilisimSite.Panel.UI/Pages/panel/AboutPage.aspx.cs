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
    public partial class AboutPage : System.Web.UI.Page
    {
        AboutService _aboutService = new AboutService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string alert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int aboutID = (from a in db.About select a.ID).FirstOrDefault();
                    About about = _aboutService.Get(aboutID);
                    txtBaslik.Text = about.Title;
                    txtKucukYazi.Text = about.SmallWriting;
                    txtBuyukYazi.Text = about.BigWriting;
                    txtMissionTitle.Text = about.MissionTitle;
                    txtMssionWriting.Text = about.MissionWriting;
                    txtPlanTitle.Text = about.PlanTitle;
                    txtPlanWriting.Text = about.PlanWriting;
                    txtVisionTitle.Text = about.VisionTitle;
                    txtVisionWriting.Text = about.VisionWriting;
                    if (about.Image != "")
                    {
                        string Image = about.Image;
                        string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                        ImgAbout.ImageUrl = subImage;
                        lblInfo.Text = Image;
                    }
                    if (about.MissionImage != "")
                    {
                        string Image = about.MissionImage;
                        string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                        ImageMission.ImageUrl = subImage;
                        lblInfo1.Text = Image;
                    }
                    if (about.PlanImage != "")
                    {
                        string Image = about.PlanImage;
                        string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                        ImagePlan.ImageUrl = subImage;
                        lblInfo2.Text = Image;
                    }
                    if (about.VisionImage != "")
                    {
                        string Image = about.VisionImage;
                        string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                        ImageVision.ImageUrl = subImage;
                        lblInfo3.Text = Image;
                    }
                    //if (!about.IsActive)
                    //{
                    //    RadioButtonList1.Items[1].Selected = true;
                    //}
                    pnlAlert.Visible = false;
                }
                catch (Exception)
                {
                    Uyari("Bilgiler getirilirken bir hata oluştu", false);
                    pnlAlert.Visible = true;
                }
            }
            ((Master)this.Master).Path = "Hakkımızda";
            ((Master)this.Master).PathLink = "AboutPage.aspx";
        }

        protected void btnAbout_Click(object sender, EventArgs e)
        {
            try
            {
                int aboutID = (from a in db.About select a.ID).FirstOrDefault();
                About about = _aboutService.Get(aboutID);
                Users user = (Users)Session["user"];

                about.Title = txtBaslik.Text;
                about.SmallWriting = txtKucukYazi.Text;
                about.BigWriting = txtBuyukYazi.Text;
                about.MissionTitle = txtMissionTitle.Text;
                about.MissionWriting = txtMssionWriting.Text;
                about.PlanTitle = txtPlanTitle.Text;
                about.PlanWriting = txtPlanWriting.Text;
                about.VisionTitle = txtVisionTitle.Text;
                about.VisionWriting = txtVisionWriting.Text;
                about.Image = lblInfo.Text;
                about.MissionImage = lblInfo1.Text;
                about.PlanImage = lblInfo2.Text;
                about.VisionImage = lblInfo3.Text;
                //if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                //{
                //    about.IsActive = true;
                //}
                //else
                //{
                //    about.IsActive = false;
                //}
                about.ModifiedBy = user.ID;
                about.ModifiedDate = DateTime.Now;

                _aboutService.Update(about);

                Uyari("Güncelleme işlemi başarılı", true);
            }
            catch (Exception)
            {
                Uyari("Güncelleme işleminde bir hatayla karşılaşıldı", false);
            }
            pnlAlert.Visible = true;
        }

        protected void btnResim_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string btnName = btn.ID;
            try
            {
                if (flResim.HasFile)
                {
                    FileInfo file = new FileInfo(flResim.FileName);
                    string phisicalPath = HttpContext.Current.Request.PhysicalApplicationPath;
                    string correctPhisicalPath = phisicalPath.Substring(0, phisicalPath.Length - 29) + @"AnalitikBilisimSite.UI\Assets\img\";
                    flResim.SaveAs(correctPhisicalPath + file.Name);
                    flResim.SaveAs(Server.MapPath("img/") + file.Name);

                    Image img = ImgAbout;
                    if (btnName == "btnResim")
                    {
                        img = ImgAbout;
                        lblInfo.Text = "~/Assets/img/" + file.Name;
                    }
                    else if (btnName == "btnMission")
                    {
                        img = ImageMission;
                        lblInfo1.Text = "~/Assets/img/" + file.Name;
                    }
                    else if (btnName == "btnPlan")
                    {
                        img = ImagePlan;
                        lblInfo2.Text = "~/Assets/img/" + file.Name;
                    }
                    else if (btnName == "btnVision")
                    {
                        img = ImageVision;
                        lblInfo3.Text = "~/Assets/img/" + file.Name;
                    }
                    img.ImageUrl = "img/" + file.Name;
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
            pnlAlert.Visible = true;
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

    }
}