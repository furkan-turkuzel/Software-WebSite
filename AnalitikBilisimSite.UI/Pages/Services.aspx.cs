using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class Services : System.Web.UI.Page
    {
        ServicesService _servicesService = new ServicesService();
        AnalitikDBContext db = new AnalitikDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AnalitikBilisimSite.Model.Entities.Language language = (Language)Session["dil"];
                string languageCode;
                if (language != null)
                {
                    languageCode = language.Code;
                    Doldur(languageCode);
                }
                else
                {
                    languageCode = "tr-TR";
                    Doldur(languageCode);
                }
                lblServicesTitle.Text = Localization.Hizmetlerimiz;
            }
            catch (Exception)
            {

                throw;
            }
            
            ((MasterPage)this.Master).ServicesMenu = "menu-active";
        }

        protected void Doldur(string Code)
        {
            int ServicesID = (from s in db.Services
                          where s.IsActive == true
                              join l in db.Language on s.LanguageID equals l.ID
                              where l.Code == Code
                              select s.ID).FirstOrDefault();

            if (ServicesID == 0)
            {
                Code = "tr-TR";
            }
            ListServices.DataSource = (from s in db.Services
                                   where s.IsActive == true
                                       join l in db.Language on s.LanguageID equals l.ID
                                       where l.Code == Code
                                       select s).ToList();

            ListServices.DataBind();
        }

        //protected void btnDetail_Click(object sender, EventArgs e)
        //{
        //    LinkButton btn = (LinkButton)sender;
        //    int serviceID = Convert.ToInt32(btn.CommandArgument);

        //    Session["hizmet"] = serviceID;
        //    Response.Redirect("ServiceDetails.aspx");
        //}
    }
}