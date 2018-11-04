using AnalitikBilisimSite.BLL.Concrete;
using AnalitikBilisimSite.DAL.Concrete.DBContext;
using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalitikBilisimSite.Panel.UI.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        UsersService users = new UsersService();
        CommonService _commonService = new CommonService();
        AnalitikDBContext db = new AnalitikDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int commonID = (from c in db.Common select c.ID).FirstOrDefault();
            Common common = _commonService.Get(commonID);
            if (!IsPostBack)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();

                string Image = common.Logo;
                string subImage = Image.Substring(9, Convert.ToInt32(Image.Length) - 9);
                ImgLoginLogo.ImageUrl = "panel/"+subImage;
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string UserName = String.Format("{0}", Request.Form["txtUserName"]);
            string Password = String.Format("{0}", Request.Form["txtPassword"]);

            Users User = (from u in db.Users where u.UserName == UserName && u.Password == Password && u.IsActive == true select u).FirstOrDefault();

            if (UserName == "" || Password == "")
            {
                lblMessage.Text = "Kullanıcı Adı veya Şifre Girilmedi. Lütfen Bütün alanları doldurun!!!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
            else if (User == null)
            {
                lblMessage.Text = "Kullanıcı Adı veya Şifre Hatalı!!!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
            else
            {
                Session["user"] = User;
                Session.Timeout = 15;
                Response.Redirect("panel/Index.aspx");
            }
        }

    }
}