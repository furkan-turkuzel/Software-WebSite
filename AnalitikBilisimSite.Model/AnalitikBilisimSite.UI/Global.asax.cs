using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AnalitikBilisimSite.UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }
    }
}