﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1
{
    public partial class ProjectDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LotTakeDown_OnClick(object sender, EventArgs e)
        {
            //Link to the takedown page based on the project we are on
            Response.Redirect("");
        }
    }
}