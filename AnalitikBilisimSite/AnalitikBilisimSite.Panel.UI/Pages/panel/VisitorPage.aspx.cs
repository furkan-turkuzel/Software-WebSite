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
    public partial class VisitorPage : System.Web.UI.Page
    {
        VisitorService _visitorService = new VisitorService();
        AnalitikDBContext db = new AnalitikDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListMessage.DataSource = (from v in db.Visitor
                                      orderby v.SendTime descending
                                      select new {
                                                  ID = v.ID, 
                                                  FullName = v.FullName,
                                                  Subject = v.Subject,
                                                  SendTime = v.SendTime,
                                                  Readed = v.Readed,
                                                  Message = (v.Message.Length > 50) ?  v.Message.Substring(0, 49)+"..." : v.Message
                                      }).ToList();
            ListMessage.DataBind();
            ((Master)this.Master).Path = "Ziyaretçi";
            ((Master)this.Master).PathLink = "VisitorPage.aspx";
        }
        protected void btnOkunmayan_Click(object sender, EventArgs e)
        {
            ListMessage.DataSource = (from v in db.Visitor
                                      where v.Readed == false orderby v.SendTime descending
                                      select new
                                      {
                                          ID = v.ID,
                                          FullName = v.FullName,
                                          Subject = v.Subject,
                                          SendTime = v.SendTime,
                                          Readed = v.Readed,
                                          Message = (v.Message.Length > 50) ? v.Message.Substring(0, 149) : v.Message
                                      }).ToList();
            ListMessage.DataBind();

            lblControl.Text = "Okunmayan";
        }

        protected void btnOkunan_Click(object sender, EventArgs e)
        {
            ListMessage.DataSource = (from v in db.Visitor
                                      where v.Readed == true orderby v.SendTime descending
                                      select new
                                      {
                                          ID = v.ID,
                                          FullName = v.FullName,
                                          Subject = v.Subject,
                                          SendTime = v.SendTime,
                                          Readed = v.Readed,
                                          Message = (v.Message.Length > 50) ? v.Message.Substring(0, 149) : v.Message
                                      }).ToList();
            ListMessage.DataBind();

            lblControl.Text = "Okunan";
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ID = Int32.Parse(btn.CommandArgument);

            Visitor visitor = (from v in db.Visitor where v.ID == ID select v).FirstOrDefault();

            _visitorService.Delete(visitor);
            Response.Redirect("VisitorPage.aspx");
        }

        protected void btnOku_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ID = Int32.Parse(btn.CommandArgument);

            string mesaj = "";

            Visitor visitor = (from v in db.Visitor where v.ID == ID select v).FirstOrDefault();
            lblKonu.Text = visitor.Subject;
            for (int i = 0; i < visitor.Message.Length; i++)
            {
                mesaj += visitor.Message[i];
                if (i % 40 == 0 && i != 0)
                {
                    mesaj += "</br>";
                }
            }
            lblMesaj.Text = mesaj;

            visitor.Readed = true;
            _visitorService.Update(visitor);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            
        }

        protected void btnCalender_Click(object sender, EventArgs e)
        {
            DateTime dateStart = Convert.ToDateTime(txtCalender1.Text);
            DateTime dateEnd = Convert.ToDateTime(txtCalender2.Text);

            if (lblControl.Text == "Okunmayan")
            {
                ListMessage.DataSource = (from v in db.Visitor
                                          where v.Readed == false
                                         && v.SendTime >= dateStart
                                         && v.SendTime <= dateEnd
                                          orderby v.SendTime descending
                                          select new
                                          {
                                              ID = v.ID,
                                              FullName = v.FullName,
                                              Subject = v.Subject,
                                              SendTime = v.SendTime,
                                              Readed = v.Readed,
                                              Message = (v.Message.Length > 50) ? v.Message.Substring(0, 149) : v.Message
                                          }).ToList();
                ListMessage.DataBind();
            }
            else if (lblControl.Text == "Okunan")
            {
                ListMessage.DataSource = (from v in db.Visitor
                                          where v.Readed == true
                                         && v.SendTime >= dateStart
                                         && v.SendTime <= dateEnd
                                          orderby v.SendTime descending
                                          select new
                                          {
                                              ID = v.ID,
                                              FullName = v.FullName,
                                              Subject = v.Subject,
                                              SendTime = v.SendTime,
                                              Readed = v.Readed,
                                              Message = (v.Message.Length > 50) ? v.Message.Substring(0, 149) : v.Message
                                          }).ToList();
                ListMessage.DataBind();
            }
            else
            {
                ListMessage.DataSource = (from v in db.Visitor
                                          where v.SendTime >= dateStart
                                             && v.SendTime <= dateEnd
                                          orderby v.SendTime descending
                                          select new
                                          {
                                              ID = v.ID,
                                              FullName = v.FullName,
                                              Subject = v.Subject,
                                              SendTime = v.SendTime,
                                              Readed = v.Readed,
                                              Message = (v.Message.Length > 50) ? v.Message.Substring(0, 149) : v.Message
                                          }).ToList();
                ListMessage.DataBind();
            }
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtCalender1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtCalender2.Text = Calendar2.SelectedDate.ToShortDateString();
        }
    }
}