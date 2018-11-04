using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.ConstructionPage
{
    public partial class UnderConstruction : System.Web.UI.Page
    {
        ContactService _contactService = new ContactService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
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
            lblAddress.Text = contact.Address;
            lblMail.Text = contact.Email;
            lblPhone.Text = phone;
            lblAddress1.Text = contact.Address;
            lblMail1.Text = contact.Email;
            lblPhone1.Text = phone;
            SosyalMedyaLink(contact);
        }

        protected void SosyalMedyaLink(AnalitikBilisimSite.Model.Entities.Contact contact)
        {
            try
            {
                Facebook = contact.Facebook;
            }
            catch (Exception)
            {
                Facebook = "#";
            }
        
            try
            {
                Linkedin = contact.Linkedin;
            }
            catch (Exception)
            {
                Linkedin = "#";
            }
        }
    }
}