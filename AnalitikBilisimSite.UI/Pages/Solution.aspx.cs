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
    public partial class Solution : System.Web.UI.Page
    {
        AnalitikDBContext db = new AnalitikDBContext();
        SolutionService _solutionService = new SolutionService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int categoryID = Convert.ToInt32(Session["category"]);
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
                lblSolutionTitle.Text = Localization.Çözümlerimiz;
            }
            catch (Exception)
            {

                throw;
            }
            
            ((MasterPage)this.Master).SolutionMenu = "menu-active";
        }

        protected void Doldur(string Code)
        {
            if (Session["category"] != null)
            {
                int categoryID = Convert.ToInt32(Session["category"]);
                int solutionID = (from s in db.Solution
                                  where s.IsActive == true && s.CategoryID == categoryID
                                  join l in db.Language on s.LanguageID equals l.ID
                                  where l.Code == Code
                                  select s.ID).FirstOrDefault();

                if (solutionID == 0)
                {
                    Code = "tr-TR";
                }
                ListSolution.DataSource = (from s in db.Solution
                                           where s.IsActive == true && s.CategoryID == categoryID
                                           join l in db.Language on s.LanguageID equals l.ID
                                           where l.Code == Code
                                           select s).ToList();
            }
            else
            {
                int solutionID = (from s in db.Solution
                                  where s.IsActive == true
                                  join l in db.Language on s.LanguageID equals l.ID
                                  where l.Code == Code
                                  select s.ID).FirstOrDefault();

                if (solutionID == 0)
                {
                    Code = "tr-TR";
                }
                ListSolution.DataSource = (from s in db.Solution
                                           where s.IsActive == true
                                           join l in db.Language on s.LanguageID equals l.ID
                                           where l.Code == Code
                                           select s).ToList();
            }
            ListSolution.DataBind();
            Session["category"] = null;
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int solutionID = Int32.Parse(btn.CommandArgument);

        //    Session["solution"] = solutionID;
        //    Response.Redirect("SolutionDetails.aspx");
        //}
    }
}