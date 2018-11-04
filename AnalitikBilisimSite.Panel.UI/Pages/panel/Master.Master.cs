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
    public partial class Master : System.Web.UI.MasterPage
    {
        UsersService _userService = new UsersService();
        AnalitikDBContext db = new AnalitikDBContext();
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string AdminImage { get; set; }
        public string PathLink { get; set; }
        public string Path { get; set; }
        public int MessageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Users user = (Users)Session["user"];
                lblUser.Text = user.FirstName + " " + user.LastName;
                AdminImage = user.UserImage;

                try
                {
                    Facebook = _userService.Get(user.ID).Facebook;
                }
                catch (Exception)
                {
                    Facebook = "#";
                }
                try
                {
                    Twitter = _userService.Get(user.ID).Twitter;
                }
                catch (Exception)
                {
                    Twitter = "#";
                }
                try
                {
                    Youtube = _userService.Get(user.ID).Youtube;
                }
                catch (Exception)
                {
                    Youtube = "#";
                }
                try
                {
                    Linkedin = _userService.Get(user.ID).Linkedin;
                }
                catch (Exception)
                {
                    Linkedin = "#";
                }
                try
                {
                    Instagram = _userService.Get(user.ID).Instagram;
                }
                catch (Exception)
                {
                    Instagram = "#";
                }

                MessageCount = (from v in db.Visitor where v.Readed == false select v).Count();

                if (MessageCount > 0)
                {
                    lblMessageCount.Text = MessageCount.ToString();
                    lblMessageCount.Visible = true;
                }
                else
                {
                    lblMessageCount.Visible = false;
                }

            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Response.Redirect("../Login.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }
    }
}