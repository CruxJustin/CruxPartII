using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBanking2.Crux;

namespace LotBankingCrux_v_1.Account
{


    public partial class Login : Page
    {
        CruxDB dbObject = new CruxDB();
        //setup Sql Query string
        string sSql = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            /*Needs to be fixed
              if(dbObject.login(login from textbox, password from textbox) == -2)
            {
                Response.Redirect("Default.aspx");
            }
             * */
            string userName = ((TextBox)LoginForm.FindControl("UserName")).Text;

            string passWord = ((TextBox)LoginForm.FindControl("Password")).Text;



            if (dbObject.login(userName, passWord) > 0)
            {
                Response.Redirect("../CBHHome.aspx");
            }
            else
            {
                LoginForm.FindControl("LoginErrorLabel").Visible = true;
            }
        }
    }
}