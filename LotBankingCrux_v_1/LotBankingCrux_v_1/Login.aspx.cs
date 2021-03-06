﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;

namespace LotBankingCrux_v_1.Account
{


    public partial class Login : Page
    {
        CruxDB dbObject = new CruxDB();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
        
            string userName = ((TextBox)LoginForm.FindControl("UserName")).Text;

            string passWord = ((TextBox)LoginForm.FindControl("Password")).Text;



            if (dbObject.login(userName, passWord) > 0)
            {
                Response.Redirect("CBHHome.aspx");
            }
            else
            {
                LoginForm.FindControl("LoginErrorLabel").Visible = true;
            }
        }
    }
}