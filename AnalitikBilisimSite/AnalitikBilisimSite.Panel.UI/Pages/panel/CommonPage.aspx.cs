using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using AnalitikBilisimSite.Panel.UI.Pages.panel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class CommonPage : System.Web.UI.Page
    {
        CommonService _commonService = new CommonService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string alert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int commonID = (from com in db.Common select com.ID).FirstOrDefault();
                    Common common = _commonService.Get(commonID);
                    txtCompanyName.Text = common.CompanyName;
                    txtURL.Text = common.URL;
                    if (common.Logo != "")
                    {
                        string Image = common.Logo;
                        string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                        ImgCommon.ImageUrl = subImage;
                        lblInfo.Text = Image;
                    }
                    //if (!common.IsActive)
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
            ((Master)this.Master).Path = "Genel";
            ((Master)this.Master).PathLink = "CommonPage.aspx";
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int commonID = (from com in db.Common select com.ID).FirstOrDefault();
                Common common = _commonService.Get(commonID);
                Users currentUser = (Users)Session["user"];

                common.CompanyName = txtCompanyName.Text;
                common.URL = txtURL.Text;
                common.Logo = lblInfo.Text;
                //if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                //{
                //    common.IsActive = true;
                //}
                //else
                //{
                //    common.IsActive = false;
                //}
                common.ModifiedBy = currentUser.ID;
                common.ModifiedDate = DateTime.Now;

                _commonService.Update(common);

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
            try
            {
                if (flResim.HasFile)
                {
                    FileInfo file = new FileInfo(flResim.FileName);
                    string phisicalPath = HttpContext.Current.Request.PhysicalApplicationPath;
                    string correctPhisicalPath = phisicalPath.Substring(0, phisicalPath.Length - 29) + @"AnalitikBilisimSite.UI\Assets\img\";
                    flResim.SaveAs(correctPhisicalPath + file.Name);
                    flResim.SaveAs(Server.MapPath("img/") + file.Name);

                    ImgCommon.ImageUrl = "img/" + file.Name;
                    lblInfo.Text = "~/Assets/img/" + file.Name;
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