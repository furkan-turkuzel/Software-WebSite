using AnalitikBilisimSite.BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.UI.Pages
{
    public partial class ServiceDetails : System.Web.UI.Page
    {
        ServicesService _service = new ServicesService();

        protected void Page_Load(object sender, EventArgs e)
        {
            int serviceID = Convert.ToInt32(Session["hizmet"]);
            AnalitikBilisimSite.Model.Entities.Services service = _service.Get(serviceID);

            ImgAbout.ImageUrl = service.Image;
            lblTitle.Text = service.Title;
            lblSmallWriting.Text = service.SmallWriting;
            lblBigWriting.Text = service.BigWriting;

        }
    }
}