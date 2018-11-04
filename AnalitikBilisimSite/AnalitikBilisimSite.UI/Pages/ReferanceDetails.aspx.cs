using AnalitikBilisimSite.BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class ReferanceDetails : System.Web.UI.Page
    {
        ReferanceService _refService = new ReferanceService();
        protected void Page_Load(object sender, EventArgs e)
        {
            int refID = Convert.ToInt32(Session["ref"]);
            AnalitikBilisimSite.Model.Entities.Referance referance = _refService.Get(refID);

            
        }
    }
}