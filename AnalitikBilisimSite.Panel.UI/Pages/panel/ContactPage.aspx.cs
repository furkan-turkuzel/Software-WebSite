using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.Panel.UI.Pages.panel
{
    public partial class ContactPage : System.Web.UI.Page
    {
        ContactService _contact = new ContactService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string alert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int contactID = (from con in db.Contact select con.ID).FirstOrDefault();
                    Contact contact = _contact.Get(contactID);

                    txtPhone.Text = contact.Phone;
                    txtFax.Text = contact.Fax;
                    txtMail.Text = contact.Email;
                    txtAddress.Text = contact.Address;
                    txtFacebook.Text = contact.Facebook;
                    txtTwitter.Text = contact.Twitter;
                    txtInstagram.Text = contact.Instagram;
                    txtYoutube.Text = contact.Youtube;
                    txtLinkedin.Text = contact.Linkedin;
                    txtGoogle.Text = contact.Google;
                    txtMap.Text = contact.GoogleMap;
                    
                    //if (!contact.IsActive)
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
            ((Master)this.Master).Path = "İletişim";
            ((Master)this.Master).PathLink = "ContactPage.aspx";
        }

        protected void btnAbout_Click(object sender, EventArgs e)
        {
            try
            {
                int contactID = (from con in db.Contact select con.ID).FirstOrDefault();
                Contact contact = _contact.Get(contactID);
                Users user = (Users)Session["user"];

                contact.Phone = txtPhone.Text;
                contact.Email = txtMail.Text;
                contact.Address = txtAddress.Text;
                contact.Fax = txtFax.Text;
                contact.Facebook = txtFacebook.Text;
                contact.Twitter = txtTwitter.Text;
                contact.Instagram = txtInstagram.Text;
                contact.Youtube = txtYoutube.Text;
                contact.Linkedin = txtLinkedin.Text;
                contact.Google = txtGoogle.Text;
                contact.GoogleMap = txtMap.Text;
                //if (Int32.Parse(RadioButtonList1.SelectedItem.Value) == 1)
                //{
                //    contact.IsActive = true;
                //}
                //else
                //{
                //    contact.IsActive = false;
                //}
                contact.ModifiedBy = user.ID;
                contact.ModifiedDate = DateTime.Now;

                _contact.Update(contact);

                Uyari("Güncelleme işlemi başarılı", true);
            }
            catch (Exception)
            {
                if (txtPhone.Text.Length != 11)
                {
                    Uyari("Telefon 11 haneli olmaz zorundadır!", false);
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