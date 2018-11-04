using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class Contact : System.Web.UI.Page
    {
        ContactService _contactService = new ContactService();
        VisitorService _visitorService = new VisitorService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string Map { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int contactID = (from c in db.Contact select c.ID).FirstOrDefault();
                AnalitikBilisimSite.Model.Entities.Contact contact = _contactService.Get(contactID);

                string phone = contact.Phone;
                for (int i = 0; i < phone.Length * 2; i++)
                {
                    if (i == 4 || i == 8 || i == 11)
                    {
                        phone = phone.Insert(i, " ");
                    }
                }

                lblPhone.Text = phone;
                lblMail.Text = contact.Email;
                lblAddress.Text = contact.Address;
                Map = contact.GoogleMap;

                lblContactTitle.Text = Localization.İletişimPage;
                lblAddressTitle.Text = Localization.Adres;
                lblPhoneTitle.Text = Localization.Telefon;
                lblMailTitle.Text = Localization.Mail;
                Name = Localization.İsim;
                Subject = Localization.Konu;
                Message = Localization.Mesaj;
                txtName.Attributes.Add("placeholder", Name);
                txtMail.Attributes.Add("placeholder", Localization.Mail);
                txtSubject.Attributes.Add("placeholder", Subject);
                txtMessage.Attributes.Add("placeholder", Message);
                btnMessage.Text = Localization.MesajGonder;
                lblUyari.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
            ((MasterPage)this.Master).ContactMenu = "menu-active";
        }

        protected void btnMessage_Click(object sender, EventArgs e)
        {
            string FullName = txtName.Value;
            string Mail = txtMail.Value;
            string Subject = txtSubject.Value;
            string Message = txtMessage.Value;

            if (FullName == "" || Mail == "" || Subject == "" || Message == "")
            {
                lblUyari.Text = "Mesajınız gönderilmedi. Lütfen bütün alanları doldurunuz!";
                lblUyari.ForeColor = Color.Red;
                lblUyari.Visible = true;
            }
            else
            {
                Visitor visitor = new Visitor();
                visitor.FullName = FullName;
                visitor.Email = Mail;
                visitor.Subject = Subject;
                visitor.Message = Message;
                visitor.SendTime = DateTime.Now;
                visitor.Readed = false;

                _visitorService.Add(visitor);

                lblUyari.Text = "Mesajınız başarıyla gönderildi. Teşekkür ederiz.";
                lblUyari.ForeColor = Color.Green;
                lblUyari.Visible = true;
                
            }
            clear();

        }
        public void clear()
        {
            txtMail.Value = "";
            txtMessage.Value = "";
            txtName.Value = "";
            txtSubject.Value = "";
        }
    }
}