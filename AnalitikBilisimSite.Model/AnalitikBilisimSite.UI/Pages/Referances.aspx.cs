using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class Referances : System.Web.UI.Page
    {
        AnalitikDBContext db = new AnalitikDBContext();
        ReferanceService _refService = new ReferanceService();
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
                lblReferenceTitle.Text = Localization.Referanslar;
                
            }
            catch (Exception)
            {

                throw;
            }
            ((MasterPage)this.Master).ReferanceMenu = "menu-active";
        }

        protected void Doldur(string Code)
        {
            int referanceID = (from r in db.Referance
                          where r.IsActive == true
                          join l in db.Language on r.LanguageID equals l.ID
                          where l.Code == Code
                          select r.ID).FirstOrDefault();

            if (referanceID == 0)
            {
                Code = "tr-TR";
            }
            ListReferance.DataSource = (from r in db.Referance
                                        where r.IsActive == true
                                        join l in db.Language on r.LanguageID equals l.ID
                                        where l.Code == Code
                                        select r).ToList();

            ListReferance.DataBind();
        }

        //protected void btnDetay_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int refID = Int32.Parse(btn.CommandArgument);

        //    Session["ref"] = refID;
        //    Response.Redirect("ReferanceDetails.aspx");
        //}
    }
}