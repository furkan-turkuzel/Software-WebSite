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
    public partial class AdminPage : System.Web.UI.Page
    {
        UsersService _userService = new UsersService();
        LanguageService _languageService = new LanguageService();
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
                }
                Users user = (Users)Session["user"];
                AdminList.DataSource = (from u in db.Users where u.ID != user.ID select u).ToList();
                AdminList.DataBind();
                ((Master)this.Master).Path = "Kullanıcılar";
                ((Master)this.Master).PathLink = "AdminPage.aspx";
            }
            catch (Exception)
            {
                Uyari("Bir hata oluştu", false);
                pnlAlert.Visible = true;
            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                Users CurrentUser = (Users)Session["user"];

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
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    user.IsActive = true;
                }
                else
                {
                    user.IsActive = false;
                }

                if (txtPassword.Text == txtPasswordAgain.Text)
                {
                    user.Password = txtPassword.Text;
                }
                else
                {
                    Uyari("Girdiğiniz şifreler aynı değil!", false);
                }

                user.CreatedBy = CurrentUser.ID;
                user.CreatedDate = DateTime.Now;

                _userService.Add(user);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
                Uyari("Kayıt işlemi başarıyla gerçekleşti", true);
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
                    Uyari("Kayıt işlemi sırasında bir hata oluştu", false);
                }
            }

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Int32.Parse(lblInfo2.Text);
                Users oldUser = _userService.Get(ID);
                Users CurrentUser = (Users)Session["user"];

                oldUser.UserName = txtUserName.Text;
                oldUser.FirstName = txtFirstName.Text;
                oldUser.LastName = txtLastName.Text;
                oldUser.Email = txtMail.Text;
                oldUser.Facebook = txtFacebook.Text;
                oldUser.Twitter = txtTwitter.Text;
                oldUser.Instagram = txtInstagram.Text;
                oldUser.Youtube = txtYoutube.Text;
                oldUser.Linkedin = txtLinkedin.Text;
                oldUser.UserImage = lblInfo.Text;
                oldUser.UserRole = drpAdminRole.SelectedItem.Text;
                oldUser.Password = txtPassword.Text;
                if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                {
                    oldUser.IsActive = true;
                }
                else
                {
                    oldUser.IsActive = false;
                }

                oldUser.ModifiedBy = CurrentUser.ID;
                oldUser.ModifiedDate = DateTime.Now;

                _userService.Update(oldUser);

                clear();
                Butonvisible(true);
                panelVisible(true, true, false, false);
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


        protected void btnGuncelleTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = Int32.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                Users user = _userService.Get(ID);

                txtUserName.Text = user.UserName;
                txtUserName.Enabled = false;
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
                if (user.IsActive)
                {
                    RadioButtonList1.SelectedIndex = 0;
                }
                else
                {
                    RadioButtonList1.SelectedIndex = 1;
                }

                foreach (ListItem item in drpAdminRole.Items)
                {
                    if (item.Text == user.UserRole)
                    {
                        drpAdminRole.SelectedItem.Text = user.UserRole;
                    }
                }
                panelVisible(false, false, true, false);
                Butonvisible(false);
            }
            catch (Exception)
            {
                Uyari("Aradığınız veriye ulaşılamadı", false);
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

        public void clear()
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            if (contentPlaceHolder != null)
            {
                foreach (Control c in contentPlaceHolder.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Text = string.Empty;
                }
            }
            drpAdminRole.SelectedItem.Text = "High";
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int harfCount = 0, sayiCount = 0;
            string password = txtPasswordAgain.Text;
            if (password.Length < 6 || password.Length > 15)
            {
                args.IsValid = false;

            }
            foreach (char item in password)
            {
                if (Char.IsDigit(item))
                {
                    harfCount++;
                }
                else if (Char.IsLetter(item))
                {
                    sayiCount++;
                }
            }
            if (sayiCount > 0 && harfCount > 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnSilTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int ID = Int32.Parse(btn.CommandArgument);
                lblInfo2.Text = ID.ToString();

                Users user = _userService.Get(ID);
                _userService.Delete(user);

                clear();
                panelVisible(true, true, false, false);
                Uyari("Silme işlemi başarıyla gerçekleşti", true);
            }
            catch (Exception)
            {
                Uyari("Silme işlemi sırasında bir hata oluştu", false);
            }
        }

    }
}