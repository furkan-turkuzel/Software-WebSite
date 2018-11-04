using AnalitikBilisimSite.BLL.Concrete;
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
    public partial class ProfilePage : System.Web.UI.Page
    {
        UsersService _userService = new UsersService();
        public string alert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Users user = (Users)Session["user"];
                    lblInfo2.Text = ID.ToString();

                    txtUserName.Text = user.UserName;
                    txtFirstName.Text = user.FirstName;
                    txtLastName.Text = user.LastName;
                    txtMail.Text = user.Email;
                    txtFacebook.Text = user.Facebook;
                    txtTwitter.Text = user.Twitter;
                    txtInstagram.Text = user.Instagram;
                    txtYoutube.Text = user.Youtube;
                    txtLinkedin.Text = user.Linkedin;
                    if (user.UserImage != "")
                    {
                        string Image = user.UserImage;
                        lblInfo.Text = Image;
                        ImgAdmin.ImageUrl = Image;
                    }
                    //if (!user.IsActive)
                    //{
                    //    RadioButtonList1.Items[1].Selected = true;
                    //}

                    foreach (ListItem item in drpAdminRole.Items)
                    {
                        if (item.Text == user.UserRole)
                        {
                            drpAdminRole.SelectedItem.Text = user.UserRole;
                        }
                    }
                }
                catch (Exception)
                {
                    Uyari("Aradığınız veriye ulaşılamadı", false);
                }
            }
            ((Master)this.Master).Path = "Profil";
            ((Master)this.Master).PathLink = "ProfilePage.aspx";
        }

        protected void btnResim_Click(object sender, EventArgs e)
        {
            try
            {
                if (flResim.HasFile)
                {
                    FileInfo file = new FileInfo(flResim.FileName);
                    flResim.SaveAs(Server.MapPath("img/") + file.Name);

                    ImgAdmin.ImageUrl = "img/" + file.Name;
                    lblInfo.Text = "img/" + file.Name;
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

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = (Users)Session["user"];

                user.UserName = txtUserName.Text;
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.Email = txtMail.Text;
                user.Facebook = txtFacebook.Text;
                user.Twitter = txtTwitter.Text;
                user.Instagram = txtInstagram.Text;
                user.Youtube = txtYoutube.Text;
                user.Linkedin = txtLinkedin.Text;
                user.UserImage = lblInfo.Text;
                user.UserRole = drpAdminRole.SelectedItem.Text;
                //if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                //{
                //    user.IsActive = true;
                //}
                //else
                //{
                //    user.IsActive = false;
                //}

                if (txtPassword.Text == txtPasswordAgain.Text)
                {
                    user.Password = txtPassword.Text;
                }
                else
                {
                    Uyari("Girdiğiniz şifreler aynı değil!", false);
                }

                user.ModifiedBy = user.ID;
                user.ModifiedDate = DateTime.Now;

                Uyari("Güncelleme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                if (txtUserName.Text.Length > 50)
                {
                    Uyari("Kullanıcı adı 50 karakterden daha uzun girilemez!", false);
                }
                else if (txtFirstName.Text.Length > 30)
                {
                    Uyari("İsim 30 karakterden daha uzun girilemez!", false);
                }
                else if (txtLastName.Text.Length > 40)
                {
                    Uyari("Soyisim 40 karakterden daha uzun girilemez!", false);
                }
                else
                {
                    Uyari("Güncelleme işlemi sırasında bir hata oluştu", false);
                }
            }

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
