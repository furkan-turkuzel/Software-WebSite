using AnalitikBilisimSite.BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class SolutionDetails : System.Web.UI.Page
    {
        SolutionService _solutionService = new SolutionService();
        protected void Page_Load(object sender, EventArgs e)
        {
            int solutionID = Convert.ToInt32(Session["solution"]);
            AnalitikBilisimSite.Model.Entities.Solution solution = _solutionService.Get(solutionID);

            ImgAbout.ImageUrl = solution.Image;
            lblTitle.Text = solution.Title;
            lblSmallWriting.Text = solution.SmallWriting;
            lblBigWriting.Text = solution.BigWriting;
        }
    }
}