using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace LotBankingCrux_v_1
{
    public partial class projectproposal : System.Web.UI.Page
    {
        protected void resetControls()
        {
            TextBox1.Text = "";
            FirstStreet.Text = "";
            SecondStreet.Text = "";
            Cardinal.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CBHHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataInserted.ForeColor = System.Drawing.Color.Green;
            DataInserted.Text = "Data Inserted";
            LotBanking2.Crux.CruxDB DBObject = new LotBanking2.Crux.CruxDB();

            int numberLots = DropDownList1.SelectedIndex;

            string locationNotes = "";

            decimal acquisitionPrice;

            decimal improvementCost;

            decimal.TryParse(TextBox4.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out acquisitionPrice);
            decimal.TryParse(TextBox5.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out improvementCost);

            if (DBObject.insertPoject(LotBanking2.Crux.CruxDB.dbID, TextBox1.Text, FirstStreet.Text, SecondStreet.Text, Cardinal.Text, locationNotes, acquisitionPrice, improvementCost, numberLots) == 1)
            {
                DataInserted.Visible = true;
                resetControls();
            }
            else
            {
                DataInserted.ForeColor = System.Drawing.Color.Red;
                DataInserted.Text = "Error!";
                DataInserted.Visible = true;
            }
        }
    }
}